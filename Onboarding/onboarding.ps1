Clear-Host
Write-Host 'ONBOARDING AUTOMATION INITIATING'

Write-Host 'Installing Chocolatey package manager for Windows...'
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))
Write-Host 'Installing Visual Studio Code...'
choco install visualstudiocode -y --force 
Write-Host 'Installing .NET SDK...'
choco install dotnet-6.0-sdk -y --force
Write-Host 'Refreshing Powershell environment...'
refreshenv
$env:Path += ";C:\Program Files\dotnet"
Write-Host 'Installing Entity Framework CLI...'
dotnet tool install -g dotnet-ef
Write-Host 'Installing .NET Code Generator CLI...'
dotnet tool install -g dotnet-aspnet-codegenerator

Write-Host 'Onboarding Complete'
