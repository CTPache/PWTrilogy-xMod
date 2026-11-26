# 逆転裁判123 成歩堂セレクション - xMod

[English](README.md) | [Español](README_es.md) | [Italiano](README_it.md) | [Português (BR)](README_pt.md) | [Français](README_fr.md) | [Deutsch](README_de.md) | **日本語** | [한국어](README_ko.md) | [简体中文](README_zh_cn.md) | [繁體中文](README_zh_tw.md)

**PWTrilogy-xMod** は、『逆転裁判123 成歩堂セレクション（Phoenix Wright: Ace Attorney Trilogy）』を**決定版**へと進化させるために制作された、コミュニティ主導の拡張およびコンテンツアップデート MOD です。

カプコン公式の収録言語を変更することなく、新しいインタラクティブルーム、QoL（快適性）向上機能、ゲーム内オーケストラサウンドトラック、Linux（Steam Deck）および Windows 向けのネイティブ 64 ビット対応、そして多言語の共存を実現する包括的な MOD となっています。

---

## 主な特徴

### 新たに共存可能な追加言語
- **スペイン語（欧州）**：**Traducciones Kurain** による翻訳、グラフィック UI、および吹き替えボイスの実装。
- **イタリア語**：**Dragon Punk Team** によって開発された完全ローカライズ。

### インタラクティブ勲章ギャラリー（Accolades Gallery）
![alt text](image-1.png)
- **ギャラリー**メニューに追加された新しいインタラクティブルーム。3D のショーケースとグレード別フレーム（ブロンズ、シルバー、ゴールドなど）を備えています。
- **Steam 双方向同期**：Steam で解除した実績を自動で検出・同期するほか、オフラインプレイ中に獲得した勲章を後から Steam アカウントへアップロードすることも可能です。
- 勲章解除時にゲーム内でポップアップ通知を表示します。

### 会話ログ（ダイアログ履歴）
![alt text](image.png)
- ゲームプレイ中、いつでも過去の会話をさかのぼって確認できます。

### ゲーム内オーケストラサウンドトラック
- 本編のプレイ中に、オリジナル音源とオーケストラアレンジ楽曲をいつでも切り替えられる新しいオプションを追加しました。

### 拡張された音楽室（ミュージックプレイヤー）
![alt text](image-2.png)
- アルバム『*逆転裁判 meets オーケストラ（Gyakuten Meets Orchestra）*』をはじめとする追加楽曲をギャラリーの音楽プレイヤーに収録しました。

### マルチプラットフォーム・ネイティブ 64 ビット対応
- **ネイティブ Linux（64-bit）**：Vulkan/OpenGL 描画に対応したネイティブ実行ファイルとライブラリにより、Linux デスクトップ環境や **Steam Deck** で快適に動作します。
- **Windows（64-bit / 32-bit）**：最新 CPU 向けの 64 ビットランタイムに対応しつつ、互換性確保のためオリジナルの 32 ビットランタイムも保持しています。

### オールインワン汎用パッチャー（PWTrilogyPatcher）
- ゲーム対応の **10 言語**（Español, Italiano, English, Português-BR, Français, Deutsch, 日本語, 한국어, 简体中文, 繁體中文）に翻訳された Avalonia UI ベースの GUI を搭載。
- **暗号化ペイロード統合**：AES-256 で保護された圧縮パッチデータを本体に内蔵しており、差分（デルタ）を即座かつ安全に適用できます。

---

## インストール手順

1. **[最新リリース（Releases）](https://github.com/CTPache/PWTrilogy-xMod/releases/latest)** ページへアクセスします。
2. お使いの OS に対応したインストーラーをダウンロードします：
   - **Windows**：`AATrilogyPatcher.exe` をダウンロード。
   - **Linux / Steam Deck**：`AATrilogyPatcher-linux` をダウンロード。
3. パッチャーを起動します：
   - Linux や Steam Deck では、実行前に実行権限を付与してください：
     ```bash
     chmod +x AATrilogyPatcher-linux
     ./AATrilogyPatcher-linux
     ```
4. パッチャーが Steam のインストールパスを自動検出します。自動検出されない場合やカスタムフォルダにインストールしている場合は、ディレクトリを手動で入力してください。
5. 適切なターゲットバージョン（Windows 32-bit、Windows 64-bit、または Linux 64-bit）を選択し、**「パッチ適用」** をクリックします。
6. 完了後、ゲームを起動します。別の言語で起動した場合は、**オプション** $\rightarrow$ **言語** メニューから希望の言語へ切り替えてください。
   - Linux 環境では、Steam の起動オプションに以下の行を追加してください：
   ```
   sh -c 'exec ./PWAAT.x86_64' -- %command%
   ```

---

## ゲーム内アップデートノート

xMod 適用後の初回起動時に、追加されたすべての新機能をまとめたアップデートノートダイアログが、現在の言語設定で自動的に表示されます。

---

## よくある質問とトラブルシューティング

<details>
<summary><b>パッチャーがファイルの書き込みに失敗する、または権限エラーが出ます</b></summary>
実行ファイルをデスクトップやホームディレクトリなど書き込み権限のあるフォルダへ展開していること、およびパッチ処理を開始する前にゲームが完全に終了していることを確認してください。
</details>

<details>
<summary><b>既存のセーブデータは保持されますか？</b></summary>
はい。xMod は全 11 言語に対応するためセーブスロットを 110 スロットへ拡張しつつ既存データを保護しており、これまでのセーブデータとの完全な互換性を保ったまま勲章の永続化機能を追加します。
</details>

<details>
<summary><b>Steam Deck にはどのようにインストールしますか？</b></summary>
Steam Deck を<i>デスクトップモード</i>に切り替え、<code>AATrilogyPatcher-linux</code> をダウンロードして実行権限を付与し、Steam のインストール先に対してパッチを適用してください。<i>ゲームモード</i>に戻ると、すべての拡張機能が有効になります。
</details>

---

## クレジットと謝辞

### PWTrilogy-xMod 開発
- **MOD 開発・Romhacking・エンジニアリング：** [CTPache](https://github.com/CTPache)
- **パッチャー開発（Avalonia / Mara）：** [Worst Aqua Player](https://github.com/WorstAquaPlayer), [CTPache](https://github.com/CTPache), [legendaryX77](https://github.com/legendaryX77)
- **UI デザイン・テキスト調整：** [JauCR](https://github.com/JauCR), [CTPache](https://github.com/CTPache)

### 翻訳
- スペイン語：[Traducciones Kurain](https://github.com/Traducciones-Kurain/PWTrilogy-ESP/blob/master/README.md)
- イタリア語：[Dragon Punk Team](https://dragonpunkteam.altervista.org/phoenix-wright-ace-attorney-trilogy/)

### スペシャルサンクス
- パッチ用ライブラリ「Mara」および関連ツールを提供してくださった [Darkmet98](https://github.com/Darkmet98) 氏に感謝いたします。
- *『逆転裁判』* シリーズを生み出してくださった **巧舟（Shu Takumi）** 氏に深く感謝いたします。
