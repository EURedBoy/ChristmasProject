using ChristmasProject.Applicazione.Code.ViewModel;

namespace ChristmasProject.Applicazione.Design;

public partial class HomePage : BasePage<ContentPage>
{
	public HomePage()
	{
		InitializeComponent();
    }

    private async void start_button(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new GamePage(new CardViewModel()));
    }

    private void shop_button(object sender, EventArgs e)
    {

    }

    private void settings_button(object sender, EventArgs e)
    {

    }
}