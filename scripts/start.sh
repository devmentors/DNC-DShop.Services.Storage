#!/bin/bash
export ASPNETCORE_ENVIRONMENT=local
cd src/DShop.Services.Storage
dotnet run --no-restore