# Phoenix Wright: Ace Attorney Trilogy - xMod

**English** | [Español](README_es.md) | [Italiano](README_it.md) | [Português (BR)](README_pt.md) | [Français](README_fr.md) | [Deutsch](README_de.md) | [日本語](README_ja.md) | [한국어](README_ko.md) | [简体中文](README_zh_cn.md) | [繁體中文](README_zh_tw.md)

**PWTrilogy-xMod** is a community-driven expansion and content update designed to turn *Phoenix Wright: Ace Attorney Trilogy* into the **definitive edition** of the game.

It is a comprehensive mod that enhances the experience with new interactive rooms, Quality of Life (QoL) improvements, dynamic orchestral soundtrack, native 64-bit support for Linux (Steam Deck) and Windows, and multilingual coexistence without altering CAPCOM's official languages.

---

## Key Features

### New Coexisting Languages
- **European Spanish**: Translation, graphical user interface, and dubbed voices adapted by **Traducciones Kurain**.
- **Italian**: Full localization developed by **Dragon Punk Team**.

### Interactive Accolades Gallery
![alt text](image-1.png)
- New interactive room in the **Gallery** menu featuring 3D display cases and frames by category (bronze, silver, and gold).
- **Two-way Steam synchronization**: Automatically detects and syncs achievements unlocked on Steam, and allows uploading accolades earned while playing offline to your account.
- In-game popup notifications upon unlocking accolades.

### Dialogue History
![alt text](image.png)
- Review previous conversations at any time during gameplay.

### In-Game Orchestral Soundtrack
- New in-game option to toggle between original soundtrack and orchestral arrangements throughout the story.

### Expanded Music Room
![alt text](image-2.png)
- New tracks added to the Gallery music player, including the album *"Gyakuten Meets Orchestra"*.

### Native 64-bit Multiplatform Support
- **Native Linux (64-bit)**: Native executable and libraries with Vulkan/OpenGL rendering, ideal for Linux desktops and **Steam Deck**.
- **Windows (64-bit and 32-bit)**: 64-bit runtimes for modern processors. The original 32-bit runtime is preserved for full compatibility.

### Self-Contained Universal Patcher (PWTrilogyPatcher)
- Avalonia UI graphical interface translated into the game's **10 languages** (Spanish, Italian, English, Português-BR, Français, Deutsch, 日本語, 한국어, 简体中文, 繁體中文).
- **Integrated Encrypted Payload**: The patcher contains the compressed data protected with AES-256 encryption, applying deltas instantly and safely.

---

## Installation Instructions

1. Head over to the **[Latest Releases](https://github.com/CTPache/PWTrilogy-xMod/releases/latest)** tab.
2. Download the installer for your operating system:
   - **Windows**: Download `AATrilogyPatcher.exe`.
   - **Linux / Steam Deck**: Download `AATrilogyPatcher-linux`.
3. Run the patcher:
   - On Linux or Steam Deck, make sure to grant it execution permissions before running it:
     ```bash
     chmod +x AATrilogyPatcher-linux
     ./AATrilogyPatcher-linux
     ```
4. The patcher will automatically detect your Steam installation path. If it doesn't, or if you use a custom path, enter the directory manually.
5. Select the appropriate target version (Windows 32-bit, Windows 64-bit, or Linux 64-bit) and click **"Patch"**.
6. Once finished, launch the game. If it boots in another language, switch it to your preferred one in the **Options** $\rightarrow$ **Language** menu.
   - On Linux, add this line to Steam launch options:
   ```
   sh -c 'exec ./PWAAT.x86_64' -- %command%
   ```

---

## In-Game Release Notes

Upon launching the game for the first time after applying the xMod, an update dialogue will automatically display release notes in your active language, summarizing all newly added features.

---

## Frequently Asked Questions & Troubleshooting

<details>
<summary><b>Does the patcher fail to write files or report a permissions error?</b></summary>
Make sure you extracted the executable into a folder with user write permissions (such as your Desktop or Home folder) and that the game is completely closed before starting the patching process.
</details>

<details>
<summary><b>Are my save files preserved?</b></summary>
Yes. The xMod preserves and expands the save slots (110 slots to accommodate all 11 languages), maintaining full compatibility with your previous save files while adding accolades persistence.
</details>

<details>
<summary><b>How do I install on Steam Deck?</b></summary>
Switch to <i>Desktop Mode</i> on your Steam Deck, download <code>AATrilogyPatcher-linux</code>, grant it execution permissions, and run it to patch your Steam installation. Once you return to <i>Gaming Mode</i>, all enhancements will be active.
</details>

---

## Credits & Acknowledgments

### PWTrilogy-xMod Development
- **Mod Development, Romhacking & Engineering:** [CTPache](https://github.com/CTPache)
- **Patcher Development (Avalonia / Mara):** [Worst Aqua Player](https://github.com/WorstAquaPlayer), [CTPache](https://github.com/CTPache), [legendaryX77](https://github.com/legendaryX77)
- **UI Design & Text Adjustments:** [JauCR](https://github.com/JauCR), [CTPache](https://github.com/CTPache)

### Translations
- Spanish: [Traducciones Kurain](https://github.com/Traducciones-Kurain/PWTrilogy-ESP/blob/master/README.md)
- Italian: [Dragon Punk Team](https://dragonpunkteam.altervista.org/phoenix-wright-ace-attorney-trilogy/)

### Special Thanks
- To [Darkmet98](https://github.com/Darkmet98) for the Mara patching library and tools.
- To **Shu Takumi** for bringing the *Ace Attorney* saga to life.
