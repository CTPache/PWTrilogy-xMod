# 逆轉裁判123：成步堂精選集 - xMod

[English](README.md) | [Español](README_es.md) | [Italiano](README_it.md) | [Português (BR)](README_pt.md) | [Français](README_fr.md) | [Deutsch](README_de.md) | [日本語](README_ja.md) | [한국어](README_ko.md) | [简体中文](README_zh_cn.md) | **繁體中文**

**PWTrilogy-xMod** 是一款由社群驅動的擴充與內容更新模組，旨在將《逆轉裁判123：成步堂精選集》（*Phoenix Wright: Ace Attorney Trilogy*）打造成真正的**終極版**。

作為一款全方位的強化模組，它在保留 CAPCOM 官方所有原版語言的同時，新增了互動藝廊展廳、多項體驗優化（QoL）、動態管弦樂原聲、針對 Linux（Steam Deck）與 Windows 的原生 64 位元支援以及多語言共存機制。

---

## 主要特色

### 全新共存語言支援
- **西班牙語（歐洲）**：由 **Traducciones Kurain** 適配的文本翻譯、圖形介面及配音。
- **義大利語**：由 **Dragon Punk Team** 開發的完整在地化版本。

### 互動勳章陳列室（Accolades Gallery）
![alt text](image-1.png)
- **藝廊**選單新增互動展廳，提供 3D 陳列櫃以及依等級劃分的相框（銅、銀、金等）。
- **Steam 雙向同步**：自動偵測並同步 Steam 上已解鎖的成就，同時支援將離線遊玩期間獲得的勳章上傳至您的 Steam 帳號。
- 解鎖勳章時於遊戲內彈出提示通知。

### 對話歷史紀錄
![alt text](image.png)
- 遊玩過程中可隨時回顧先前的對話內容。

### 遊戲內管弦樂原聲切換
- 在遊戲中新增獨立選項，可在劇情推進期間隨時切換原版配樂與管弦樂重編版配樂。

### 擴充音樂室
![alt text](image-2.png)
- 藝廊音樂播放器新增多首曲目，包含專輯《*逆轉裁判 meets 管弦樂（Gyakuten Meets Orchestra）*》。

### 原生 64 位元多平台支援
- **原生 Linux（64 位元）**：提供基於 Vulkan/OpenGL 渲染的原生執行檔與執行時期函式庫，非常適合 Linux 桌面與 **Steam Deck**。
- **Windows（64 位元與 32 位元）**：為現代處理器提供 64 位元執行環境，同時保留原版 32 位元執行環境以確保完整相容性。

### 自包含通用補丁安裝程式（PWTrilogyPatcher）
- 基於 Avalonia UI 的圖形介面，完整支援遊戲內 **10 種語言**（Español, Italiano, English, Português-BR, Français, Deutsch, 日本語, 한국어, 简体中文, 繁體中文）。
- **內建加密載荷**：安裝程式內嵌經 AES-256 加密保護的壓縮補丁資料，可即時且安全地套用差分補丁。

---

## 安裝指南

1. 前往 **[最新釋出頁面（Releases）](https://github.com/CTPache/PWTrilogy-xMod/releases/latest)**。
2. 下載對應您作業系統的安裝程式：
   - **Windows**：下載 `AATrilogyPatcher.exe`。
   - **Linux / Steam Deck**：下載 `AATrilogyPatcher-linux`。
3. 執行補丁安裝程式：
   - 在 Linux 或 Steam Deck 上執行前，請先確認已賦予執行權限：
     ```bash
     chmod +x AATrilogyPatcher-linux
     ./AATrilogyPatcher-linux
     ```
4. 安裝程式會自動偵測 Steam 遊戲安裝路徑。若未能偵測或您使用自訂路徑，請手動輸入目錄位置。
5. 選擇對應的目標版本（Windows 32-bit、Windows 64-bit 或 Linux 64-bit），然後點擊 **「安裝補丁」**。
6. 完成後即可啟動遊戲。若遊戲以其他語言啟動，請前往 **選項** $\rightarrow$ **語言** 選單切換為您偏好的語言。
   - 在 Linux 系統中，請將下列啟動參數新增至 Steam 遊戲啟動選項：
   ```
   sh -c 'exec ./PWAAT.x86_64' -- %command%
   ```

---

## 遊戲內更新說明

安裝 xMod 後首次啟動遊戲時，系統會自動以您目前的語言顯示更新說明對話框，摘要列出所有新增功能與項目。

---

## 常見問題與疑難排解

<details>
<summary><b>補丁程式寫入檔案失敗或回報權限錯誤？</b></summary>
請確認您已將執行檔置於具備使用者寫入權限的資料夾中（例如桌面或個人主目錄），並在開始套用補丁前完全關閉遊戲。
</details>

<details>
<summary><b>我原有的遊戲存檔會保留嗎？</b></summary>
會的。xMod 會保留並將存檔欄位擴充至 110 個（以容納全部 11 種語言），在維持與先前存檔完全相容的同時，加入勳章進度的永續儲存功能。
</details>

<details>
<summary><b>如何在 Steam Deck 上安裝？</b></summary>
將 Steam Deck 切換至<i>桌面模式（Desktop Mode）</i>，下載 <code>AATrilogyPatcher-linux</code> 並賦予執行權限，執行後對您的 Steam 安裝目錄套用補丁即可。切回<i>遊戲模式（Gaming Mode）</i>後，所有強化功能即會生效。
</details>

---

## 製作人員與致謝

### PWTrilogy-xMod 開發團隊
- **模組開發、Romhacking 與工程架構：** [CTPache](https://github.com/CTPache)
- **補丁安裝程式開發（Avalonia / Mara）：** [Worst Aqua Player](https://github.com/WorstAquaPlayer), [CTPache](https://github.com/CTPache), [legendaryX77](https://github.com/legendaryX77)
- **UI 設計與文本調整：** [JauCR](https://github.com/JauCR), [CTPache](https://github.com/CTPache)

### 在地化翻譯
- 西班牙語：[Traducciones Kurain](https://github.com/Traducciones-Kurain/PWTrilogy-ESP/blob/master/README.md)
- 義大利語：[Dragon Punk Team](https://dragonpunkteam.altervista.org/phoenix-wright-ace-attorney-trilogy/)

### 特別鳴謝
- 感謝 [Darkmet98](https://github.com/Darkmet98) 提供的 Mara 補丁函式庫與相關工具。
- 感謝 **巧舟（Shu Takumi）** 創作出《*逆轉裁判*》系列。
