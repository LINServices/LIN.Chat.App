#if ANDROID
using Android.Views;
#endif
using Microsoft.Extensions.Logging;
using LIN.Access.Auth;

namespace LIN.Allo.App
{
    public static class MauiProgram
    {

        /// <summary>
        /// Crear app Maui.
        /// </summary>
        public static Microsoft.Maui.Hosting.MauiApp CreateMauiApp()
        {
            var builder = Microsoft.Maui.Hosting.MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddAuthenticationService();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            LIN.Allo.Shared.Services.Scripts.Build();
            // Iniciar.
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
            currentActivity.Window.SetStatusBarColor(new(255, 255, 255));
            currentActivity.Window.SetNavigationBarColor(new(255, 255, 255));
            currentActivity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
        }
        else
        {
            currentActivity.Window.SetStatusBarColor(new(0,0,0));
            currentActivity.Window.SetNavigationBarColor(new(0, 0, 0));
            currentActivity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.Visible;
        }
#endif
        }



        /// <summary>
        /// Color del status bar.
        /// </summary>
        public static void LoadColorSelect()
        {
#if ANDROID
        var currentActivity = Platform.CurrentActivity;

        if (currentActivity == null || currentActivity.Window == null)
            return;

        var currentTheme = AppInfo.RequestedTheme;

        if (currentTheme == AppTheme.Light)
        {
            currentActivity.Window.SetStatusBarColor(new(255, 255, 255));
            currentActivity.Window.SetNavigationBarColor(new(245, 240, 234));
            currentActivity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
        }
        else
        {
            currentActivity.Window.SetStatusBarColor(new(0,0,0));
            currentActivity.Window.SetNavigationBarColor(new(0, 0, 0));
            currentActivity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.Visible;
        }
#endif
        }





    }
}
