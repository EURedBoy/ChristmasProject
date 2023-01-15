using ChristmasProject.Applicazione.Code.Base;
using ChristmasProject.Applicazione.Code.Models;
using ChristmasProject.Applicazione.Code.ViewModel;
using CommunityToolkit.Maui.Views;
using ChristmasProject.Applicazione.Design.PopupPage;

namespace ChristmasProject.Applicazione.Design;

public partial class GamePage : BasePage<ContentPage>
{
    private CardPicture lastCardImage;
    private CardViewModel cardView;

    private Themes currentTheme;

    private bool isRunning;
    private int score;
    private int moves;

	public GamePage(Themes themes)
	{
        InitializeComponent();

        currentTheme = themes;

        if (!themes.IsActive)
        {
            DisplayAlert("Attenzione", "Il tema non si e' caricato correttamente", "Ok")
                .ContinueWith(task => NavigationService.GotoMainPage());
            return;
        }

        cardView = new CardViewModel(themes);
        BindingContext = cardView;

        lastCardImage = null;
        isRunning = false;

        score = 0;
        moves = 15;

        moves_label.Text = "Moves: " + moves;
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

        if (cardPicture == lastCardImage)
        {
            lastCardImage = null;
            return;
        }

        if (lastCardImage == null)
        {
            lastCardImage = cardPicture;
            return;
        }

        UpdateMoves();
        MemoryCard lastCard = lastCardImage.Card;

        await Task.Delay(500);

        if (isMatching(cardPicture, lastCardImage))
        {
            card.isFounded = true;
            lastCard.isFounded = true;

            //TODO: Controllo nei settings
            //cardView.Cards.Remove(card);
            //cardView.Cards.Remove(lastCard);

            cardView.InGameCard -= 2;
            UpdateScore();
        } else
        {
            await card.FlipCard(cardPicture);
            await lastCard.FlipCard(lastCardImage);
        }

        //TODO: Check this code non funziona la vittoria probabilmente non giro le carte prima
        if (cardView.InGameCard <= 0)
        {
            var response = await this.ShowPopupAsync(new PopupEndGame(true, score));

            if (response is bool boolResult)
                if (boolResult) await NavigationService.GotoGame(currentTheme);
                else await NavigationService.GotoMainPage();

            return;
        }

        if (moves <= 0)
        {
            var response = await this.ShowPopupAsync(new PopupEndGame(false, score));

            if (response is bool boolResult)
                if (boolResult) await NavigationService.GotoGame(currentTheme);
                else await NavigationService.GotoMainPage();

            return;
        }

        lastCardImage = null;
    }

    private async Task EndGame(bool winner)
    {
        if (winner)
        {
            EconomyManager.AddMoney(20);

            await DisplayAlert("Hai vinto!", "Bravo, hai vinto " + EconomyManager.Money, "Ok");
            await NavigationService.GotoMainPage();
            return;
        }
        EconomyManager.RemoveMoney(10);

        await DisplayAlert("Hai perso", "Mi spiace, hai perso " + EconomyManager.Money, "Ok");
        await NavigationService.GotoMainPage();
    }

    private bool isMatching(CardPicture one, CardPicture two)
    {
        return one.Source.ToString().Equals(two.Source.ToString());
    }


    private void UpdateScore()
    {
        score_label.Text = "Score: " + (score += 10);
    }

    private void UpdateMoves()
    {
        moves_label.Text = "Moves: " + --moves;
    }

    void BackEvent(System.Object sender, System.EventArgs e)
    {
        NavigationService.GotoMainPage();
    }
}