using ChristmasProject.Applicazione.Code.Base;
using ChristmasProject.Applicazione.Code.Manager;
using ChristmasProject.Applicazione.Code.ViewModel;
using ChristmasProject.Applicazione.Design;

#if WINDOWS
using Microsoft.UI;
using Windows.Graphics;
using Microsoft.UI.Windowing;
#endif

namespace ChristmasProject;

public partial class App : Application
{

    const int WindowWidth = 360;
    const int WindowHeight = 640;

	public App()
	{
        InitializeComponent();

        init();

#if WINDOWS
        Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        {
            var mauiWindow = handler.VirtualView;
            var nativeWindow = handler.PlatformView;
            nativeWindow.Activate();
            IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
            WindowId windowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
            AppWindow appWindow = AppWindow.GetFromWindowId(windowId);
            appWindow.Resize(new SizeInt32(WindowWidth, WindowHeight));
            var presenter = appWindow.Presenter as OverlappedPresenter;
            presenter.IsResizable = false;
        });
#endif

        SettingsManager = new SettingsManager();
        ThemeManager = new ThemeManager();
        NavigationService = new NavigationService();
        EconomyManager = new EconomyManager();

        MainPage = new NavigationPage(new HomePage());
	}

    private void init()
    {
        instance = this;
    }

    public ThemeManager ThemeManager { get; private set; }
    public INavigationService NavigationService { get; private set; }
    public SettingsManager SettingsManager { get; private set; }
    public EconomyManager EconomyManager { get; set; }

    public static App instance { get; set; }

    
}
