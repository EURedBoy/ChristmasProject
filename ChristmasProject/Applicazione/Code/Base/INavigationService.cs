using ChristmasProject.Applicazione.Code.Models;
using ChristmasProject.Applicazione.Design;

namespace ChristmasProject.Applicazione.Code.Base
{
    public interface INavigationService
    {

        public Task NavigateBack(BasePage<ContentPage> page);
        public Task GotoMainPage(BasePage<ContentPage> page);
        public Task GotoGame(BasePage<ContentPage> page, Themes theme);
        public Task GotoShop(BasePage<ContentPage> page);
        public Task GotoSettings(BasePage<ContentPage> page);
    }

    public class NavigationService : INavigationService
    {
        public Task GotoGame(BasePage<ContentPage> page, Themes theme)
        {
            page.Navigation.PopToRootAsync(false); //TODO: Check
            return page.Navigation.PushAsync(new GamePage(theme));
        }

        public Task GotoMainPage(BasePage<ContentPage> page)
        {
            return page.Navigation.PopToRootAsync(false);
        }

        public Task GotoSettings(BasePage<ContentPage> page)
        {
            page.Navigation.PopToRootAsync(false);
            return page.Navigation.PushAsync(new SettingsPage());
        }

        public Task GotoShop(BasePage<ContentPage> page)
        {
            page.Navigation.PopToRootAsync(false);
            return page.Navigation.PushAsync(new SettingsPage());
        }

        public Task NavigateBack(BasePage<ContentPage> page)
        {
            return page.Navigation.PopAsync(false);
        }
    }
}
