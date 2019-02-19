set -e;
rm -rf bin
dotnet restore
dotnet build -c Release
dotnet pack -c Release


dotnet nuget push `ls ./bin/Release/*.nupkg`  -s https://www.nuget.org/packages -k oy2bxhvuvfir77xlbyxqyyaoug44u33ejnxbw4mepzfiim