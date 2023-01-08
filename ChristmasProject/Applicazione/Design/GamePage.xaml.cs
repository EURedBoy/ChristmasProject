using ChristmasProject.Applicazione.Code.Models;
using ChristmasProject.Applicazione.Code.ViewModel;

namespace ChristmasProject.Applicazione.Design;

public partial class GamePage : BasePage<ContentPage>
{
    private CardPicture lastCardImage;
    private CardViewModel cardView;

    private bool isRunning;
    private int score;
    private int moves;

	public GamePage(Themes themes)
	{
        InitializeComponent();

        if (!themes.IsActive)
        {
            DisplayAlert("Attenzione", "Il tema non si e' caricato correttamente", "Ok")
                .ContinueWith(task => NavigationService.GotoMainPage(this));
            return;
        }

        cardView = new CardViewModel(themes);
        BindingContext = cardView;

        lastCardImage = null;
        isRunning = false;

        score = 0;
        moves = 10;
    }

    private async void OnClick(object sender, EventArgs e)
    {
        if (!(sender is CardPicture)) return;
        if (isRunning) return;

        CardPicture cardPicture = (CardPicture)sender;
        if (cardPicture.Card.isFounded) return;
        isRunning = true;

        await Switch(cardPicture);

        isRunning = false;
    }

    private async Task Switch(CardPicture cardPicture)
    {
        MemoryCard card = cardPicture.Card;

        await card.FlipCard(cardPicture);

        if (cardPicture == lastCardImage) return;

        if (lastCardImage == null)
        {
            lastCardImage = cardPicture;
            return;
        }

        UpdateMoves();
        MemoryCard lastCard = lastCardImage.Card;

        //TODO: Check this code
        if (moves <= 0 && cardView.InGameCard <= 0)
        {
            await EndGame(true);
            return;
        }

        if (moves <= 0)
        {
            await EndGame(false);
            return;
        }

        await Task.Delay(500);

        if (isMatching(cardPicture, lastCardImage))
        {
            card.isFounded = true;
            card.isFounded = true;

            cardView.Cards.Remove(card);
            cardView.Cards.Remove(lastCard);
            UpdateScore();

        } else
        {
            await card.FlipCard(cardPicture);
            await lastCard.FlipCard(lastCardImage);
        }

        lastCardImage = null;
    }

    private async Task EndGame(bool winner)
    {
        if (winner)
        {
            SettingsManager.SetData("money", 20.ToString());
            await DisplayAlert("Hai vinto!", "Bravo, hai vinto", "Ok");
            await NavigationService.GotoMainPage(this);
            return;
        }
        //TODO: Fai un setmoney getmoney
        int currentMoney = Int32.Parse(SettingsManager.GetData("money"));
        SettingsManager.SetData("money", (currentMoney-10).ToString());

        await DisplayAlert("Hai perso", "Mi spiace, hai perso", "Ok");
        await NavigationService.GotoMainPage(this);
        return;
    }

    private bool isMatching(CardPicture one, CardPicture two)
    {
        return one.Source.ToString().Equals(two.Source.ToString());
    }


    private void UpdateScore()
    {
        score_label.Text = "Score: " + (score + 10);
    }

    private void UpdateMoves()
    {
        moves_label.Text = "Moves: " + --moves;
    }

}