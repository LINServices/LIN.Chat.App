global using CommunityToolkit.Maui.Animations;
using LIN.Controls.Handlers;
using Microsoft.Maui.Platform;

namespace LIN.Controls;

public static class Builder
{


    public static MauiAppBuilder UseCustomControls(this MauiAppBuilder builder)
    {




        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
        {
            if (view is BorderlessEntry)
            {
#if __ANDROID__

                handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif __IOS__
              handler  .PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
                handler.PlatformView.FocusVisualPrimaryBrush = new Microsoft.UI.Xaml.Media.SolidColorBrush(Windows.UI.Color.FromArgb(100, 81, 43, 212));
                handler.PlatformView.FocusVisualSecondaryBrush = new Microsoft.UI.Xaml.Media.SolidColorBrush(Windows.UI.Color.FromArgb(100, 81, 43, 212));
#endif
            }
        });


        return builder;
    }
}
