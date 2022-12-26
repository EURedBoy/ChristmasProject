using ChristmasProject.Applicazione.Design;

namespace ChristmasProject;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new HomePage();
	}
}
