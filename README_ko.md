# 역전재판 123 나루호도 셀렉션 - xMod

[English](README.md) | [Español](README_es.md) | [Italiano](README_it.md) | [Português (BR)](README_pt.md) | [Français](README_fr.md) | [Deutsch](README_de.md) | [日本語](README_ja.md) | **한국어** | [简体中文](README_zh_cn.md) | [繁體中文](README_zh_tw.md)

**PWTrilogy-xMod**는 *『역전재판 123 나루호도 셀렉션』(Phoenix Wright: Ace Attorney Trilogy)*을 **완전판(Definitive Edition)**으로 거듭나게 하기 위해 제작된 커뮤니티 주도 확장 및 콘텐츠 업데이트 모드입니다.

CAPCOM의 공식 지원 언어를 건드리지 않으면서 새로운 인터랙티브 공간, 편의성(QoL) 개선, 다이내믹 오케스트라 사운드트랙, Linux(Steam Deck) 및 Windows용 네이티브 64비트 지원, 그리고 다국어 공존 기능을 통합한 종합 모드입니다.

---

## 주요 기능

### 신규 공존 언어 지원
- **유럽 스페인어**: **Traducciones Kurain**이 현지화한 번역, 그래픽 UI 및 더빙 음성.
- **이탈리아어**: **Dragon Punk Team**이 개발한 완전 현지화 지원.

### 인터랙티브 훈장 갤러리 (Accolades Gallery)
![alt text](image-1.png)
- **갤러리** 메뉴에 3D 진열장과 등급별 프레임(브론즈, 실버, 골드 등)을 갖춘 새로운 인터랙티브 전시실이 추가되었습니다.
- **Steam 양방향 동기화**: Steam에서 달성한 업적을 자동으로 감지하고 동기화하며, 오프라인 플레이 중 획득한 훈장을 나중에 Steam 계정에 업로드할 수 있습니다.
- 훈장 달성 시 게임 내 팝업 알림이 표시됩니다.

### 대화 로그 (Dialogue History)
![alt text](image.png)
- 플레이 도중 언제든지 이전 대화를 다시 확인할 수 있습니다.

### 게임 내 오케스트라 사운드트랙
- 본편 진행 중 언제든 원곡 사운드트랙과 오케스트라 편곡 버전을 전환할 수 있는 새로운 인게임 옵션이 추가되었습니다.

### 확장된 음악 감상실
![alt text](image-2.png)
- *"Gyakuten Meets Orchestra"* 앨범을 비롯한 새로운 트랙들이 갤러리 음악 플레이어에 추가되었습니다.

### 네이티브 64비트 멀티플랫폼 지원
- **네이티브 Linux (64-bit)**: Vulkan/OpenGL 렌더링을 지원하는 네이티브 실행 파일 및 라이브러리로 Linux 데스크톱과 **Steam Deck**에 최적화되어 있습니다.
- **Windows (64-bit 및 32-bit)**: 최신 프로세서를 위한 64비트 런타임을 지원하며, 완벽한 호환성을 위해 기존 32비트 런타임도 함께 유지합니다.

### 독립 실행형 범용 패처 (PWTrilogyPatcher)
- 게임의 **10개 언어**(Español, Italiano, English, Português-BR, Français, Deutsch, 日本語, 한국어, 简体中文, 繁體中文)를 지원하는 Avalonia UI 기반 그래픽 인터페이스.
- **암호화된 페이로드 내장**: AES-256 암호화로 보호된 압축 패치 데이터를 자체 내장하여 델타 패치를 즉각적이고 안전하게 적용합니다.

---

## 설치 방법

