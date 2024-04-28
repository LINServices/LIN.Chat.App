namespace LIN.Allo.App;


public partial class MainPage : ContentPage
{


    public static Action OnColorRequest = () => OnColorRequestDefault();

    public static Action OnColorRequestDefault = () => MauiProgram.LoadColor();


    public MainPage()
    {
        InitializeComponent();

        Application.Current.RequestedThemeChanged += (s, a) => OnColorRequest();
    }
}
