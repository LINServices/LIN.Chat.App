using LIN.Shared.Responses;

namespace LIN.Services.Login;


internal class LoginCredentials : ILoginStrategy
{


    readonly Action OnWaiting;


    public LoginCredentials(Action onWaiting)
    {
        this.OnWaiting = onWaiting;
    }

    public void Dispose()
    {
        
    }



    public async Task<(string message, bool can)> Login(string username, string? password)
    {

         OnWaiting();

        // Campos vacíos
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            return ("Por favor, asegúrate de llenar todos los campos requeridos.", false);

        // Connection a internet
        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            return ("No hay conexión a internet", false);

       

        // Plataforma
        Platforms platform = MauiProgram.GetPlatform();

        // Inicio de sesion
        var (_, response) = await Sesion.LoginWith(username, password, platform);


        // Evaluacion
        switch (response)
        {
            // Ok
            case Responses.Success:
                {
                    await new LocalDataBase.Data.UserDB().SaveUser(new() { ID = 0, UserU = username, Password = password });
                    return ("", true);
                }

            // No existe el usuario
            case Responses.NotExistAccount:
                return ("No existe este usuario", false);

            // No existe el usuario
            case Responses.InvalidPassword:
                return ("Contraseña incorrecta", false);

            // No existe el usuario
            case Responses.NotConnection:
                return ("No hay conexión", false);

            // Hubo un error grave
            default:
                return ("Inténtalo mas tarde", false);

        }

    }



}
