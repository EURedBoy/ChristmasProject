
using ChristmasProject.Applicazione.Code.Models;
using ChristmasProject.Applicazione.Code.ViewModel;
using ChristmasProject.Applicazione.Design;
using CommunityToolkit.Maui;
using Microsoft.Maui.Handlers;
using Plugin.Maui.Audio;

namespace ChristmasProject;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Whitney-Bold.ttf", "WhitneyBold");
			})
            .ConfigureMauiHandlers(h =>
            {
				h.AddHandler<CardPicture, ImageButtonHandler>();
				h.AddHandler<ShopButton, ButtonHandler>();
			});

		builder.Services.AddSingleton<CardViewModel>();
		builder.Services.AddSingleton<GamePage>();

        return builder.Build();
	}
}
