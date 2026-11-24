@ECHO OFF
cd PWTrilogyPatcher.Desktop
dotnet publish -c Release -r linux-x64 /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true --output "bin\Publish\net8.0-linux"
ren bin\Publish\net8.0-linux\PWTrilogyPatcher.Desktop AATrilogyPatcher-linux
