using ChristmasProject.Applicazione.Code.Models;

namespace ChristmasProject.Applicazione.Design;

public partial class ShopPage : BasePage<ContentPage>
{
	public ShopPage()
	{
		InitializeComponent();

		BindingContext = ThemeManager;
        UpdateMoney();
	}

    void BackEvent(Object sender, EventArgs e)
    {
		NavigationService.GotoMainPage();
    }

    void OnBuyEvent(Object sender, EventArgs e)
    {
        if (!(sender is ShopButton)) return;
        ShopButton shop = (ShopButton)sender;
        Themes theme = shop.Theme;

        if (!theme.IsBought)
        {
            if (EconomyManager.Money < long.Parse(theme._prize)) return;

            theme.BuyTheme();
            SettingsManager.SerializeTheme(
                ThemeManager.Themes.Where(theme => theme.IsBought).ToList());

            EconomyManager.RemoveMoney(long.Parse(theme._prize));
            UpdateMoney();
            return;
        }

        theme.IsSelected = true;
        ThemeManager.SelectedTheme = theme;
        SettingsManager.SetData("selected_themes", theme.Name);
    }

    private void UpdateMoney()
    {
        label_money.Text = EconomyManager.Money + "";
    }
}