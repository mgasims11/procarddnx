cd ProCardLib
dotnet restore
dotnet build
cd ..\ProCardLib.Test
dotnet restore
dotnet build
dotnet test
cd ..