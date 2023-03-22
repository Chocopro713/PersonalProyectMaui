using ChrisPersonalProject.Services;
using ChrisPersonalProject.ViewModels.Auth;
using ChrisPersonalProject.Views.Auth;

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
            .RegisterSingleton<IMyService, MyService>()

            .RegisterForNavigation<LogInPage, LogInViewModel>()
            .RegisterForNavigation<SignUpPage, SignUpViewModel>()

            .RegisterInstance(SemanticScreenReader.Default);
    }
}