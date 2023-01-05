using ChristmasProject.Applicazione.Code.Models;
using ChristmasProject.Applicazione.Code.ViewModel;

namespace ChristmasProject.Applicazione.Design;

public partial class GamePage : BasePage<ContentPage>
{
    private CardPicture lastCardImage;

    private CardViewModel cardView;

    private bool isRunning;

	public GamePage(CardViewModel viewModel)
	{
        InitializeComponent();

        BindingContext= viewModel;
        cardView = viewModel;

        lastCardImage = null;
        isRunning = false;
    }

    private async void OnClick(object sender, EventArgs e)
    {
        if (!(sender is CardPicture)) return;
        if (isRunning) return;

        isRunning = true;

        CardPicture cardPicture = (CardPicture) sender;

        await Switch(cardPicture);

        isRunning = false;
    }

    private async Task Switch(CardPicture cardPicture)
    {
        MemoryCard card = cardPicture.Card;

        await card.FlipCard(cardPicture);

        if (lastCardImage == null)
        {
            lastCardImage = cardPicture;
            return;
        }

        MemoryCard lastCard = lastCardImage.Card;

        await Task.Delay(500);

        if (isMatching(cardPicture, lastCardImage))
        {
            cardView.Cards.Remove(card);
            cardView.Cards.Remove(lastCard);
        } else
        {
            await card.FlipCard(cardPicture);
            await lastCard.FlipCard(lastCardImage);
        }

        lastCardImage = null;
    }

    private bool isMatching(CardPicture one, CardPicture two)
    {
        return one.Source.ToString().Equals(two.Source.ToString());
    }
}