using ChristmasProject.Applicazione.Code.Utils;

namespace ChristmasProject.Applicazione.Design;

public partial class HomePage : BasePage<ContentPage>
{
	public HomePage()
	{
		InitializeComponent();
    }

    private async void start_button(object sender, EventArgs e)
    {
        await NavigationService.GotoGame(ThemeManager.SelectedTheme == null ? ThemeManager.DefaultTheme : ThemeManager.SelectedTheme);
    }

    private async void shop_button(object sender, EventArgs e)
    {
        await NavigationService.GotoShop();
    }

    private async void settings_button(object sender, EventArgs e)
    {
        await NavigationService.GotoSettings();
    }
}