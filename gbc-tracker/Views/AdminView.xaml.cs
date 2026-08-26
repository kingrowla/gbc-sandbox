using GBC.Tracker.ViewModels;

namespace GBC.Tracker;

public partial class AdminView : ContentPage
{
    public AdminView(AdminViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
