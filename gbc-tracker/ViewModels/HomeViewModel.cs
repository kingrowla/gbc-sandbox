using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GBC.Tracker.Services;

namespace GBC.Tracker.ViewModels;

public partial class HomeViewModel(INavigationService navigationService) : ObservableObject
{
    [RelayCommand]
    private Task OpenFireTruckTrackerAsync() =>
        navigationService.GoToAsync(AppRoutes.FireTruckTracker);

    [RelayCommand]
    private Task OpenBandTrackerAsync() =>
        navigationService.GoToAsync(AppRoutes.BandTracker);
}
