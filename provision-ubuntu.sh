﻿#!/bin/bash

# Update and upgrade the system
sudo apt-get update -y
sudo apt-get upgrade -y

# Install dependencies
sudo apt-get install -y wget apt-transport-https software-properties-common

# Add Microsoft package repository for .NET SDK
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

# Install .NET SDK 8.0
sudo apt-get update
sudo apt-get install -y dotnet-sdk-8.0

# Configure BaGet as NuGet source using environment variable
dotnet nuget add source http://localhost:5000/v3/index.json -n Baget
# dotnet tool install --global lab4 --version 1.0.0

cd /home/vagrant/project

echo "Ubuntu environment setup complete."
