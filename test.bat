rem cd ProCardLib
rem dotnet restore
rem dotnet build
cd .\ProCardLib.Test
dotnet restore
dotnet build
dotnet test
cd ..