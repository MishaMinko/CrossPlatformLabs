# Install Chocolatey
Set-ExecutionPolicy Bypass -Scope Process -Force
[System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072
iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

# Install .NET SDK 8.0
choco install dotnet-8.0-sdk -y

# Refresh environment variables
refreshenv

dotnet nuget add source http://localhost:5000/v3/index.json -n Baget
dotnet tool install --global lab4 --version 1.0.0

# Verify installation
dotnet --version

# Navigate to the project directory
cd C:\project

# Run lab4
dotnet run --project lAB4 -- version

Write-Host "Windows environment setup complete and lab4 executed"