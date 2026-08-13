using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GBC.Tracker.Services;

namespace GBC.Tracker.ViewModels;

public partial class HomeViewModel(
    INavigationService navigationService,
    ILocationPermissionService locationPermissionService) : ObservableObject
{
    private bool _hasInitialized;

    public async Task InitializeAsync()
    {
        if (_hasInitialized)
        {
            return;
        }

        try
        {
            await locationPermissionService.RequestWhenInUseAsync();
        }
        finally
        {
            _hasInitialized = true;
        }
    }

    [RelayCommand]
    private Task OpenFireTruckTrackerAsync() =>
        navigationService.GoToAsync(AppRoutes.FireTruckTracker);

    [RelayCommand]
    private Task OpenBandTrackerAsync() =>
        navigationService.GoToAsync(AppRoutes.BandTracker);
}
