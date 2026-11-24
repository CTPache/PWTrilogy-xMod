using System;
using System.Collections.Generic;
using System.Globalization;

namespace PWTrilogyPatcher.Services;

public enum AppLanguage
{
    Spanish = 0,
    Italian = 1,
    English = 2,
    PortugueseBrazil = 3,
    French = 4,
    German = 5,
    Japanese = 6,
    Korean = 7,
    ChineseSimplified = 8,
    ChineseTraditional = 9
}

public class LocalizationService
{
    private static LocalizationService? _instance;
    public static LocalizationService Instance => _instance ??= new LocalizationService();

    public event Action? LanguageChanged;

    private AppLanguage _currentLanguage = AppLanguage.English;
    public AppLanguage CurrentLanguage
    {
        get => _currentLanguage;
        set
        {
            if (_currentLanguage != value)
            {
                _currentLanguage = value;
                LanguageChanged?.Invoke();
            }
        }
    }

    public static readonly string[] LanguageDisplayNames = new string[]
    {
        "Español",
        "Italiano",
        "English",
        "Português (Brasil)",
        "Français",
        "Deutsch",
        "日本語",
        "한국어",
        "简体中文",
        "繁體中文"
    };

    public LocalizationService()
    {
        _currentLanguage = DetectDefaultLanguage();
    }

    private static AppLanguage DetectDefaultLanguage()
    {
        try
        {
            string culture = CultureInfo.CurrentUICulture.Name;
            if (string.IsNullOrWhiteSpace(culture))
            {
                culture = CultureInfo.CurrentCulture.Name;
            }

            if (string.IsNullOrWhiteSpace(culture) || culture.Equals("invariant", StringComparison.OrdinalIgnoreCase))
            {
                string? env = Environment.GetEnvironmentVariable("LC_ALL")
                           ?? Environment.GetEnvironmentVariable("LC_MESSAGES")
                           ?? Environment.GetEnvironmentVariable("LANG");
                if (!string.IsNullOrWhiteSpace(env))
                {
                    culture = env;
                }
            }

            culture = (culture ?? string.Empty).ToLowerInvariant();

            if (culture.StartsWith("es")) return AppLanguage.Spanish;
            if (culture.StartsWith("it")) return AppLanguage.Italian;
            if (culture.StartsWith("pt")) return AppLanguage.PortugueseBrazil;
            if (culture.StartsWith("fr")) return AppLanguage.French;
            if (culture.StartsWith("de")) return AppLanguage.German;
            if (culture.StartsWith("ja")) return AppLanguage.Japanese;
            if (culture.StartsWith("ko")) return AppLanguage.Korean;
            if (culture.Contains("zh-hans") || culture.StartsWith("zh-cn") || culture.StartsWith("zh-sg")) return AppLanguage.ChineseSimplified;
            if (culture.Contains("zh-hant") || culture.StartsWith("zh-tw") || culture.StartsWith("zh-hk") || culture.StartsWith("zh-mo")) return AppLanguage.ChineseTraditional;
            if (culture.StartsWith("zh")) return AppLanguage.ChineseSimplified;
            if (culture.StartsWith("en")) return AppLanguage.English;
        }
        catch
        {
            // Fallback to English
        }
        return AppLanguage.English;
    }

    public string WindowTitle => CurrentLanguage switch
    {
        AppLanguage.Spanish => "Parcheador de Phoenix Wright: Ace Attorney Trilogy",
        AppLanguage.Italian => "Patcher di Phoenix Wright: Ace Attorney Trilogy",
        AppLanguage.English => "Phoenix Wright: Ace Attorney Trilogy Patcher",
        AppLanguage.PortugueseBrazil => "Instalador de Patch de Phoenix Wright: Ace Attorney Trilogy",
        AppLanguage.French => "Patch pour Phoenix Wright: Ace Attorney Trilogy",
        AppLanguage.German => "Patcher für Phoenix Wright: Ace Attorney Trilogy",
        AppLanguage.Japanese => "『逆転裁判123 成歩堂セレクション』パッチャー",
        AppLanguage.Korean => "『역전재판 123 나루호도 셀렉션』 패처",
        AppLanguage.ChineseSimplified => "《逆转裁判123：成步堂精选集》补丁安装程序",
        AppLanguage.ChineseTraditional => "《逆轉裁判123：成步堂精選集》補丁安裝程式",
        _ => "Phoenix Wright: Ace Attorney Trilogy Patcher"
    };

