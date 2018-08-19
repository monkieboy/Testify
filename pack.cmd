SET "NUGETVERSION=%1"
SET "NUGETKEY=%2"
SET "PACKACTION=Bdd -c Release /p:PackageVersion=%NUGETVERSION%"
SET "PUSHACTION=Bdd/bin/Release/Testify.Bdd.%NUGETVERSION%.nupkg -k %NUGETKEY% -s nuget.org"
ECHO %PACKACTION%
ECHO %PUSHACTION%
dotnet pack %PACKACTION%
dotnet nuget push %PUSHACTION%