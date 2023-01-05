using ChristmasProject.Applicazione.Code.Models;
using System.Collections.ObjectModel;

namespace ChristmasProject.Applicazione.Code.ViewModel;
    
public partial class CardViewModel
{
    public ObservableCollection<MemoryCard> Cards { get; set; } = new ObservableCollection<MemoryCard>();

    private List<string> cardImage = new List<string>() 
    { 
        "sw_black_death.png",
        "sw_darth_fener.png",
        "sw_falcon.png",
        "sw_resistance.png",
        "sw_ship.png",
        "sw_storm_trooper.png"
    };

    public CardViewModel()
    {
        BindChatList();
    }

    private void BindChatList()
    {
        Random random = new Random();

        MemoryCard[] preload = new MemoryCard[cardImage.Count*2];

        foreach (var path in cardImage)
        {
            insert(preload, path, random);
        }

        foreach (var item in preload)
        {
            Cards.Add(item);
        }
    }

    private void insert(MemoryCard[] array, string path, Random random)
    {
        for (int i = 0; i < 2; i++)
        {
            int tries = 0;
            while (tries < 20)
            {
                tries++;

                int pos = random.Next(0, 12);

                if (array[pos] != null) continue;

                array[pos] = new MemoryCard(path, pos);
                break;
            }
        }
    }

}
