using LIN.UI.Views;

namespace LIN.Services.Login;

internal class Logout
{


    public async static void Start()
    {
       
        MauiProgram.DeviceSesionKey = Shared.Tools.KeyGen.Generate(20, "dv.");
        await new LocalDataBase.Data.UserDB().DeleteUsers();
        Sesion.CloseSesion();
        await UI.Views.AppShell.Hub.CloseSesion();
        AppShell.Hub = null;
        AppShell.Instance = null;
        new UI.Views.Login().ShowOnTop();

    }


}
