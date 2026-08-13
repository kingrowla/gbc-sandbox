using GBC.Tracker.ViewModels;
using Microsoft.Extensions.Logging;

namespace GBC.Tracker;

public partial class HomeView : ContentPage
{
    private readonly HomeViewModel _viewModel;
    private readonly ILogger<HomeView> _logger;

    public HomeView(HomeViewModel viewModel, ILogger<HomeView> logger)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
        _logger = logger;
        Loaded += OnLoaded;
    }

    private async void OnLoaded(object? sender, EventArgs e)
    {
        Loaded -= OnLoaded;

        try
        {
            // Allow the first native frame to finish before presenting a system prompt.
            await Task.Yield();
            await _viewModel.InitializeAsync();
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Unable to initialize HomeView permissions.");
        }
    }
}