    public string BtnPatch => CurrentLanguage switch
    {
        AppLanguage.Spanish => "Parchear",
        AppLanguage.Italian => "Applica Patch",
        AppLanguage.English => "Patch",
        AppLanguage.PortugueseBrazil => "Instalar Patch",
        AppLanguage.French => "Patcher",
        AppLanguage.German => "Patchen",
        AppLanguage.Japanese => "パッチ適用",
        AppLanguage.Korean => "패치 적용",
        AppLanguage.ChineseSimplified => "安装补丁",
        AppLanguage.ChineseTraditional => "安裝補丁",
        _ => "Patch"
    };

    public string BtnCredits => CurrentLanguage switch
    {
        AppLanguage.Spanish => "Créditos",
        AppLanguage.Italian => "Crediti",
        AppLanguage.English => "Credits",
        AppLanguage.PortugueseBrazil => "Créditos",
        AppLanguage.French => "Crédits",
        AppLanguage.German => "Credits",
        AppLanguage.Japanese => "クレジット",
        AppLanguage.Korean => "크레딧",
        AppLanguage.ChineseSimplified => "制作人员",
        AppLanguage.ChineseTraditional => "製作人員",
        _ => "Credits"
    };

    public string BtnExit => CurrentLanguage switch
    {
        AppLanguage.Spanish => "Salir",
        AppLanguage.Italian => "Esci",
        AppLanguage.English => "Exit",
        AppLanguage.PortugueseBrazil => "Sair",
        AppLanguage.French => "Quitter",
        AppLanguage.German => "Beenden",
        AppLanguage.Japanese => "終了",
        AppLanguage.Korean => "종료",
        AppLanguage.ChineseSimplified => "退出",
        AppLanguage.ChineseTraditional => "結束",
        _ => "Exit"
    };

    public string BtnBack => CurrentLanguage switch
    {
        AppLanguage.Spanish => "Volver",
        AppLanguage.Italian => "Indietro",
        AppLanguage.English => "Back",
        AppLanguage.PortugueseBrazil => "Voltar",
        AppLanguage.French => "Retour",
        AppLanguage.German => "Zurück",
        AppLanguage.Japanese => "戻る",
        AppLanguage.Korean => "돌아가기",
        AppLanguage.ChineseSimplified => "返回",
        AppLanguage.ChineseTraditional => "返回",
        _ => "Back"
    };

    public string HeaderSelectPath => CurrentLanguage switch
    {
        AppLanguage.Spanish => "Elige la ruta de juego:",
        AppLanguage.Italian => "Scegli il percorso del gioco:",
        AppLanguage.English => "Select the game path:",
        AppLanguage.PortugueseBrazil => "Escolha o caminho do jogo:",
        AppLanguage.French => "Choisissez le dossier du jeu :",
        AppLanguage.German => "Wähle den Spielpfad:",
        AppLanguage.Japanese => "ゲームのフォルダを選択してください：",
        AppLanguage.Korean => "게임 설치 경로를 선택하세요:",
        AppLanguage.ChineseSimplified => "选择游戏安装路径：",
        AppLanguage.ChineseTraditional => "選擇遊戲安裝路徑：",
        _ => "Select the game path:"
    };

    public string PathWatermark => CurrentLanguage switch
    {
        AppLanguage.Spanish => "Introduce la ruta del juego aquí",
        AppLanguage.Italian => "Inserisci qui il percorso del gioco",
        AppLanguage.English => "Enter game path here",
        AppLanguage.PortugueseBrazil => "Insira o caminho do jogo aqui",
        AppLanguage.French => "Entrez le chemin du jeu ici",
        AppLanguage.German => "Hier Spielpfad eingeben",
        AppLanguage.Japanese => "ここにゲームのパスを入力",
        AppLanguage.Korean => "여기에 게임 경로를 입력하세요",
        AppLanguage.ChineseSimplified => "在此输入游戏路径",
        AppLanguage.ChineseTraditional => "在此輸入遊戲路徑",
        _ => "Enter game path here"
    };

    public string VersionLabel => CurrentLanguage switch
    {
        AppLanguage.Spanish => "Versión:",
        AppLanguage.Italian => "Versione:",
        AppLanguage.English => "Version:",
        AppLanguage.PortugueseBrazil => "Versão:",
        AppLanguage.French => "Version :",
        AppLanguage.German => "Version:",
        AppLanguage.Japanese => "バージョン：",
        AppLanguage.Korean => "버전:",
        AppLanguage.ChineseSimplified => "版本：",
        AppLanguage.ChineseTraditional => "版本：",
        _ => "Version:"
    };

