using Acr.UserDialogs;
using ChrisPersonalProject.Views.Auth;

namespace ChrisPersonalProject;

public partial class App : Application
{
    public static IUserDialogs UserDialog;
    public App(IUserDialogs userDialogs)
	{
		InitializeComponent();
        UserDialog = userDialogs;
    }
}
