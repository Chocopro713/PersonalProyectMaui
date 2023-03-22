using ChrisPersonalProject.Services;
using ChrisPersonalProject.Views.Auth;

namespace ChrisPersonalProject.ViewModels.Auth;

public class LogInViewModel : BindableBase
{
    #region Attributes
    private string _userName;
    private string _password;
    #endregion Attributes

    #region Properties
    public string Title { get; set; }
    public string UserName { get => _userName; set { SetProperty(ref _userName, value); } }
    public string Password { get => _password; set { SetProperty(ref _password, value); } }
    public INavigationService _navigation { get; set; }
    public Command ValidateDataCommand { get; set; }
    #endregion Properties

    #region Constructor
    public LogInViewModel(INavigationService navigation, IMyService service)
    {
        _navigation = navigation;

        this.Title = "Test Title";
        this.UserName = service.ShowMessage();
        this.ValidateDataCommand = new Command(OnValidateDataCommand);
    }
    #endregion Constructor

    #region Commands
    private async void OnValidateDataCommand()
    {
        var result = await _navigation.NavigateAsync($"{nameof(SignUpPage)}");
        if (!result.Success)
            Console.WriteLine(result);
    }
    #endregion Commands
}