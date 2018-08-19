export FrameworkPathOverride=$(dirname $(which mono))/../lib/mono/4.5/
NUGETVERSION=2.4.0
dotnet pack Bdd -c Release /p:PackageVersion=$NUGETVERSION
dotnet nuget push Bdd/bin/Release/Testify.Bdd.$NUGETVERSION.nupkg -k $NUGETKEY -s nuget.org