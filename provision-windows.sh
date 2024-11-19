choco install dotnet-sdk -y
refreshenv
dotnet nuget add source http://localhost:5000/v3/index.json -n Baget

# Install the lab4 NuGet tool
dotnet tool install --global lab4 --version 1.0.0
dotnet --version

Write-Host "Windows environment setup complete."