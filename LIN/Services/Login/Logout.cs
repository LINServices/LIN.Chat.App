namespace LIN.Services.Login;

internal class Logout
{


    public async static void Start()
    {
        try
        {
            MauiProgram.DeviceSesionKey = Shared.Tools.KeyGen.Generate(20, "dv.");
            await new LocalDataBase.Data.UserDB().DeleteUsers();
            Sesion.CloseSesion();
            if (AppShell.Hub != null)
                await UI.Views.AppShell.Hub?.CloseSesion();
            AppShell.Hub = null;
            AppShell.Instance = null;
        }
        catch
        {

        }

        new UI.Views.Login().ShowOnTop();

    }


}