    public string[] TargetVersions => CurrentLanguage switch
    {
        AppLanguage.Spanish => new[] { "Windows 32-bit (Vanilla / Proton)", "Windows 64-bit", "Linux 64-bit (Nativo)" },
        AppLanguage.Italian => new[] { "Windows 32-bit (Vanilla / Proton)", "Windows 64-bit", "Linux 64-bit (Nativo)" },
        AppLanguage.English => new[] { "Windows 32-bit (Vanilla / Proton)", "Windows 64-bit", "Linux 64-bit (Native)" },
        AppLanguage.PortugueseBrazil => new[] { "Windows 32-bit (Vanilla / Proton)", "Windows 64-bit", "Linux 64-bit (Nativo)" },
        AppLanguage.French => new[] { "Windows 32-bit (Vanilla / Proton)", "Windows 64-bit", "Linux 64-bit (Natif)" },
        AppLanguage.German => new[] { "Windows 32-bit (Vanilla / Proton)", "Windows 64-bit", "Linux 64-bit (Nativ)" },
        AppLanguage.Japanese => new[] { "Windows 32ビット (バニラ / Proton)", "Windows 64ビット", "Linux 64ビット (ネイティブ)" },
        AppLanguage.Korean => new[] { "Windows 32비트 (바닐라 / Proton)", "Windows 64비트", "Linux 64비트 (네이티브)" },
        AppLanguage.ChineseSimplified => new[] { "Windows 32位 (原版 / Proton)", "Windows 64位", "Linux 64位 (原生)" },
        AppLanguage.ChineseTraditional => new[] { "Windows 32位元 (原版 / Proton)", "Windows 64位元", "Linux 64位元 (原生)" },
        _ => new[] { "Windows 32-bit (Vanilla / Proton)", "Windows 64-bit", "Linux 64-bit (Native)" }
    };

    public string StatusNoFolder => CurrentLanguage switch
    {
        AppLanguage.Spanish => "Introduce la ruta de juego.",
        AppLanguage.Italian => "Inserisci il percorso del gioco.",
        AppLanguage.English => "Enter the game path.",
        AppLanguage.PortugueseBrazil => "Insira o caminho do jogo.",
        AppLanguage.French => "Entrez le chemin du jeu.",
        AppLanguage.German => "Gib den Spielpfad ein.",
        AppLanguage.Japanese => "ゲームのパスを入力してください。",
        AppLanguage.Korean => "게임 경로를 입력하세요.",
        AppLanguage.ChineseSimplified => "请输入游戏路径。",
        AppLanguage.ChineseTraditional => "請輸入遊戲路徑。",
        _ => "Enter the game path."
    };

    public string StatusInvalidFolder => CurrentLanguage switch
    {
        AppLanguage.Spanish => "Ruta de juego inválida",
        AppLanguage.Italian => "Percorso del gioco non valido",
        AppLanguage.English => "Invalid game path",
        AppLanguage.PortugueseBrazil => "Caminho do jogo inválido",
        AppLanguage.French => "Chemin du jeu invalide",
        AppLanguage.German => "Ungültiger Spielpfad",
        AppLanguage.Japanese => "無効なゲームパスです",
        AppLanguage.Korean => "유효하지 않은 게임 경로입니다",
        AppLanguage.ChineseSimplified => "游戏路径无效",
        AppLanguage.ChineseTraditional => "遊戲路徑無效",
        _ => "Invalid game path"
    };

    public string StatusDetectedFolder => CurrentLanguage switch
    {
        AppLanguage.Spanish => "Ruta de juego detectada.",
        AppLanguage.Italian => "Percorso del gioco rilevato.",
        AppLanguage.English => "Game path detected.",
        AppLanguage.PortugueseBrazil => "Caminho do jogo detectado.",
        AppLanguage.French => "Chemin du jeu détecté.",
        AppLanguage.German => "Spielpfad erkannt.",
        AppLanguage.Japanese => "ゲームパスが検出されました。",
        AppLanguage.Korean => "게임 경로가 감지되었습니다.",
        AppLanguage.ChineseSimplified => "已检测到游戏路径。",
        AppLanguage.ChineseTraditional => "已檢測到遊戲路徑。",
        _ => "Game path detected."
    };

