# Phoenix Wright: Ace Attorney Trilogy - xMod

[![GitHub Release](https://img.shields.io/github/v/release/CTPache/PWTrilogy-xMod?color=blue&label=Versi%C3%B3n)](https://github.com/CTPache/PWTrilogy-xMod/releases/latest)
[![Plataformas](https://img.shields.io/badge/Plataformas-Windows%20%7C%20Linux%20%28Steam%20Deck%29-brightgreen)](#-instrucciones-de-instalación)
[![Idiomas](https://img.shields.io/badge/Idiomas%20A%C3%B1adidos-Espa%C3%B1ol%20%7C%20Italiano-orange)](#-características-principales)

**PWTrilogy-xMod** es una expansión comunitaria y actualización de contenido diseñada para convertir *Phoenix Wright: Ace Attorney Trilogy* en la **edición definitiva** del juego.

No se trata únicamente de un parche de traducción, sino de un mod integral que expande la experiencia con nuevas salas interactivas, mejoras en la calidad de vida (QoL), banda sonora orquestal dinámica, soporte nativo de 64 bits para Linux (Steam Deck) y Windows, y coexistencia multilingüe sin alterar los idiomas oficiales de Capcom.

---

## ⚖️ Características Principales

### 🌐 Nuevos Idiomas Coexistentes
- **Español de España**: Traducción, interfaz gráfica y voces adaptadas por **Traducciones Kurain**.
- **Italiano**: Localización completa desarrollada por el **Dragon Punk Team**.
- **Coexistencia Total**: Ambos idiomas se suman a los 9 idiomas oficiales de Capcom (totalizando 11 idiomas seleccionables) con sus propios gráficos vectorizados en alta resolución, textos y pistas de audio sin sobreescribir ningún idioma base.

### 🏆 Galería de Galardones Interactiva (Accolades Gallery)
- Nueva sala interactiva en el menú de la **Galería** con vitrinas tridimensionales y marcos por categoría (bronce, plata y oro).
- **Persistencia local offline** (`SaveData/accolades.json`): Los logros se guardan en tu equipo tanto en modo offline como online.
- **Sincronización bidireccional con Steam**: Detecta y sincroniza automáticamente los logros desbloqueados en Steam, y permite subir a tu cuenta los galardones conseguidos mientras jugabas offline.
- Notificaciones emergentes *in-game* al desbloquear galardones durante los juicios e investigaciones.

### 📜 Historial de Conversación (Backlog)
- Revisa las conversaciones anteriores en cualquier momento durante los juicios y las fases de investigación para no perder ningún testimonio ni detalle clave del caso.

### 🎻 Banda Sonora Orquestal Dinámica en Partida
- Nueva opción en partida para alternar entre la música original y los arreglos orquestales durante el desarrollo de la historia, manteniendo transiciones fluidas y bucles continuos.

### 🎶 Sala de Música Ampliada (Music Gallery)
- Nuevas pistas añadidas al reproductor de la Galería, incluyendo el célebre álbum de arreglos orquestales *"Gyakuten Meets Orchestra"*.

### 🚀 Soporte Multiplataforma Nativo de 64 bits
- **Linux Nativo (64-bit)**: Ejecutable y librerías nativas con renderizado Vulkan/OpenGL, ideal para escritorios Linux y **Steam Deck** sin capas de emulación innecesarias.
- **Windows (64-bit y 32-bit vanilla)**: Runtimes optimizados que resuelven incompatibilidades y evitan el error de Mono (*Failed to load mono*).

### 🛠️ Parcheador Universal Autocontenido (PWTrilogyPatcher)
- Interfaz gráfica en Avalonia UI traducida a **10 idiomas** (Español, Italiano, English, Português-BR, Français, Deutsch, 日本語, 한국어, 简体中文, 繁體中文) con autodetección del idioma del sistema y fallback a inglés.
- **Payload cifrado integrado**: No requiere descargas de parches por separado; el parcheador contiene los datos comprimidos y protegidos con cifrado AES-256 (derivado del ejecutable legítimo del juego), aplicando los deltas de forma inmediata y segura.

---

## 📥 Instrucciones de Instalación

1. Dirígete a la pestaña de **[Últimas Versiones (Releases)](https://github.com/CTPache/PWTrilogy-xMod/releases/latest)**.
2. Descarga el instalador correspondiente a tu sistema operativo:
   - **Windows**: Descarga `AATrilogyPatcher.exe`.
   - **Linux / Steam Deck**: Descarga `AATrilogyPatcher-linux`.
3. Ejecuta el parcheador:
   - En Linux o Steam Deck, asegúrate de otorgarle permisos de ejecución antes de abrirlo:
     ```bash
     chmod +x AATrilogyPatcher-linux
     ./AATrilogyPatcher-linux
     ```
4. El parcheador detectará automáticamente la ruta de instalación de Steam. Si no la detecta o utilizas una instalación personalizada, introduce la ruta manualmente.
5. Selecciona la versión de destino adecuada (Windows 32-bit, Windows 64-bit o Linux 64-bit) y presiona **«Parchear»**.
6. Una vez completado, abre el juego. Si arranca en otro idioma, cámbialo a tu preferencia en el menú **Opciones** $\rightarrow$ **Idioma**.

---

## ⚙️ Notas de la Actualización In-Game

Al iniciar el juego por primera vez tras aplicar el xMod, se desplegará automáticamente un cuadro de diálogo con las notas de la actualización en tu idioma activo, resumiendo todas las novedades incorporadas.

---

## ❓ Preguntas Frecuentes y Solución de Problemas

<details>
<summary><b>¿El parcheador falla al escribir archivos o reporta error de permisos?</b></summary>
Asegúrate de haber extraído el ejecutable en una carpeta con permisos de escritura de usuario (como tu Escritorio o carpeta personal) y de que el juego esté completamente cerrado antes de iniciar el parcheo.
</details>

<details>
<summary><b>¿Mis partidas guardadas se conservan?</b></summary>
Sí. El xMod preserva y expande las ranuras de datos de guardado (110 ranuras para acomodar los 11 idiomas), manteniendo plena compatibilidad con tus partidas anteriores e incorporando la persistencia de galardones.
</details>

<details>
<summary><b>¿Cómo se instala en Steam Deck?</b></summary>
Entra en el <i>Modo Escritorio</i> de tu Steam Deck, descarga <code>AATrilogyPatcher-linux</code>, dale permisos de ejecución y ejecútalo para aplicar el mod sobre tu instalación de Steam. Al volver al <i>Modo Juego</i>, las novedades estarán activas.
</details>

---

## 👥 Créditos y Reconocimientos

### Desarrollo de PWTrilogy-xMod
- **Desarrollo del mod, Romhacking e Ingeniería:** [CTPache](https://github.com/CTPache)
- **Desarrollo del Parcheador (Avalonia / Mara):** [Worst Aqua Player](https://github.com/WorstAquaPlayer), [CTPache](https://github.com/CTPache), [legendaryX77](https://github.com/legendaryX77)
- **Diseño de Interfaz y Ajustes de Textos:** [JauCR](https://github.com/JauCR), [CTPache](https://github.com/CTPache)

### Traducción al Español (Traducciones Kurain)
- **Dirección:** [JauCR](https://github.com/JauCR)
- **Edición Gráfica:** [JauCR](https://github.com/JauCR), MF5K
- **Romhacking:** [CTPache](https://github.com/CTPache), [Worst Aqua Player](https://github.com/WorstAquaPlayer), Kaplas, Dant (del proyecto *Судебный поворот*)
- **Testeo:** [CTPache](https://github.com/CTPache), franciskirk, [Worst Aqua Player](https://github.com/WorstAquaPlayer)

### Traducción al Italiano (Dragon Punk Team)
- **Localización y Adaptación:** Dj_Mike238 y el equipo de **Dragon Punk Team**.

### Agradecimientos Especiales
- Retroductor, roli 300, LegendaryX77.
- A la comunidad de [TraduSquare](https://tradusquare.es) y [Jacutem Sabão](https://jacutemsabao.bitbucket.io).
- A [Darkmet98](https://github.com/Darkmet98) por la librería y herramientas de parcheo Mara.
- A **CAPCOM** por dar vida a la saga *Ace Attorney*.
