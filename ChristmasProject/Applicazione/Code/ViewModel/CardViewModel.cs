﻿using ChristmasProject.Applicazione.Code.Models;
using System.Collections.ObjectModel;

namespace ChristmasProject.Applicazione.Code.ViewModel;
    
public partial class CardViewModel
{
    public ObservableCollection<MemoryCard> Cards { get; set; } = new ObservableCollection<MemoryCard>();
    private List<ImageSource> cardImage;

    private static ImageSource[] defaultImage = new ImageSource[]
    {
        ImageSource.FromFile("blu.png"),
        ImageSource.FromFile("bianco.png"),
        ImageSource.FromFile("nero.png"),
        ImageSource.FromFile("rosso.png"),
        ImageSource.FromFile("giallo.webp"),
        ImageSource.FromFile("silver.webp")
    };

    public int InGameCard { get; set; }

    public CardViewModel(Themes theme)
    {
        if (theme == null) cardImage = defaultImage.ToList();
        else cardImage = theme.imageSources.ToList();

        InGameCard = 12;
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

    private void insert(MemoryCard[] array, ImageSource path, Random random)
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
