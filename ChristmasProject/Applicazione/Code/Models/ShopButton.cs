using System;
namespace ChristmasProject.Applicazione.Code.Models
{
	public class ShopButton : Button
	{
        public static readonly BindableProperty ThemeProperty =
            BindableProperty.Create("Theme", typeof(Themes), typeof(ShopButton), null);

        public Themes Theme 
        {
            get => (Themes)GetValue(ThemeProperty);
            set => SetValue(ThemeProperty, value);
        }
    }
}

