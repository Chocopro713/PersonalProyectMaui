namespace ChrisPersonalProject.ViewModels.Auth;

public class SignUpViewModel : BindableBase
{
    #region Attributes
    #endregion Attributes

    #region Properties
    public Command TermsAndConditionsCommand { get; set; }
    #endregion Properties

    #region Constructor
    public SignUpViewModel()
    {
        this.TermsAndConditionsCommand = new Command(OnTermsAndConditionsCommand);
    }

    #endregion Constructor

    #region Commands
    /// <summary>
    /// Open the terms and conditions page
    /// </summary>
    private void OnTermsAndConditionsCommand()
    {

    }
    #endregion Commands
}
