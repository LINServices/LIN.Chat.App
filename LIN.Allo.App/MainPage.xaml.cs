namespace LIN.Allo.App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Application.Current.RequestedThemeChanged += (s, a) =>
            {
                MauiProgram.LoadColor();
            };
        }
    }
}
