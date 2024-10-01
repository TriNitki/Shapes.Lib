docker pull loicsharma/baget
docker run -d --rm --name nuget-server -p 5555:80 --env-file Nuget/baget.env -v "baget-data:/var/baget" loicsharma/baget:latest

cd Nuget/Packages
dotnet nuget push -s http://localhost:5555/v3/index.json -k NUGET-SERVER-API-KEY Shapes.Lib.1.0.0.nupkg
dotnet nuget push -s http://localhost:5555/v3/index.json -k NUGET-SERVER-API-KEY Shapes.Lib.1.0.0.snupkg

pause