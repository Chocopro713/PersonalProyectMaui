namespace ChrisPersonalProject.ViewModels.Auth;

public class SignUpViewModel : BindableBase
{
    #region Attributes
    private bool _showPassword = true;
    #endregion Attributes

    #region Properties
    public bool ShowPassword { get => _showPassword; set { SetProperty(ref _showPassword, value); } }
    public Command TermsAndConditionsCommand { get; set; }
    public Command ShowPassCommand { get; set; }
    #endregion Properties

    #region Constructor
    public SignUpViewModel()
    {
        this.TermsAndConditionsCommand = new Command(OnTermsAndConditionsCommand);
        this.ShowPassCommand = new Command(OnShowPassCommand);
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
    #endregion Commands
}
