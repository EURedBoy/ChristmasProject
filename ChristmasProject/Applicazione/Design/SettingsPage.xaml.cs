namespace ChristmasProject.Applicazione.Design;

public partial class SettingsPage : BasePage<ContentPage>
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    async void AudioTest(System.Object sender, System.EventArgs e)
    {
        if (SettingsManager.audioPlayer.IsPlaying) SettingsManager.audioPlayer.Pause();
        else SettingsManager.audioPlayer.Play();
    }

    void BackEvent(Object sender, EventArgs e)
    {
        NavigationService.GotoMainPage();
    }
}