#!/usr/bin/env bash
cd ../GianLuca.Domain.Core.UnitTest/
dotnet restore
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput='../DomainCore.xml'