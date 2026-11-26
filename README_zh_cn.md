# 逆转裁判123：成步堂精选集 - xMod

[English](README.md) | [Español](README_es.md) | [Italiano](README_it.md) | [Português (BR)](README_pt.md) | [Français](README_fr.md) | [Deutsch](README_de.md) | [日本語](README_ja.md) | [한국어](README_ko.md) | **简体中文** | [繁體中文](README_zh_tw.md)

**PWTrilogy-xMod** 是一款由社区驱动的内容扩展与更新模组，旨在将《逆转裁判123：成步堂精选集》（*Phoenix Wright: Ace Attorney Trilogy*）打造为真正的**终极版**。

作为一款全方位的增强模组，它在保留 CAPCOM 官方所有原版语言的同时，新增了互动画廊展厅、多项体验优化（QoL）、动态管弦乐原声、针对 Linux（Steam Deck）与 Windows 的原生 64 位支持以及多语言共存机制。

---

## 主要特性

### 全新共存语言支持
- **西班牙语（欧洲）**：由 **Traducciones Kurain** 适配的文本翻译、图形界面及配音。
- **意大利语**：由 **Dragon Punk Team** 开发的完整本地化版本。

### 互动勋章陈列室（Accolades Gallery）
![alt text](image-1.png)
- **画廊**菜单新增互动展厅，提供 3D 陈列柜以及按等级划分的相框（铜、银、金等）。
- **Steam 双向同步**：自动检测并同步 Steam 上已解锁的成就，同时支持将离线游玩期间获得的勋章上传至您的 Steam 账号。
- 解锁勋章时在游戏内弹出提示通知。

### 对话历史记录
![alt text](image.png)
- 游玩过程中可随时回顾此前的对话内容。

### 游戏内管弦乐原声开关
- 在游戏中新增独立选项，可在剧情流程中随时切换原版配乐与管弦乐重编版配乐。

### 扩展音乐室
![alt text](image-2.png)
- 画廊音乐播放器新增多首曲目，包括专辑《*逆转裁判 meets 管弦乐（Gyakuten Meets Orchestra）*》。

### 原生 64 位多平台支持
- **原生 Linux（64 位）**：提供基于 Vulkan/OpenGL 渲染的原生可执行文件与运行库，非常适合 Linux 桌面及 **Steam Deck**。
- **Windows（64 位与 32 位）**：为现代处理器提供 64 位运行时支持，同时保留原版 32 位运行时以确保完全兼容。

### 自包含通用补丁安装器（PWTrilogyPatcher）
- 基于 Avalonia UI 的图形界面，完整支持游戏内 **10 种语言**（Español, Italiano, English, Português-BR, Français, Deutsch, 日本語, 한국어, 简体中文, 繁體中文）。
- **内置加密载荷**：安装器内嵌经过 AES-256 加密保护的压缩补丁数据，可即时、安全地应用差分补丁。

---

## 安装指南

1. 前往 **[最新发布页面（Releases）](https://github.com/CTPache/PWTrilogy-xMod/releases/latest)**。
2. 下载对应您操作系统的安装程序：
   - **Windows**：下载 `AATrilogyPatcher.exe`。
   - **Linux / Steam Deck**：下载 `AATrilogyPatcher-linux`。
3. 运行补丁安装器：
   - 在 Linux 或 Steam Deck 上运行前，请确保赋予其可执行权限：
     ```bash
     chmod +x AATrilogyPatcher-linux
     ./AATrilogyPatcher-linux
     ```
4. 安装程序会自动检测 Steam 游戏安装路径。如果未能识别或您使用了自定义安装路径，请手动输入目录路径。
5. 选择对应的目标版本（Windows 32-bit、Windows 64-bit 或 Linux 64-bit），然后点击 **“安装补丁”**。
6. 安装完成后即可启动游戏。若游戏以其他语言启动，可在 **选项** $\rightarrow$ **语言** 菜单中切换为您偏好的语言。
   - 在 Linux 系统中，请将以下启动参数添加到 Steam 游戏启动选项中：
   ```
   sh -c 'exec ./PWAAT.x86_64' -- %command%
   ```

---

## 游戏内更新说明

安装 xMod 后首次启动游戏时，系统会自动以您当前选择的语言弹出更新说明窗口，汇总所有新增内容与特性。

---

## 常见问题与故障排查

<details>
<summary><b>补丁程序写入文件失败或提示权限错误怎么办？</b></summary>
请确保已将可执行文件放在具有用户写入权限的文件夹中（例如桌面或主目录），并在开始安装补丁前完全关闭游戏。
</details>

<details>
<summary><b>我之前的游戏存档会保留吗？</b></summary>
会的。xMod 在保留原有存档的同时将存档槽位扩展至 110 个（以适配全部 11 种语言），与您原有的存档保持完全兼容，并增加了勋章进度持久化功能。
</details>

<details>
<summary><b>如何在 Steam Deck 上安装？</b></summary>
将 Steam Deck 切换至<i>桌面模式（Desktop Mode）</i>，下载 <code>AATrilogyPatcher-linux</code> 并赋予执行权限，运行后对您的 Steam 游戏目录安装补丁即可。切回<i>游戏模式（Gaming Mode）</i>后，所有增强内容便会生效。
</details>

---

## 制作人员与致谢

### PWTrilogy-xMod 开发团队
- **模组开发、Romhacking 与工程架构：** [CTPache](https://github.com/CTPache)
- **补丁安装器开发（Avalonia / Mara）：** [Worst Aqua Player](https://github.com/WorstAquaPlayer), [CTPache](https://github.com/CTPache), [legendaryX77](https://github.com/legendaryX77)
- **UI 设计与文本调整：** [JauCR](https://github.com/JauCR), [CTPache](https://github.com/CTPache)

### 本地化翻译
- 西班牙语：[Traducciones Kurain](https://github.com/Traducciones-Kurain/PWTrilogy-ESP/blob/master/README.md)
- 意大利语：[Dragon Punk Team](https://dragonpunkteam.altervista.org/phoenix-wright-ace-attorney-trilogy/)

### 特别鸣谢
- 感谢 [Darkmet98](https://github.com/Darkmet98) 提供的 Mara 补丁库及相关工具。
- 感谢 **巧舟（Shu Takumi）** 创作出《*逆转裁判*》系列。
