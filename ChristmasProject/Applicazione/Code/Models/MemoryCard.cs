using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace ChristmasProject.Applicazione.Code.Models;

public partial class MemoryCard : ObservableObject
{
    private bool isShowed;
    public bool isFounded { get; set; }

    private ImageSource revealSource;
    private ImageSource hideSource = ImageSource.FromFile("cards.png");

    public MemoryCard(ImageSource source, int id)
    {
        revealSource = source;
        Id = id;

        isShowed = false;
    }

    public string Source { get; set; }
    public int Id { get; set; }

    public async Task FlipCard(CardPicture cardPicture) //Assolutamente sistemare sto codice
    {
        await cardPicture.RotateYTo(180, 250);
        cardPicture.RotationY = 0;

        cardPicture.Source = isShowed ? hideSource : revealSource;
        isShowed = !isShowed;
    }

    public override string ToString()
    {
        return "Carta con source: " + Source;
    }

}
