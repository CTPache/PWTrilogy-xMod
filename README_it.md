# Phoenix Wright: Ace Attorney Trilogy - xMod

[English](README.md) | [Español](README_es.md) | **Italiano** | [Português (BR)](README_pt.md) | [Français](README_fr.md) | [Deutsch](README_de.md) | [日本語](README_ja.md) | [한국어](README_ko.md) | [简体中文](README_zh_cn.md) | [繁體中文](README_zh_tw.md)

**PWTrilogy-xMod** è un'espansione e un aggiornamento dei contenuti creato dalla community, progettato per trasformare *Phoenix Wright: Ace Attorney Trilogy* nell'**edizione definitiva** del gioco.

Si tratta di una mod completa che arricchisce l'esperienza con nuove sale interattive, miglioramenti alla qualità della vita (QoL), colonna sonora orchestrale dinamica, supporto nativo a 64 bit per Linux (Steam Deck) e Windows, e coesistenza multilingua senza alterare le lingue ufficiali di CAPCOM.

---

## Caratteristiche principali

### Nuove lingue coesistenti
- **Spagnolo europeo**: Traduzione, interfaccia grafica e voci doppiate adattate da **Traducciones Kurain**.
- **Italiano**: Localizzazione completa sviluppata dal **Dragon Punk Team**.

### Galleria dei riconoscimenti interattiva (Accolades Gallery)
![alt text](image-1.png)
- Nuova sala interattiva nel menu **Galleria** con teche 3D e cornici suddivise per categoria (bronzo, argento e oro).
- **Sincronizzazione bidirezionale con Steam**: Rileva e sincronizza automaticamente gli obiettivi sbloccati su Steam e permette di caricare sul proprio account i riconoscimenti ottenuti giocando offline.
- Notifiche popup *in-game* al momento dello sblocco dei riconoscimenti.

### Cronologia dei dialoghi
![alt text](image.png)
- Rileggi le conversazioni precedenti in qualsiasi momento durante il gioco.

### Colonna sonora orchestrale in partita
- Nuova opzione nel gioco per alternare tra la colonna sonora originale e gli arrangiamenti orchestrali nel corso della storia.

### Sala della musica ampliata
![alt text](image-2.png)
- Nuovi brani aggiunti al lettore musicale della Galleria, incluso l'album *"Gyakuten Meets Orchestra"*.

### Supporto multipiattaforma nativo a 64 bit
- **Linux nativo (64-bit)**: Eseguibile e librerie native con rendering Vulkan/OpenGL, ideale per desktop Linux e **Steam Deck**.
- **Windows (64-bit e 32-bit)**: Runtime a 64 bit per i processori moderni. Il runtime originale a 32 bit viene mantenuto per garantire la massima compatibilità.

### Patcher universale autonomo (PWTrilogyPatcher)
- Interfaccia grafica in Avalonia UI tradotta nelle **10 lingue** del gioco (Español, Italiano, English, Português-BR, Français, Deutsch, 日本語, 한국어, 简体中文, 繁體中文).
- **Payload cifrato integrato**: Il patcher contiene i dati compressi protetti con cifratura AES-256, applicando i delta in modo immediato e sicuro.

---

## Istruzioni per l'installazione

1. Vai alla scheda **[Ultime versioni (Releases)](https://github.com/CTPache/PWTrilogy-xMod/releases/latest)**.
2. Scarica il programma di installazione adatto al tuo sistema operativo:
   - **Windows**: Scarica `AATrilogyPatcher.exe`.
   - **Linux / Steam Deck**: Scarica `AATrilogyPatcher-linux`.
3. Avvia il patcher:
   - Su Linux o Steam Deck, assicurati di concedergli i permessi di esecuzione prima di avviarlo:
     ```bash
     chmod +x AATrilogyPatcher-linux
     ./AATrilogyPatcher-linux
     ```
4. Il patcher rileverà automaticamente il percorso di installazione di Steam. Se non dovesse rilevarlo o se usi un percorso personalizzato, inserisci manualmente la cartella.
5. Seleziona la versione di destinazione appropriata (Windows 32-bit, Windows 64-bit o Linux 64-bit) e premi **"Applica Patch"**.
6. Al termine, avvia il gioco. Se si avvia in un'altra lingua, impostala secondo le tue preferenze dal menu **Opzioni** $\rightarrow$ **Lingua**.
   - Su Linux, aggiungi questa riga alle opzioni di avvio di Steam:
   ```
   sh -c 'exec ./PWAAT.x86_64' -- %command%
   ```

---

## Note di aggiornamento in gioco

Al primo avvio del gioco dopo l'applicazione della xMod, verrà mostrato automaticamente un riquadro con le note di aggiornamento nella lingua attiva, riassumendo tutte le novità introdotte.

---

## Domande frequenti e risoluzione dei problemi

<details>
<summary><b>Il patcher non riesce a scrivere i file o segnala un errore di permessi?</b></summary>
Assicurati di aver estratto l'eseguibile in una cartella con permessi di scrittura dell'utente (come il Desktop o la cartella Home) e che il gioco sia completamente chiuso prima di avviare l'applicazione della patch.
</details>

<details>
<summary><b>I miei salvataggi vengono conservati?</b></summary>
Sì. La xMod preserva ed espande gli slot di salvataggio (110 slot per ospitare tutte le 11 lingue), mantenendo la piena compatibilità con i tuoi salvataggi precedenti e aggiungendo la persistenza dei riconoscimenti.
</details>

<details>
<summary><b>Come si installa su Steam Deck?</b></summary>
Passa alla <i>Modalità Desktop</i> su Steam Deck, scarica <code>AATrilogyPatcher-linux</code>, assegnagli i permessi di esecuzione e avvialo per applicare la patch alla tua installazione Steam. Tornando alla <i>Modalità Gioco (Gaming Mode)</i>, tutte le novità saranno attive.
</details>

---

## Crediti e ringraziamenti

### Sviluppo di PWTrilogy-xMod
- **Sviluppo della mod, Romhacking e Ingegneria:** [CTPache](https://github.com/CTPache)
- **Sviluppo del Patcher (Avalonia / Mara):** [Worst Aqua Player](https://github.com/WorstAquaPlayer), [CTPache](https://github.com/CTPache), [legendaryX77](https://github.com/legendaryX77)
- **Design dell'interfaccia e adattamento testi:** [JauCR](https://github.com/JauCR), [CTPache](https://github.com/CTPache)

### Traduzioni
- Spagnolo: [Traducciones Kurain](https://github.com/Traducciones-Kurain/PWTrilogy-ESP/blob/master/README.md)
- Italiano: [Dragon Punk Team](https://dragonpunkteam.altervista.org/phoenix-wright-ace-attorney-trilogy/)

### Ringraziamenti speciali
- A [Darkmet98](https://github.com/Darkmet98) per la libreria e gli strumenti di patching Mara.
- A **Shu Takumi** per aver dato vita alla saga di *Ace Attorney*.
