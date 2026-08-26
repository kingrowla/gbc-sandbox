using Microsoft.Extensions.DependencyInjection;

namespace GBC.Tracker;

public partial class AppShell : Shell
{
    public AppShell(IServiceProvider services)
    {
        InitializeComponent();

        TrackerShellContent.ContentTemplate = new DataTemplate(() =>
            DeviceInfo.Platform == DevicePlatform.Android
                ? services.GetRequiredService<MapsUnavailableView>()
                : services.GetRequiredService<FireTruckTrackerView>());
        
        HomeShellContent.ContentTemplate = new DataTemplate(
            services.GetRequiredService<HomeView>);

        AdminShellContent.ContentTemplate = new DataTemplate(
            services.GetRequiredService<AdminView>);

        Routing.RegisterRoute(AppRoutes.BandTracker, typeof(BandTrackerView));
        Routing.RegisterRoute(AppRoutes.Home, typeof(HomeView));
        Routing.RegisterRoute(AppRoutes.Admin, typeof(AdminView));

    }
}