    public string GetStatusPlatformDetected(string platform) => CurrentLanguage switch
    {
        AppLanguage.Spanish => $"Plataforma detectada: {platform}",
        AppLanguage.Italian => $"Piattaforma rilevata: {platform}",
        AppLanguage.English => $"Platform detected: {platform}",
        AppLanguage.PortugueseBrazil => $"Plataforma detectada: {platform}",
        AppLanguage.French => $"Plateforme détectée : {platform}",
        AppLanguage.German => $"Erkannte Plattform: {platform}",
        AppLanguage.Japanese => $"検出されたプラットフォーム： {platform}",
        AppLanguage.Korean => $"감지된 플랫폼: {platform}",
        AppLanguage.ChineseSimplified => $"检测到的平台：{platform}",
        AppLanguage.ChineseTraditional => $"檢測到的平台：{platform}",
        _ => $"Platform detected: {platform}"
    };

    public string StatusReadyToPatch => CurrentLanguage switch
    {
        AppLanguage.Spanish => "Listo para aplicar.",
        AppLanguage.Italian => "Pronto per l'applicazione.",
        AppLanguage.English => "Ready to patch.",
        AppLanguage.PortugueseBrazil => "Pronto para aplicar.",
        AppLanguage.French => "Prêt à patcher.",
        AppLanguage.German => "Bereit zum Patchen.",
        AppLanguage.Japanese => "パッチ適用の準備が整いました。",
        AppLanguage.Korean => "패치 적용 준비 완료.",
        AppLanguage.ChineseSimplified => "已准备好应用补丁。",
        AppLanguage.ChineseTraditional => "已準備好套用補丁。",
        _ => "Ready to patch."
    };

    public string StatusDownloading => CurrentLanguage switch
    {
        AppLanguage.Spanish => "Descargando el parche...",
        AppLanguage.Italian => "Download della patch...",
        AppLanguage.English => "Downloading patch...",
        AppLanguage.PortugueseBrazil => "Baixando o patch...",
        AppLanguage.French => "Téléchargement du patch...",
        AppLanguage.German => "Patch wird heruntergeladen...",
        AppLanguage.Japanese => "パッチをダウンロード中...",
        AppLanguage.Korean => "패치 다운로드 중...",
        AppLanguage.ChineseSimplified => "正在下载补丁...",
        AppLanguage.ChineseTraditional => "正在下載補丁...",
        _ => "Downloading patch..."
    };

    public string GetDownloadingProgressStatus(string progress, string total) => CurrentLanguage switch
    {
        AppLanguage.Spanish => $"Descargando el parche... ({progress} de {total} MB)",
        AppLanguage.Italian => $"Download della patch... ({progress} di {total} MB)",
        AppLanguage.English => $"Downloading patch... ({progress} of {total} MB)",
        AppLanguage.PortugueseBrazil => $"Baixando o patch... ({progress} de {total} MB)",
        AppLanguage.French => $"Téléchargement du patch... ({progress} sur {total} Mo)",
        AppLanguage.German => $"Patch wird heruntergeladen... ({progress} von {total} MB)",
        AppLanguage.Japanese => $"パッチをダウンロード中... ({progress} / {total} MB)",
        AppLanguage.Korean => $"패치 다운로드 중... ({progress} / {total} MB)",
        AppLanguage.ChineseSimplified => $"正在下载补丁... ({progress} / {total} MB)",
        AppLanguage.ChineseTraditional => $"正在下載補丁... ({progress} / {total} MB)",
        _ => $"Downloading patch... ({progress} of {total} MB)"
    };

    public string StatusValidatingAndDecrypting => CurrentLanguage switch
    {
        AppLanguage.Spanish => "Validando ejecutable original y descifrando parche...",
        AppLanguage.Italian => "Convalida dell'eseguibile originale e decifratura della patch...",
        AppLanguage.English => "Validating original executable and decrypting patch...",
        AppLanguage.PortugueseBrazil => "Validando executável original e descriptografando o patch...",
        AppLanguage.French => "Validation de l'exécutable original et déchiffrement du patch...",
        AppLanguage.German => "Original-Spieldatei wird validiert und Patch entschlüsselt...",
        AppLanguage.Japanese => "オリジナル実行ファイルを検証し、パッチを復号中...",
        AppLanguage.Korean => "원본 실행 파일 검증 및 패치 복호화 중...",
        AppLanguage.ChineseSimplified => "正在验证原版可执行文件并解密补丁...",
        AppLanguage.ChineseTraditional => "正在驗證原版執行檔並解密補丁...",
        _ => "Validating original executable and decrypting patch..."
    };

