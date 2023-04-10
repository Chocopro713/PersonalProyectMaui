using Acr.UserDialogs;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace ChrisPersonalProject;

public static class MauiProgram
{
    /// <summary>
    /// Main configuration of the application using Prism
    /// </summary>
    /// <returns></returns>
    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UsePrism(PrismStartup.Configure)
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons");
            })
            .Services.AddSingleton<IUserDialogs>(UserDialogs.Instance);

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
