namespace GBC.Tracker.Services;

public interface INavigationService
{
    Task GoToAsync(string route);
}
