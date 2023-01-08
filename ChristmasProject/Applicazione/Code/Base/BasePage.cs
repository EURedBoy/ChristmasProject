﻿using ChristmasProject.Applicazione.Code.Base;
using ChristmasProject.Applicazione.Code.Manager;

namespace ChristmasProject.Applicazione.Design;

public abstract class BasePage<T> : ContentPage where T : TemplatedPage
{
    public BasePage()
    {
        NavigationPage.SetHasNavigationBar(this, false);

        ThemeManager = app.ThemeManager;
        NavigationService= app.NavigationService;
        SettingsManager = app.SettingsManager;
    }

    protected App app { get; } = App.instance;
    protected T page { get; }

    protected ThemeManager ThemeManager { get; private set; }
    protected INavigationService NavigationService { get; private set; }
    protected SettingsManager SettingsManager { get; private set; }
}

