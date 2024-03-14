#if ANDROID
using Android.Views;
#endif

using Microsoft.Extensions.Logging;

namespace LIN.Allo.App;


public static class MauiProgram
{


    /// <summary>
    /// Crear app.
    /// </summary>
    /// <returns></returns>
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

        LIN.Allo.Shared.Services.Scripts.Build();
        // Iniciar.
        LIN.Access.Auth.Build.Init();
        LIN.Access.Communication.Build.Init();
        LIN.Access.Search.Build.Init();
       
        return builder.Build();
    }



    /// <summary>
    /// Color del status bar.
    /// </summary>
    public static void LoadColor()
    {
#if ANDROID
        var currentActivity = Platform.CurrentActivity;

        if (currentActivity == null || currentActivity.Window == null)
            return;

        var currentTheme = AppInfo.RequestedTheme;

        if (currentTheme == AppTheme.Light)
        {
            currentActivity.Window.SetStatusBarColor(new(252, 252, 255));
            currentActivity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
        }
        else
        {
            currentActivity.Window.SetStatusBarColor(new(0, 0, 0));
            currentActivity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
        }
#endif
    }


}
