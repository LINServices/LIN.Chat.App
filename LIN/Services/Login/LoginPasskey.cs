namespace LIN.Services.Login;

internal class LoginPasskey //: //ILoginStrategy
{

    //Action OnWaiting;

    //Action<object?, PasskeyIntentDataModel> OnRecieve;


    //bool isDispose = false;

    //private Access.Hubs.PasskeyHub? Hub = null;

    //public LoginPasskey(Action onWaiting, Action<object?, PasskeyIntentDataModel> onRecieve)
    //{
    //    this.OnWaiting = onWaiting;
    //    this.OnRecieve = onRecieve;
    //}

    //public void Dispose()
    //{
    //    Hub?.Disconet();
    //    Hub = null;
    //    isDispose = true;
    //}


    //public async Task<(string message, bool can)> Login(string username, string? val)
    //{
    //    try
    //    {
    //        // Campos vacíos
    //        if (string.IsNullOrEmpty(username))
    //            return ("Por favor, asegúrate de llenar todos los campos requeridos.", false);

    //        // Connection a internet
    //        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
    //            return ("No hay conexión a internet", false);

    //        // Ejecucion de OnWaiting
    //        OnWaiting();

    //        Hub = new LIN.Access.Hubs.PasskeyHub(username);
    //        await Hub.Suscribe();


    //        Hub.OnRecieveResponse += Hub_OnRecieveResponse;

    //        var intent = new PasskeyIntentDataModel()
    //        {
    //            ApplicationName = "Inventario LIN for Windows",
    //            User = username
    //        };

    //        Hub?.SendIntent(intent);


    //        await Task.Delay(30000);

    //        Hub?.Disconet();
    //        Hub = null;

    //        return ("La sesión expiro", isDispose);

    //    }
    //    catch (Exception ex)
    //    {
    //        System.Diagnostics.Debug.WriteLine(ex);
    //    }

    //    return ("Hubo un error", false);

    //}



    //private void Hub_OnRecieveResponse(object? sender, PasskeyIntentDataModel e)
    //{
    //    Dispose();
    //    OnRecieve(sender, e);
    //}

}
