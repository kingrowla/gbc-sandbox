using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using GBC.Tracker.Services;
using GBC.Tracker.ViewModels;

namespace GBC.Tracker;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            fonts.AddFont("Font Awesome 7 Free-Solid-900.otf", "FontAwesomeSolid");
        }).UseMauiCommunityToolkit();

        builder.Services.AddSingleton<INavigationService, ShellNavigationService>();
        builder.Services.AddSingleton<ILocationPermissionService, LocationPermissionService>();
        builder.Services.AddTransient<AppShell>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<HomeView>();
        builder.Services.AddTransient<FireTruckTrackerView>();
        builder.Services.AddTransient<BandTrackerView>();
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
