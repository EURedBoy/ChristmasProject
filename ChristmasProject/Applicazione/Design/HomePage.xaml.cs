namespace ChristmasProject.Applicazione.Design;

public partial class HomePage : BasePage<ContentPage>
{
	public HomePage()
	{
		InitializeComponent();
        ThemeManager.SelectedTheme = ThemeManager.GetThemeFromName("starwars");

        string path = Path.Combine(FileSystem.Current.AppDataDirectory, "Memory");
        DisplayAlert("ciao", path, "ciao");
    }

    private async void start_button(object sender, EventArgs e)
    {
        await NavigationService.GotoGame(this, ThemeManager.SelectedTheme == null ? ThemeManager.DefaultTheme : ThemeManager.SelectedTheme);
    }

    private void shop_button(object sender, EventArgs e)
    {

    }

    private void settings_button(object sender, EventArgs e)
    {

    }
}