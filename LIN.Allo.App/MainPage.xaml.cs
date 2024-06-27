namespace LIN.Allo.App
{
    public partial class MainPage : ContentPage
    {


        public static Action OnColorRequest = () => OnColorRequestDefault();

        public static Action OnColorRequestDefault = () => MauiProgram.LoadColor();


        /// <summary>
        /// Nueva mainPage.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            Application.Current.RequestedThemeChanged += (s, a) => OnColorRequest();
        }

        /// <summary>
        /// Evento al abrir la app.
        /// </summary>
        protected override void OnAppearing()
        {
            // Establecer colores.
            OnColorRequest();
            base.OnAppearing();
        }

    }
}
