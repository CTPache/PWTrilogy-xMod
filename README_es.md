# Phoenix Wright: Ace Attorney Trilogy - xMod

[English](README.md) | **Español** | [Italiano](README_it.md) | [Português (BR)](README_pt.md) | [Français](README_fr.md) | [Deutsch](README_de.md) | [日本語](README_ja.md) | [한국어](README_ko.md) | [简体中文](README_zh_cn.md) | [繁體中文](README_zh_tw.md)

**PWTrilogy-xMod** es una expansión comunitaria y actualización de contenido diseñada para convertir *Phoenix Wright: Ace Attorney Trilogy* en la **edición definitiva** del juego.

Se trata de un mod integral que expande la experiencia con nuevas salas interactivas, mejoras en la calidad de vida (QoL), banda sonora orquestal dinámica, soporte nativo de 64 bits para Linux (Steam Deck) y Windows, y coexistencia multilingüe sin alterar los idiomas oficiales de CAPCOM.

---

## Características principales

### Nuevos idiomas coexistentes
- **Español de España**: Traducción, interfaz gráfica y voces adaptadas por **Traducciones Kurain**.
- **Italiano**: Localización completa desarrollada por el **Dragon Punk Team**.

### Galería de galardones interactiva
![alt text](image-1.png)
- Nueva sala interactiva en el menú de la **Galería** con vitrinas tridimensionales y marcos por categoría (bronce, plata y oro).
- **Sincronización bidireccional con Steam**: Detecta y sincroniza automáticamente los logros desbloqueados en Steam, y permite subir a tu cuenta los galardones conseguidos mientras jugabas offline.
- Notificaciones emergentes *in-game* al desbloquear galardones.

### Historial de conversación
![alt text](image.png)
- Revisa las conversaciones anteriores en cualquier momento.

### Banda Sonora Orquestal en partida
- Nueva opción en partida para alternar entre la música original y los arreglos orquestales durante el desarrollo de la historia.

### Sala de Música Ampliada
![alt text](image-2.png)
- Nuevas pistas añadidas al reproductor de la Galería, incluyendo el álbum *"Gyakuten Meets Orchestra"*.

### Soporte Multiplataforma Nativo de 64 bits
- **Linux Nativo (64-bit)**: Ejecutable y librerías nativas con renderizado Vulkan/OpenGL, ideal para escritorios Linux y **Steam Deck**.
- **Windows (64-bit y 32-bit)**: Runtimes de 64 bits para procesadores actuales. Se conserva el runtime original de 32 bits por compatibilidad.

### Parcheador Universal Autocontenido (PWTrilogyPatcher)
- Interfaz gráfica en Avalonia UI traducida a los **10 idiomas** del juego (Español, Italiano, English, Português-BR, Français, Deutsch, 日本語, 한국어, 简体中文, 繁體中文).
- **Payload cifrado integrado**: El parcheador contiene los datos comprimidos y protegidos con cifrado AES-256, aplicando los deltas de forma inmediata y segura.

---

## Instrucciones de Instalación

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
   - En Linux, pon esta línea en las opciones de arranque de Steam:
   ```
   sh -c 'exec ./PWAAT.x86_64' -- %command%
   ```

---

## Notas de la Actualización In-Game

Al iniciar el juego por primera vez tras aplicar el xMod, se desplegará automáticamente un cuadro de diálogo con las notas de la actualización en tu idioma activo, resumiendo todas las novedades incorporadas.

---

## Preguntas Frecuentes y Solución de Problemas

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

## Créditos y Reconocimientos

### Desarrollo de PWTrilogy-xMod
- **Desarrollo del mod, Romhacking e Ingeniería:** [CTPache](https://github.com/CTPache)
- **Desarrollo del Parcheador (Avalonia / Mara):** [Worst Aqua Player](https://github.com/WorstAquaPlayer), [CTPache](https://github.com/CTPache), [legendaryX77](https://github.com/legendaryX77)
- **Diseño de Interfaz y Ajustes de Textos:** [JauCR](https://github.com/JauCR), [CTPache](https://github.com/CTPache)

### Traducciones 
- Al Español [Traducciones Kurain](https://github.com/Traducciones-Kurain/PWTrilogy-ESP/blob/master/README.md)
- Al Italiano [Dragon Punk Team](https://dragonpunkteam.altervista.org/phoenix-wright-ace-attorney-trilogy/)

### Agradecimientos Especiales
- A [Darkmet98](https://github.com/Darkmet98) por la librería y herramientas de parcheo Mara.
- A **Shu Takumi** por dar vida a la saga *Ace Attorney*.