1. **[최신 릴리스(Releases)](https://github.com/CTPache/PWTrilogy-xMod/releases/latest)** 탭으로 이동합니다.
2. 사용 중인 운영체제에 맞는 설치 파일을 다운로드합니다:
   - **Windows**: `AATrilogyPatcher.exe` 다운로드.
   - **Linux / Steam Deck**: `AATrilogyPatcher-linux` 다운로드.
3. 패처를 실행합니다:
   - Linux 또는 Steam Deck에서는 실행 전 반드시 실행 권한을 부여하세요:
     ```bash
     chmod +x AATrilogyPatcher-linux
     ./AATrilogyPatcher-linux
     ```
4. 패처가 Steam 설치 경로를 자동으로 감지합니다. 자동으로 감지되지 않거나 사용자 지정 경로를 사용하는 경우 디렉터리 경로를 직접 입력하세요.
5. 환경에 맞는 대상 버전(Windows 32-bit, Windows 64-bit 또는 Linux 64-bit)을 선택하고 **"패치 적용"** 버튼을 클릭합니다.
6. 완료되면 게임을 실행합니다. 다른 언어로 시작되는 경우 **옵션** $\rightarrow$ **언어** 메뉴에서 원하는 언어로 변경하세요.
   - Linux에서는 Steam 게임 시작 옵션에 다음 줄을 추가하세요:
   ```
   sh -c 'exec ./PWAAT.x86_64' -- %command%
   ```

---

## 게임 내 업데이트 노트

xMod 적용 후 게임을 처음 실행하면 현재 설정된 언어로 새로 추가된 모든 기능을 요약한 업데이트 노트 대화상자가 자동으로 표시됩니다.

---

## 자주 묻는 질문 및 문제 해결

<details>
<summary><b>패처가 파일 쓰기에 실패하거나 권한 오류를 표시합니다</b></summary>
실행 파일을 바탕화면이나 홈 폴더 등 쓰기 권한이 있는 폴더에 두었는지, 그리고 패치를 시작하기 전에 게임이 완전히 종료되어 있는지 확인하세요.
</details>

<details>
<summary><b>기존 저장 데이터가 유지되나요?</b></summary>
네. xMod는 기존 저장 데이터를 보존하며 전체 11개 언어 지원에 맞춰 저장 슬롯을 110개로 확장합니다. 이전 저장 파일과의 완벽한 호환성을 유지하면서 훈장 데이터 저장 기능도 함께 제공됩니다.
</details>

<details>
<summary><b>Steam Deck에는 어떻게 설치하나요?</b></summary>
Steam Deck에서 <i>데스크톱 모드(Desktop Mode)</i>로 전환한 뒤 <code>AATrilogyPatcher-linux</code>를 다운로드하여 실행 권한을 부여하고 실행해 Steam 설치 경로에 패치를 적용하세요. <i>게임 모드(Gaming Mode)</i>로 돌아오면 모든 개선 사항이 활성화됩니다.
</details>

---

## 크레딧 및 감사의 말

### PWTrilogy-xMod 개발
- **모드 개발, 롬해킹 및 엔지니어링:** [CTPache](https://github.com/CTPache)
- **패처 개발 (Avalonia / Mara):** [Worst Aqua Player](https://github.com/WorstAquaPlayer), [CTPache](https://github.com/CTPache), [legendaryX77](https://github.com/legendaryX77)
- **UI 디자인 및 텍스트 조정:** [JauCR](https://github.com/JauCR), [CTPache](https://github.com/CTPache)

### 번역
- 스페인어: [Traducciones Kurain](https://github.com/Traducciones-Kurain/PWTrilogy-ESP/blob/master/README.md)
- 이탈리아어: [Dragon Punk Team](https://dragonpunkteam.altervista.org/phoenix-wright-ace-attorney-trilogy/)

### 특별 감사
- Mara 패치 라이브러리와 도구를 제공해 주신 [Darkmet98](https://github.com/Darkmet98)님께 감사드립니다.
- *역전재판(Ace Attorney)* 시리즈를 탄생시킨 **타쿠미 슈(Shu Takumi)** 님께 감사드립니다.
