using ChristmasProject.Applicazione.Code.Models;
using ChristmasProject.Applicazione.Design;

namespace ChristmasProject.Applicazione.Code.Base
{
    public interface INavigationService
    {

        public Task NavigateBack();
        public Task GotoMainPage();
        public Task GotoGame(Themes theme);
    }

    public class NavigationService : INavigationService
    {
        public Task GotoGame(Themes theme)
        {
            return Shell.Current.Navigation.PushAsync(new GamePage(theme));
        }

        public Task GotoMainPage()
        {
            return Shell.Current.Navigation.PopToRootAsync(false);
        }

        public Task NavigateBack()
        {
            return Shell.Current.GoToAsync("...", false);
        }
    }
}
