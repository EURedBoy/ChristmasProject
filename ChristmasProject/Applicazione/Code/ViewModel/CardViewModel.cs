using ChristmasProject.Applicazione.Code.Models;
using System.Collections.ObjectModel;

namespace ChristmasProject.Applicazione.Code.ViewModel;
    
public partial class CardViewModel
{
    public ObservableCollection<MemoryCard> Cards { get; set; } = new ObservableCollection<MemoryCard>();

    public CardViewModel()
    {
        BindChatList();
    }

    private void BindChatList()
    {
        Cards.Add(new MemoryCard("card_one.jpg", 1));
        Cards.Add(new MemoryCard("card_one.jpg", 2));
        Cards.Add(new MemoryCard("card_one.jpg", 3));
        Cards.Add(new MemoryCard("card_one.jpg", 4));
        Cards.Add(new MemoryCard("card_one.jpg", 5));
        Cards.Add(new MemoryCard("card_one.jpg", 6));
        Cards.Add(new MemoryCard("card_one.jpg", 7));
        Cards.Add(new MemoryCard("card_one.jpg", 8));
        Cards.Add(new MemoryCard("card_one.jpg", 9));
        Cards.Add(new MemoryCard("card_one.jpg", 10));
        Cards.Add(new MemoryCard("card_one.jpg", 11));
        Cards.Add(new MemoryCard("card_one.jpg", 12));
    }
}
