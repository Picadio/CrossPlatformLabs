sudo apt update
sudo apt upgrade -y

wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

sudo apt update

sudo apt install -y dotnet-sdk-8.0

dotnet --version

cd /vagrant/Lab4

sudo dotnet nuget add source http://10.0.2.2:5000/v3/index.json -n Baget
sudo dotnet add package abedryk

cd ..

dotnet run --project Lab4 version