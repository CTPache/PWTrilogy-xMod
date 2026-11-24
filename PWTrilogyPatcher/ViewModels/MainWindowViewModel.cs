using CommunityToolkit.Mvvm.ComponentModel;
using PWTrilogyPatcher.Services;

namespace PWTrilogyPatcher.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase contentViewModel;

    public string WindowTitle => LocalizationService.Instance.WindowTitle;

    public string[] AvailableLanguages => LocalizationService.LanguageDisplayNames;

    public int SelectedLanguageIndex
    {
        get => (int)LocalizationService.Instance.CurrentLanguage;
        set
        {
            if (value >= 0 && value < LocalizationService.LanguageDisplayNames.Length)
            {
                LocalizationService.Instance.CurrentLanguage = (AppLanguage)value;
                OnPropertyChanged(nameof(SelectedLanguageIndex));
            }
        }
    }

    public MainWindowViewModel()
    {
        LocalizationService.Instance.LanguageChanged += () =>
        {
            OnPropertyChanged(nameof(WindowTitle));
            OnPropertyChanged(nameof(SelectedLanguageIndex));
        };

        if (App.UpdateMode)
        {
            SetPatcherViewModel();
        }
        else
        {
            SetMainViewModel();
        }
    }

    public void SetMainViewModel()
    {
        ContentViewModel = new MainViewModel();
    }

    public void SetPatcherViewModel()
    {
        ContentViewModel = new PatcherViewModel();
    }
}
