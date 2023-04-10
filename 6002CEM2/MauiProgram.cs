using _6002CEM2.ViewModel;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;

namespace _6002CEM2;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement()
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
        builder.Services.AddSingleton<UserPage>();
        builder.Services.AddSingleton<UserPageViewModel>();
        builder.Services.AddSingleton<CreateJoinGroupViewModel>();
        builder.Services.AddSingleton<CreateJoinGroup>();
        builder.Services.AddSingleton<JoinGroup>();
        builder.Services.AddSingleton<JoinGroupViewModel>();
        builder.Services.AddSingleton<MakeGroup>();
        builder.Services.AddSingleton<MakeGroupViewModel>();
        builder.Services.AddSingleton<RegisterPage>();
        builder.Services.AddSingleton<RegisterPageViewModel>();
        builder.Services.AddSingleton<GroupSettings>();
        builder.Services.AddSingleton<GroupSettingsViewModel>();
        builder.Services.AddSingleton<JoinGroup>();
        builder.Services.AddSingleton<JoinGroupViewModel>();
        builder.Services.AddSingleton<Settings>();
        builder.Services.AddSingleton<SettingsViewModel>();
        builder.Services.AddSingleton<NoteViewModel>();
        builder.Services.AddSingleton<Note>();
        builder.Services.AddSingleton(AudioManager.Current);
        return builder.Build();
	}
}
