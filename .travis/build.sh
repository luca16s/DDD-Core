#!/usr/bin/env bash
cd ../GianLuca.Domain.Core/
dotnet tool install --global coverlet.console
dotnet restore
dotnet build