using Microsoft.Maui.ApplicationModel;

namespace GBC.Tracker.Services;

public interface ILocationPermissionService
{
    Task<PermissionStatus> RequestWhenInUseAsync();
}
