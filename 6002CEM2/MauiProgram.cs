using _6002CEM2.ViewModel;
using Microsoft.Extensions.Logging;

namespace _6002CEM2;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiMaps()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<Tests>();
		builder.Services.AddSingleton<DefultViewModel>();
		builder.Services.AddSingleton<DataPassViewModel>();
        builder.Services.AddSingleton<LogIn2ViewModel>();
        builder.Services.AddSingleton<LogIn2>();
      
        return builder.Build();
	}
}
