#!/usr/bin/env bash
set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROJECT_ROOT="$(cd "$SCRIPT_DIR/../.." && pwd)"
cd "$SCRIPT_DIR"

if command -v dotnet &> /dev/null; then
    DOTNET_BIN="dotnet"
elif [ -x "$HOME/.dotnet/dotnet" ]; then
    DOTNET_BIN="$HOME/.dotnet/dotnet"
else
    echo "Error: No se encontró dotnet en PATH ni en ~/.dotnet/dotnet"
    exit 1
fi

echo "=== Generando payload cifrado para el parcheador ==="
python3 "$PROJECT_ROOT/patches/encrypt_patch.py"

echo "=== Compilando y publicando AATrilogyPatcher.exe (Windows Single File) ==="
cd PWTrilogyPatcher.Desktop
"$DOTNET_BIN" publish -c Release -r win-x86 /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true --output "bin/Publish/net8.0-windows"
cp -v "bin/Publish/net8.0-windows/PWTrilogyPatcher.Desktop.exe" "bin/Publish/net8.0-windows/AATrilogyPatcher.exe"

# Copiar a la carpeta de distribución patches/
if [ -d "$PROJECT_ROOT/patches" ]; then
    cp -v "bin/Publish/net8.0-windows/AATrilogyPatcher.exe" "$PROJECT_ROOT/patches/AATrilogyPatcher.exe"
fi

echo "=== Publicación completada con éxito: $SCRIPT_DIR/PWTrilogyPatcher.Desktop/bin/Publish/net8.0-windows/AATrilogyPatcher.exe ==="
