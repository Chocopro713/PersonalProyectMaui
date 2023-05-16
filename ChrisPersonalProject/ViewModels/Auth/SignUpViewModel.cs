using ChrisPersonalProject.Views.Auth;

namespace ChrisPersonalProject.ViewModels.Auth;

public class SignUpViewModel : BindableBase
{
    #region Attributes
    private bool _showPassword = true;
    #endregion Attributes

    #region Properties
    public bool ShowPassword { get => _showPassword; set { SetProperty(ref _showPassword, value); } }
    public INavigationService _navigation { get; set; }
    public Command TermsAndConditionsCommand { get; set; }
    public Command ShowPassCommand { get; set; }
    public Command SingUpCommand { get; set; }
    #endregion Properties

    #region Constructor
    public SignUpViewModel(INavigationService navigation)
    {
        _navigation = navigation;

        this.TermsAndConditionsCommand = new Command(OnTermsAndConditionsCommand);
        this.ShowPassCommand = new Command(OnShowPassCommand);
        this.SingUpCommand = new Command(OnSingUpCommand);
    }

    #endregion Constructor

    #region Commands
    /// <summary>
    /// Open the terms and conditions page
    /// </summary>
    private void OnTermsAndConditionsCommand()
    {

    }

    /// <summary>
    /// Muestra y oculta la contraseña
    /// </summary>
    private void OnShowPassCommand()
    {
        this.ShowPassword = !this.ShowPassword;
    }

    private async void OnSingUpCommand()
    {
        var result = await _navigation.NavigateAsync($"{nameof(EnterOTPPage)}");
        if (!result.Success)
            Console.WriteLine(result);
    }
    #endregion Commands
}
