namespace ChristmasProject.Applicazione.Design;

public abstract class BasePage<T> : ContentPage where T : TemplatedPage
{

    public BasePage()
    {
        NavigationPage.SetHasNavigationBar(this, false);
        //Impostare il title a codice maybe
    }

    protected App app { get; } = App.instance;
    protected T page { get; }
}

