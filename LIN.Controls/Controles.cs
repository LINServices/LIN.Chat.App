namespace LIN.Controls;


public static class VisualElementExtensions
{








    public static async void AnimateRight(this VisualElement context, bool hide = false)
    {
        // distance to right edge
        var rightDist = (DeviceDisplay.MainDisplayInfo.Width - context.X) / DeviceDisplay.MainDisplayInfo.Density;

        await Task.WhenAll(
            context.TranslateTo(rightDist, 0, 1000, easing: Easing.CubicInOut),
            context.ScaleTo(0.4, 1000, easing: Easing.CubicInOut)
        );

        context.TranslationX = rightDist * -1;

        if (hide)
            context.Hide();

    }







    /// <summary>
    /// Muestra el control
    /// </summary>
    public static void Show(this VisualElement context)
    {
        try
        {
            context.Dispatcher.DispatchAsync(() =>
            {
                context.IsVisible = true;
            });
        }
        catch
        {
        }
    }



    /// <summary>
    /// Oculta el control
    /// </summary>
    public static void Hide(this VisualElement context)
    {
        try
        {
            context.Dispatcher.DispatchAsync(() =>
            {
                context.IsVisible = false;
            });
        }
        catch
        {
        }
    }


}
