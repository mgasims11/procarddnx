rem cd ProCardLib
rem dotnet restore
rem dotnet build
cd .\ProCardLib.Test
dotnet restore
rem dotnet build
dotnet test
cd ..