using Acr.UserDialogs;
using ChrisPersonalProject.Services;
using ChrisPersonalProject.Services.RestApi;
using ChrisPersonalProject.ViewModels.Auth;
using ChrisPersonalProject.ViewModels.Home;
using ChrisPersonalProject.Views.Auth;
using ChrisPersonalProject.Views.Home;

namespace ChrisPersonalProject;

internal static class PrismStartup 
{
    public static void Configure(PrismAppBuilder builder)
    {
        builder.RegisterTypes(RegisterTypes).OnAppStart("/NavigationPage/LogInPage");
    }

    public static void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry
            // Services
            .RegisterSingleton<IMyService, MyService>()
            .RegisterSingleton<IApiManager, ApiManager>()
            .RegisterSingleton<GlobalSetting>()

            // Auth
            .RegisterForNavigation<LogInPage, LogInViewModel>()
            .RegisterForNavigation<SignUpPage, SignUpViewModel>()
            .RegisterForNavigation<ForgotPasswordPage, ForgotPasswordViewModel>()
            .RegisterForNavigation<ResetPasswordPage, ResetPasswordViewModel>()
            .RegisterForNavigation<EnterOTPPage, EnterOTPViewModel>()

            // Home
            .RegisterForNavigation<HomePage, HomeViewModel>()

            // Default
            .RegisterInstance(SemanticScreenReader.Default);
    }
}