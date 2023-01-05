using ChristmasProject.Applicazione.Code.Base;
using ChristmasProject.Applicazione.Code.Manager;

namespace ChristmasProject.Applicazione.Design;

public abstract class BasePage<T> : ContentPage where T : TemplatedPage
{
    public BasePage()
    {
        NavigationPage.SetHasNavigationBar(this, false);
    }

    protected App app { get; } = App.instance;
    protected T page { get; }

    protected static ThemeManager ThemeManager { get; private set; } = new ThemeManager();
    protected static INavigationService NavigationService { get; private set; } = new NavigationService();
}