    public string StatusPatching => CurrentLanguage switch
    {
        AppLanguage.Spanish => "Aplicando el parche...",
        AppLanguage.Italian => "Applicazione della patch in corso...",
        AppLanguage.English => "Applying patch...",
        AppLanguage.PortugueseBrazil => "Aplicando o patch...",
        AppLanguage.French => "Application du patch en cours...",
        AppLanguage.German => "Patch wird angewendet...",
        AppLanguage.Japanese => "パッチを適用中...",
        AppLanguage.Korean => "패치 적용 중...",
        AppLanguage.ChineseSimplified => "正在应用补丁...",
        AppLanguage.ChineseTraditional => "正在套用補丁...",
        _ => "Applying patch..."
    };

    public string GetDecryptingStatus(string progress, string total) => CurrentLanguage switch
    {
        AppLanguage.Spanish => $"Descifrando parche... ({progress} de {total} MB)",
        AppLanguage.Italian => $"Decifratura della patch... ({progress} di {total} MB)",
        AppLanguage.English => $"Decrypting patch... ({progress} of {total} MB)",
        AppLanguage.PortugueseBrazil => $"Descriptografando patch... ({progress} de {total} MB)",
        AppLanguage.French => $"Déchiffrement du patch... ({progress} sur {total} Mo)",
        AppLanguage.German => $"Patch wird entschlüsselt... ({progress} von {total} MB)",
        AppLanguage.Japanese => $"パッチを復号中... ({progress} / {total} MB)",
        AppLanguage.Korean => $"패치 복호화 중... ({progress} / {total} MB)",
        AppLanguage.ChineseSimplified => $"正在解密补丁... ({progress} / {total} MB)",
        AppLanguage.ChineseTraditional => $"正在解密補丁... ({progress} / {total} MB)",
        _ => $"Decrypting patch... ({progress} of {total} MB)"
    };

    public string GetPatchingProgressStatus(string progress, string total) => CurrentLanguage switch
    {
        AppLanguage.Spanish => $"{StatusPatching} ({progress} de {total} archivos)",
        AppLanguage.Italian => $"{StatusPatching} ({progress} di {total} file)",
        AppLanguage.English => $"{StatusPatching} ({progress} of {total} files)",
        AppLanguage.PortugueseBrazil => $"{StatusPatching} ({progress} de {total} arquivos)",
        AppLanguage.French => $"{StatusPatching} ({progress} sur {total} fichiers)",
        AppLanguage.German => $"{StatusPatching} ({progress} von {total} Dateien)",
        AppLanguage.Japanese => $"{StatusPatching} ({progress} / {total} ファイル)",
        AppLanguage.Korean => $"{StatusPatching} ({progress} / {total} 파일)",
        AppLanguage.ChineseSimplified => $"{StatusPatching} ({progress} / {total} 个文件)",
        AppLanguage.ChineseTraditional => $"{StatusPatching} ({progress} / {total} 個檔案)",
        _ => $"{StatusPatching} ({progress} of {total} files)"
    };

    public string StatusPatchSuccess => CurrentLanguage switch
    {
        AppLanguage.Spanish => "¡Se ha parcheado el juego con éxito!",
        AppLanguage.Italian => "Patch applicata con successo!",
        AppLanguage.English => "Game successfully patched!",
        AppLanguage.PortugueseBrazil => "O jogo foi atualizado com sucesso!",
        AppLanguage.French => "Le jeu a été patché avec succès !",
        AppLanguage.German => "Das Spiel wurde erfolgreich gepatcht!",
        AppLanguage.Japanese => "パッチの適用が正常に完了しました！",
        AppLanguage.Korean => "게임에 패치가 성공적으로 적용되었습니다!",
        AppLanguage.ChineseSimplified => "游戏补丁已成功安装！",
        AppLanguage.ChineseTraditional => "遊戲補丁已成功安裝！",
        _ => "Game successfully patched!"
    };

