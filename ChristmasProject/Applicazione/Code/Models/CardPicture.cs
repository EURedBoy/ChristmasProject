namespace ChristmasProject.Applicazione.Code.Models
{
    public class CardPicture : ImageButton
    {
        public static readonly BindableProperty CardProperty =
            BindableProperty.Create("Card", typeof(MemoryCard), typeof(CardPicture), null);

        public MemoryCard Card
        {
            get => (MemoryCard)GetValue(CardProperty);
            set => SetValue(CardProperty, value);
        }
    }
}
