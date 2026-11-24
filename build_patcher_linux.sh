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

echo "=== Compilando y publicando AATrilogyPatcher-linux (Single File) ==="
cd PWTrilogyPatcher.Desktop
"$DOTNET_BIN" publish -c Release -r linux-x64 /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true --output "bin/Publish/net8.0-linux"
cp -v "bin/Publish/net8.0-linux/PWTrilogyPatcher.Desktop" "bin/Publish/net8.0-linux/AATrilogyPatcher-linux"
chmod +x "bin/Publish/net8.0-linux/AATrilogyPatcher-linux"

# Copiar a la carpeta de distribución patches/
if [ -d "$PROJECT_ROOT/patches" ]; then
    rm -f "$PROJECT_ROOT/patches/AATrilogyPatcher-linux" 2>/dev/null || true
    cp -v --remove-destination "bin/Publish/net8.0-linux/AATrilogyPatcher-linux" "$PROJECT_ROOT/patches/AATrilogyPatcher-linux"
fi

echo "=== Publicación completada con éxito: $SCRIPT_DIR/PWTrilogyPatcher.Desktop/bin/Publish/net8.0-linux/AATrilogyPatcher-linux ==="
