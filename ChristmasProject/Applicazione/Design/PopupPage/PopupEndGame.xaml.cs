using CommunityToolkit.Maui.Views;
using ChristmasProject.Applicazione.Code.Base;
namespace ChristmasProject.Applicazione.Design.PopupPage;

public partial class PopupEndGame : Popup
{
	private bool win;
	public PopupEndGame(bool win, int point)
	{
		InitializeComponent();

		this.win = win;

		title_image.Source = win ? "win.png" : "loose.png";

		int money = 0;

		EconomyManager economy = App.instance.EconomyManager;

		if (win)
		{
			money = (point / 10); //Soldi che guadagna
			economy.AddMoney(money);
		} else
		{
			money = 12 - (point / 10); //Soldi che perde
			economy.RemoveMoney(money);
		}

		label_money.Text = (win ? "Hai vinto: " : "Hai perso: ") + money;

	}

    void play_again_event(Object sender, EventArgs e)
    {
		Close(true);
    }

    void main_menu_event(System.Object sender, System.EventArgs e)
    {
		Close(false);
    }

}
