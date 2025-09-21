#if ANDROID
using Android.Views;
using LIN.Allo.App.Platforms.Android.Services.Web;
#endif
using LIN.Access.Auth;
using LIN.Access.Communication;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Extensions.Logging;


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

#if ANDROID

            BlazorWebViewHandler.ViewMapper.AppendToMapping("Permissions", (handler, view) =>
            {
                // Cast correcto al WebView nativo de Android
                if (handler.PlatformView is Android.Webkit.WebView webView)
                {
                    webView.SetWebChromeClient(new PermissiveWebChromeClient());
                }
            });
#endif

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            LIN.Allo.Shared.Services.Scripts.Build();

            // Iniciar.
            builder.Services.AddCommunicationService();
            LIN.Access.Search.Build.Init();

            var app = builder.Build();

            var device = app.Services.GetService<DeviceOnAccountModel>();

            device.Name = DeviceInfo.Name;
            device.SurfaceFrom = "native";

#if ANDROID
            device.OperativeSystem = "android";
#elif WINDOWS
            device.OperativeSystem = "windows";
#endif
            return app;
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
                currentActivity.Window.SetStatusBarColor(new(0, 0, 0));
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
                currentActivity.Window.SetStatusBarColor(new(0, 0, 0));
                currentActivity.Window.SetNavigationBarColor(new(0, 0, 0));
                currentActivity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.Visible;
            }
#endif
        }





    }
}
