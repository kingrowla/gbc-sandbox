using Microsoft.Extensions.DependencyInjection;

namespace GBC.Tracker;

public partial class AppShell : Shell
{
    public AppShell(IServiceProvider services)
    {
        InitializeComponent();

        HomeShellContent.ContentTemplate = new DataTemplate(
            () => services.GetRequiredService<HomeView>());
        Routing.RegisterRoute(AppRoutes.FireTruckTracker, typeof(FireTruckTrackerView));
        Routing.RegisterRoute(AppRoutes.BandTracker, typeof(BandTrackerView));
    }
}
