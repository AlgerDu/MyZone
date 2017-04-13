Stop-Website "MyZone" -ea stop;
cd E:/DProject/MyZone/Src/Server;
dotnet publish -o D:\www\MyZone;
Start-Website "MyZone" -ea stop;