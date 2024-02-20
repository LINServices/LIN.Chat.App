global using LIN.Allo.App.Components.Pages;
global using LIN.Allo.App.Components.Sections;
global using LIN.Allo.App.Components.Shared;
global using LIN.Allo.App.Elements.Drawers;
global using LIN.Types.Cloud.Identity.Abstracts;
global using LIN.Types.Cloud.Identity.Enumerations;
global using LIN.Types.Cloud.Identity.Models;
global using LIN.Types.Communication.Models;
global using LIN.Types.Responses;
global using Microsoft.AspNetCore.Components;
global using Microsoft.JSInterop;
using Microsoft.Extensions.Logging;

#if ANDROID
using Android.Views;
#endif

namespace LIN.Allo.App
{
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            LIN.Access.Auth.Build.Init();
            LIN.Access.Communication.Build.Init();


            return builder.Build();
        }









        public static void Aa()
        {
#if ANDROID
            var currentActivity = Platform.CurrentActivity;

            if (currentActivity == null || currentActivity.Window == null)
                return;

            var currentTheme = AppInfo.RequestedTheme;

            if (currentTheme == AppTheme.Light)
            {
                currentActivity.Window.SetStatusBarColor(new(247, 248, 253));
                currentActivity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
            }
            else
            {
                currentActivity.Window.SetStatusBarColor(new(0, 0, 0));
                currentActivity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
            }


            //currentActivity.Window.SetTitleColor(new(0, 0, 0));
#endif
        }




    }
}
