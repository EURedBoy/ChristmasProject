using ChristmasProject.Applicazione.Code.Models;
using ChristmasProject.Applicazione.Design;

namespace ChristmasProject.Applicazione.Code.Base
{
    public interface INavigationService
    {

        public Task NavigateBack();
        public Task GotoMainPage();
        public Task GotoGame(Themes theme);
        public Task GotoShop();
        public Task GotoSettings();
    }

    public class NavigationService : INavigationService
    {
        public Task GotoGame(Themes theme)
        {
            App.Current.MainPage.Navigation.PopToRootAsync(false); //TODO: Check
            return App.Current.MainPage.Navigation.PushAsync(new GamePage(theme));
        }

        public Task GotoMainPage()
        {
            return App.Current.MainPage.Navigation.PopToRootAsync(false);
        }

        public Task GotoSettings()
        {
            //App.Current.MainPage.Navigation.PopToRootAsync(false);
            return App.Current.MainPage.Navigation.PushAsync(new SettingsPage());
        }

        public Task GotoShop()
        {
            //page.Navigation.PopToRootAsync(false); //TODO: Check
            return App.Current.MainPage.Navigation.PushAsync(new ShopPage());
        }

        public Task NavigateBack()
        {
            return App.Current.MainPage.Navigation.PopAsync(false);
        }
    }
}
