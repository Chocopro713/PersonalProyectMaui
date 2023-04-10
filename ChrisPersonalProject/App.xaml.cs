using Acr.UserDialogs;
using ChrisPersonalProject.Handlers;
using ChrisPersonalProject.Views.Auth;
using Microsoft.Maui.Platform;

namespace ChrisPersonalProject;

public partial class App : Application
{
    public static IUserDialogs UserDialog;
    public App(IUserDialogs userDialogs)
	{
		InitializeComponent();

        // Inicializador en prism
        UserDialog = userDialogs;

        // Ocultar la linea debajo del entry (BorderlessEntry)
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
        {
            if (view is BorderlessEntry)
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
            handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
#endif
            }
        });
    }
}
