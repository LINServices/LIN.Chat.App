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

        // Llamada
        Actions.Add("call", (param) =>
        {
            if (PhoneDialer.Default.IsSupported)
                PhoneDialer.Default.Open(param);
        });


        // Abrir Producto
        Actions.Add("openPr", async (param) =>
        {
            // Convierte el valor
            bool can = int.TryParse(param, out int id);

            if (!can)
                return;

            var model = await Access.Controllers.Product.Read(id);

            var form = new UI.Views.Products.ViewItem(model.Model);

            form.Show();
        });


        // Abrir Contactos
        Actions.Add("openCt", async (param) =>
        {

            // Convierte el valor
            bool can = int.TryParse(param, out int id);

            if (!can)
                return;

            var model = await Access.Controllers.Contact.Read(id);


            var pop = new UI.Popups.ContactPopup(model.Model);

            await pop.Show();

        });


        // Abrir Exportar PDF (Entradas)
        Actions.Add("exportInflow", async (param) =>
        {

            // Convierte el valor
            bool can = int.TryParse(param, out int id);

            if (!can)
                return;


            var model = await Access.Controllers.Inflows.Read(id);
            var form = new UI.Views.Inflows.ViewItem(model.Model, true);

            form.Show();

        });


        // Abrir Exportar PDF (Salidas)
        Actions.Add("exportOutflow", async (param) =>
        {

            // Convierte el valor
            bool can = int.TryParse(param, out int id);

            if (!can)
                return;


            var model = await Access.Controllers.Outflows.Read(id);
            var form = new UI.Views.Outflows.ViewItem(model.Model, true);

            form.Show();

        });


        // Abrir Entrada
        Actions.Add("openIF", async (param) =>
        {

            // Convierte el valor
            bool can = int.TryParse(param, out int id);

            if (!can)
                return;

            var model = await Access.Controllers.Inflows.Read(id);

            var form = new UI.Views.Inflows.ViewItem(model.Model);

            form.Show();

        });


        // Abrir Salida
        Actions.Add("openOF", async (param) =>
        {

            // Convierte el valor
            bool can = int.TryParse(param, out int id);

            if (!can)
                return;

            var model = await Access.Controllers.Outflows.Read(id);

            var form = new UI.Views.Outflows.ViewItem(model.Model);

            form.Show();

        });


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
