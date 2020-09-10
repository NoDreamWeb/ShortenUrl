# ShortenUrl

for create a nuget package please check :
https://docs.github.com/en/packages/using-github-packages-with-your-projects-ecosystem/configuring-dotnet-cli-for-use-with-github-packages

Local pc publish steps:
1. create nuget.config
2. set update the token in https://github.com/settings/tokens
3. set the .csproj file with url
4. build the package :dotnet pack --configuration Release
5. dotnet nuget push "bin/Release/<project>_<version>.nupkg" --source "github"
6. done
  
Github publish steps:
1. Commit changes.
2. 'Actions' > 'Run workflow'
3. done.

for download the nupkg for github:
1. create nuget.config
2. add the url in the NuGet Package Manager (https://nuget.pkg.github.com/NoDreamWeb/index.json)

  

