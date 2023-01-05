
using ChristmasProject.Applicazione.Code.Models;
using ChristmasProject.Applicazione.Code.ViewModel;
using ChristmasProject.Applicazione.Design;
using Microsoft.Maui.Handlers;

namespace ChristmasProject;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Whitney-Bold.ttf", "WhitneyBold");
			})
            .ConfigureMauiHandlers(h =>
            {
				h.AddHandler<CardPicture, ImageButtonHandler>();
			});

		builder.Services.AddSingleton<CardViewModel>();
		builder.Services.AddSingleton<GamePage>();

        return builder.Build();
	}
}
