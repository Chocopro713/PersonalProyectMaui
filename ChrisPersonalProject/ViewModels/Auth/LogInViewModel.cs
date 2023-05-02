using ChrisPersonalProject.Models;
using ChrisPersonalProject.Services;
using ChrisPersonalProject.Views.Auth;
using ChrisPersonalProject.Views.Home;

namespace ChrisPersonalProject.ViewModels.Auth;

public class LogInViewModel : BaseViewModel
{
    #region Attributes
    private string _userName;
    private string _password;
    private bool _showPassword = true;
    #endregion Attributes

    #region Properties
    public string Title { get; set; }
    public string UserName { get => _userName; set { SetProperty(ref _userName, value); } }
    public string Password { get => _password; set { SetProperty(ref _password, value); } }
    public bool ShowPassword { get => _showPassword; set { SetProperty(ref _showPassword, value); } }
    public INavigationService _navigation { get; set; }
    public Command ValidateDataCommand { get; set; }
    public Command ShowPassCommand { get; set; }
    public Command ForgotPasswordCommand { get; set; }
    public Command RegisterCommand { get; set; }
    public Command LogInWithGoogleCommand { get; set; }
    #endregion Properties

    #region Constructor
    /// <summary>
    /// Constructor de la Clase
    /// </summary>
    /// <param name="navigation"></param>
    /// <param name="service"></param>
    public LogInViewModel(INavigationService navigation, IMyService service)
    {
        _navigation = navigation;

        // this.UserName = service.ShowMessage();
        this.ValidateDataCommand = new Command(OnValidateDataCommand);
        this.ShowPassCommand = new Command(OnShowPassCommand);
        this.ForgotPasswordCommand = new Command(OnForgotPasswordCommand);
        this.RegisterCommand = new Command(OnRegisterCommand);
        this.LogInWithGoogleCommand = new Command(OnLogInWithGoogleCommand);
    }
    #endregion Constructor

    #region Commands
    /// <summary>
    /// Valida la informacion y se logea
    /// </summary>
    private async void OnValidateDataCommand()
    {
        var result = await _navigation.NavigateAsync($"/NavigationPage/{nameof(HomePage)}");
        if (!result.Success)
            Console.WriteLine(result);
    }

    /// <summary>
    /// Muestra y oculta la contraseña
    /// </summary>
    private void OnShowPassCommand()
    {
        this.ShowPassword = !this.ShowPassword;
    }

    /// <summary>
    /// Ingresa a la pagina de recuperar contraseña
    /// </summary>
    private async void OnForgotPasswordCommand()
    {
        var result = await _navigation.NavigateAsync($"/{nameof(ForgotPasswordPage)}");
        if (!result.Success)
            Console.WriteLine(result);
    }

    /// <summary>
    /// Ingresa a la pagina de Registrarse
    /// </summary>
    private async void OnRegisterCommand()
    {
        var result = await _navigation.NavigateAsync($"{nameof(LogInPage)}/{nameof(SignUpPage)}");
        if (!result.Success)
            Console.WriteLine(result);
    }

    /// <summary>
    /// Se logue con Google
    /// </summary>
    private async void OnLogInWithGoogleCommand()
    {
    }
    #endregion Commands
}