NUGETVERSION=1.0.0
dotnet pack Bdd -c Release /p:PackageVersion=$NUGETVERSION
dotnet nuget push Bdd/bin/Release/Testify.Bdd.$NUGETVERSION.nupkg -k $NUGETKEY -s nuget.org