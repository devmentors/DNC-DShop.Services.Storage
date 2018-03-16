#!/bin/bash

echo Executing after success scripts on branch $TRAVIS_BRANCH
echo Triggering MyGet package build

cd src/DShop.Services.Storage.Models
dotnet pack /p:PackageVersion=1.0.$TRAVIS_BUILD_NUMBER --no-restore -o .

echo Uploading DShop.Services.Storage.Models package to MyGet using branch $TRAVIS_BRANCH

case "$TRAVIS_BRANCH" in
  "master")
    dotnet nuget push *.nupkg -k $MYGET_API_KEY -s https://www.myget.org/F/dnc-dshop/api/v2/package
    ;;
  "develop")
    dotnet nuget push *.nupkg -k $MYGET_DEV_API_KEY -s https://www.myget.org/F/dnc-dshop-dev/api/v2/package
    ;;    
esac

cd ../../
dotnet publish --no-restore ./src/DShop.Services.Storage -c Release -o ./bin/Docker

DOCKER_ENV=''
DOCKER_TAG=''

case "$TRAVIS_BRANCH" in
  "master")
    DOCKER_ENV=production
    DOCKER_TAG=latest
    ;;
  "develop")
    DOCKER_ENV=development
    DOCKER_TAG=dev
    ;;    
esac

docker login -u $DOCKER_USERNAME -p $DOCKER_PASSWORD
docker build -f ./src/DShop.Services.Storage/Dockerfile.$DOCKER_ENV -t dshop.services.storage:$DOCKER_TAG ./src/DShop.Services.Storage
docker tag dshop.services.storage:$DOCKER_TAG $DOCKER_USERNAME/dshop.services.storage:$DOCKER_TAG
docker push $DOCKER_USERNAME/dshop.services.storage:$DOCKER_TAG