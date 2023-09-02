
namespace LIN.ScriptRuntime;


internal class Scripts
{

    /// <summary>
    /// Funciones
    /// </summary>
    public static Dictionary<string, Action<string>> Actions { get; set; } = new Dictionary<string, Action<string>>();



    /// <summary>
    /// Construye las funciones
    /// </summary>
    public static void Build()
    {

       

        // Mensaje
        Actions.Add("msg", async (param) =>
        {
            try
            {

                if (AppShell.ActualPage == null)
                    return;

                await AppShell.ActualPage.DisplayAlert("Mensaje", param ?? "", "OK");
            }
            catch
            {

            }
        });


        // Cerrar Sesión
        Actions.Add("disconnect", (param) =>
        {
            Services.Login.Logout.Start();
        });


       

    }


}
