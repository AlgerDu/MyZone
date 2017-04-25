cd E:/DProject/MyZone/Src/WebClient;
npm run build;
Stop-Website "MyZone" -ea stop;
cd E:/DProject/MyZone/Src/Server;
dotnet publish -o D:\www\MyZone;
Start-Website "MyZone" -ea stop;