    public string StatusPatchError => CurrentLanguage switch
    {
        AppLanguage.Spanish => $"Error al aplicar el parche.{Environment.NewLine}Revisa el archivo error.log{Environment.NewLine}{Environment.NewLine}Si necesitas soporte técnico, visita el servidor{Environment.NewLine}de Discord de Traducciones Kurain.",
        AppLanguage.Italian => $"Errore durante l'applicazione della patch.{Environment.NewLine}Controlla il file error.log{Environment.NewLine}{Environment.NewLine}Se hai bisogno di supporto tecnico, visita il server{Environment.NewLine}Discord di Traducciones Kurain.",
        AppLanguage.English => $"Error applying patch.{Environment.NewLine}Check the error.log file{Environment.NewLine}{Environment.NewLine}If you need technical support, visit the{Environment.NewLine}Traducciones Kurain Discord server.",
        AppLanguage.PortugueseBrazil => $"Erro ao aplicar o patch.{Environment.NewLine}Verifique o arquivo error.log{Environment.NewLine}{Environment.NewLine}Se precisar de suporte técnico, visite o servidor{Environment.NewLine}do Discord da Traducciones Kurain.",
        AppLanguage.French => $"Erreur lors de l'application du patch.{Environment.NewLine}Vérifiez le fichier error.log{Environment.NewLine}{Environment.NewLine}Si vous avez besoin d'aide, rejoignez le serveur{Environment.NewLine}Discord de Traducciones Kurain.",
        AppLanguage.German => $"Fehler beim Anwenden des Patches.{Environment.NewLine}Überprüfe die Datei error.log{Environment.NewLine}{Environment.NewLine}Für technischen Support besuche bitte den{Environment.NewLine}Discord-Server von Traducciones Kurain.",
        AppLanguage.Japanese => $"パッチの適用中にエラーが発生しました。{Environment.NewLine}error.log ファイルを確認してください。{Environment.NewLine}{Environment.NewLine}サポートが必要な場合は、Traducciones Kurain の{Environment.NewLine}Discord サーバーへお越しください。",
        AppLanguage.Korean => $"패치 적용 중 오류가 발생했습니다.{Environment.NewLine}error.log 파일을 확인하세요.{Environment.NewLine}{Environment.NewLine}기술 지원이 필요한 경우 Traducciones Kurain의{Environment.NewLine}Discord 서버를 방문해 주세요.",
        AppLanguage.ChineseSimplified => $"应用补丁时出错。{Environment.NewLine}请查看 error.log 文件。{Environment.NewLine}{Environment.NewLine}如需技术支持，请访问{Environment.NewLine}Traducciones Kurain 的 Discord 频道。",
        AppLanguage.ChineseTraditional => $"套用補丁時發生錯誤。{Environment.NewLine}請查看 error.log 檔案。{Environment.NewLine}{Environment.NewLine}如需技術支援，請前往{Environment.NewLine}Traducciones Kurain 的 Discord 伺服器。",
        _ => $"Error applying patch.{Environment.NewLine}Check the error.log file{Environment.NewLine}{Environment.NewLine}If you need technical support, visit the{Environment.NewLine}Traducciones Kurain Discord server."
    };

    public string OriginalExeNotFoundError => CurrentLanguage switch
    {
        AppLanguage.Spanish => "No se pudo validar el archivo ejecutable original (PWAAT.exe) del juego. Por favor, asegúrate de seleccionar el directorio de una instalación oficial.",
        AppLanguage.Italian => "Impossibile convalidare il file eseguibile originale (PWAAT.exe) del gioco. Assicurati di selezionare la cartella di un'installazione ufficiale.",
        AppLanguage.English => "Could not validate the original game executable (PWAAT.exe). Please make sure to select the directory of an official installation.",
        AppLanguage.PortugueseBrazil => "Não foi possível validar o arquivo executável original (PWAAT.exe) do jogo. Certifique-se de selecionar o diretório de uma instalação oficial.",
        AppLanguage.French => "Impossible de valider l'exécutable original (PWAAT.exe) du jeu. Veuillez sélectionner le répertoire d'une installation officielle.",
        AppLanguage.German => "Die Original-Spieldatei (PWAAT.exe) konnte nicht validiert werden. Bitte stelle sicher, dass du das Verzeichnis einer offiziellen Installation auswählst.",
        AppLanguage.Japanese => "ゲームのオリジナル実行ファイル (PWAAT.exe) を検証できませんでした。公式にインストールされたフォルダを選択していることを確認してください。",
        AppLanguage.Korean => "게임의 원본 실행 파일(PWAAT.exe)을 확인할 수 없습니다. 정품 설치 디렉터리를 선택했는지 확인해 주세요.",
        AppLanguage.ChineseSimplified => "无法验证游戏的原版可执行文件 (PWAAT.exe)。请确保选择的是官方正版游戏的安装目录。",
        AppLanguage.ChineseTraditional => "無法驗證遊戲的原版執行檔 (PWAAT.exe)。請確保選擇的是官方正版遊戲的安裝目錄。",
        _ => "Could not validate the original game executable (PWAAT.exe). Please make sure to select the directory of an official installation."
    };
}
