using ChrisPersonalProject.Views.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisPersonalProject.ViewModels.Auth;

public class EnterOTPViewModel : BindableBase
{
    public INavigationService _navigation { get; set; }
    public Command SubmitCommand { get; set; }

    public EnterOTPViewModel(INavigationService navigation)
    {
        _navigation = navigation;
        this.SubmitCommand = new Command(OnSubmitCommand);
    }

    private async void OnSubmitCommand()
    {
        var result = await _navigation.NavigateAsync($"{nameof(ResetPasswordPage)}");
        if (!result.Success)
            Console.WriteLine(result);
    }
}
