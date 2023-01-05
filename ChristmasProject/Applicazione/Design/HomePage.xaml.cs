namespace ChristmasProject.Applicazione.Design;

public partial class HomePage : BasePage<ContentPage>
{
	public HomePage()
	{
		InitializeComponent();
    }

    private async void start_button(object sender, EventArgs e)
    {
        await NavigationService.GotoGame();
    }

    private void shop_button(object sender, EventArgs e)
    {

    }

    private void settings_button(object sender, EventArgs e)
    {

    }
}