using LIN.Services.Login;
#if ANDROID
using Android.Views;
#endif

namespace LIN.UI.Views;


public partial class LoginLoading : ContentPage
{


    /// <summary>
    /// Usuario
    /// </summary>
    private readonly string User = string.Empty;


    /// <summary>
    /// Contrase�a
    /// </summary>
    private readonly string Password = string.Empty;


    /// <summary>
    /// Contrase�a
    /// </summary>
    private readonly bool IsPasskeySesion = false;




    private bool IsCompleted = false;




    /// <summary>
    /// Constructor primario
    /// </summary>
    private LoginLoading(string user, string pass, bool isPasskeySesion)
    {
        InitializeComponent();

        // Evento
        Appearing += Login_Appearing;

        // Variables
        this.User = user;
        this.Password = pass;
        this.IsPasskeySesion = isPasskeySesion;

        // Inicia la sesion
        Iniciar();
    }



    /// <summary>
    /// Constructor PassKey
    /// </summary>
    public LoginLoading(string user) : this(user, string.Empty, true) { }



    /// <summary>
    /// Constructor con credenciales
    /// </summary>
    public LoginLoading(string user, string pass) : this(user, pass, false) { }




    /// <summary>
    /// Evento (Pagina aparece)
    /// </summary>
    private void Login_Appearing(object? sender, EventArgs e)
    {
#if ANDROID
        var currentActivity = Platform.CurrentActivity;
        currentActivity.Window.SetStatusBarColor(new(247, 248, 253));
        currentActivity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
        //currentActivity.Window.SetTitleColor(new(0, 0, 0));
#endif
    }




    /// <summary>
    /// Iniciar sesion
    /// </summary>
    public async void Iniciar()
    {

        // Seleccion de la estrategia
        ILoginStrategy loginStrategy = IsPasskeySesion
                                     ? new LoginPasskey(MessageWait, RecievePasskeyResponse)
                                     : new LoginCredentials(MessageStart);


        // Respuesta
        var (message, can) = await loginStrategy.Login(User, Password);

        loginStrategy.Dispose();

        // Respuesta erronea
        if (!can)
        {
            await Dispatcher.DispatchAsync(() =>
            {
                if (!IsCompleted)
                {
                    new Login(message).ShowOnTop();
                    this.Close();
                }
            });

            return;
        }


        if (!IsCompleted)
        {
            // Abre la nueva ventana
            App.Current!.MainPage = new AppShell();
            this.Close();
        }



    }



    /// <summary>
    /// Mensaje de espera
    /// </summary>
    private async void MessageWait()
    {
        await Dispatcher.DispatchAsync(() =>
        {
            lbMessage.Text = "Revisa tu";
            lbMessageBlue.Text = "Dispositivo";
        });

        await Task.Delay(5);
    }



    /// <summary>
    /// Mensaje de Iniciando
    /// </summary>
    private async void MessageStart()
    {
        await this.Dispatcher.DispatchAsync(() =>
        {
            lbMessage.Text = "Iniciando";
            lbMessageBlue.Text = "Sesi�n";
        });

        await Task.Delay(5);
    }



    // <summary>
    // Recibe respuesta de Passkey
    // </summary>
    private void RecievePasskeyResponse(object? sender, PassKeyModel e)
    {
        Dispatcher.DispatchAsync(async () =>
        {

            IsCompleted = true;

            // Estado
            switch (e.Status)
            {
                case PassKeyStatus.Success:
                    break;

                case PassKeyStatus.Rejected:
                    new Login("Sesi�n de passkey rechazada").ShowOnTop();
                    this.Close();
                    return;

                case PassKeyStatus.Expired:
                    new Login("La sesi�n expiro").ShowOnTop();
                    this.Close();
                    return;

                case PassKeyStatus.BlockedByOrg:
                    new Login("Tu organizaci�n no permite que inicies en esta app.").ShowOnTop();
                    this.Close();
                    return;

                default:
                    new Login("Hubo un error en Passkey").ShowOnTop();
                    this.Close();
                    return;
            }

            MessageStart();

            await Task.Delay(10);
            await Task.Delay(10);


            // Inicio de sesion
            var login = await Session.LoginWith(e.Token);


            if (login.Response == Responses.Success)
            {
                // Abre la nueva ventana
                App.Current!.MainPage = new AppShell();
                this.Close();
            }

            else if (login.Response == Responses.InvalidPassword)
            {
                new Login("La sesi�n expiro").ShowOnTop();
                this.Close();
            }
            else if (login.Response == Responses.NotExistAccount)
            {
                new Login("No existe este usuario").ShowOnTop();
                this.Close();
            }
            else
            {
                new Login("Int�ntalo mas tarde").ShowOnTop();
                this.Close();
            }
        });
    }



}