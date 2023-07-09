using CommunityToolkit.Maui.Core;
#if ANDROID
using Android.Views;
#endif


namespace LIN.UI.Views;


public partial class Login : ContentPage
{


    /// <summary>
    /// Base de datos local
    /// </summary>
    private readonly LocalDataBase.Data.UserDB Database;



    private bool IsByKey = false;


    /// <summary>
    /// Constructor
    /// </summary>
    public Login()
    {
        InitializeComponent();
        Appearing += Login_Appearing;
        Database = new();
        TryGo();
    }




    /// <summary>
    /// Constructor de error
    /// </summary>
    public Login(string messsage)
    {
        InitializeComponent();
        Database = new();
        lbInfo.Show();
        lbInfo.Text = messsage;
    }





    /// <summary>
    /// Trata de inicia sesion con datos anteriores
    /// </summary>
    private async void TryGo()
    {

        // Usuario
        var user = await Database.GetDefault();

        // Si no existe
        if (user == null)
        {
            return;
        }


        new LoginLoading(user.UserU, user.Password).ShowOnTop();
        this.Close();

    }






    private void Login_Appearing(object? sender, EventArgs e)
    {
#if ANDROID
        var currentActivity = Platform.CurrentActivity;

        if (currentActivity == null || currentActivity.Window == null)
            return;

        currentActivity.Window.SetStatusBarColor(new(247, 248, 253));
        currentActivity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
        //currentActivity.Window.SetTitleColor(new(0, 0, 0));
#endif
    }



    /// <summary>
    /// Evento cuando se escribe sobre los txts
    /// </summary>
    private void TxtChanged(object sender, TextChangedEventArgs e)
    {
        lbInfo.Hide();
    }



    /// <summary>
    /// Evento boton iniciar sesion
    /// </summary>
    private void BtnIniciar_Click(object sender, EventArgs e)
    {

        this.Close();

        if (IsByKey)
            new LoginLoading(txtUser.Text).ShowOnTop();
        else
            new LoginLoading(txtUser.Text, txtPass.Text).ShowOnTop();
        
    }


    /// <summary>
    /// Evento: No existe cuenta
    /// </summary>
    private void NotAccountEvent(object sender, EventArgs e)
    {

        new Singin().Show();
        this.Close();
    }


    private async void Snack()
    {

        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        string text = "This is a Toast";
        ToastDuration duration = ToastDuration.Short;
        double fontSize = 14;

        var toast = CommunityToolkit.Maui.Alerts.Toast.Make(text, duration, fontSize);

        await toast.Show(cancellationTokenSource.Token);
    }


    private void ToggleButton_Clicked(object sender, EventArgs e)
    {

        lbInfo.Hide();

        if (IsByKey)
            txtPass.Show();
        else
            txtPass.Hide();

        IsByKey = !IsByKey;


    }
}