using LIN.Types.Auth.Enumerations;

namespace LIN.UI.Views;


public partial class AccountPage : ContentPage
{


    /// <summary>
    /// Lista de dispositivos
    /// </summary>
    private static List<DeviceModel> Devices { get; set; } = new();







    /// <summary>
    /// Constructor
    /// </summary>
    public AccountPage()
    {

        InitializeComponent();

        // Pagina actual
        AppShell.ActualPage = this;

        // Evento (Aparece esta pagina)
        Appearing += AccountPage_Appearing;

        // Eventos para el HUB
        AppShell.Hub.OnReceiveDevicesList += OnRecieveAll;
        AppShell.Hub.OnDeviceJoins += OnReceiveDevice;
        AppShell.Hub.OnDeviceLeaves += OnSomeoneLeave;

        // Muestra la información
        perfil.Source = ImageEncoder.Decode(Session.Instance.Account.Perfil);
        lbName.Text = Session.Instance. Account.Nombre;
        displayUser.Text = "@" + Session.Instance.Account.Usuario;

        // Insignias
        switch (Session.Instance.Account.Insignia)
        {

            case AccountBadges.Verified:
                displayInsignia.Show();
                displayInsignia.Source = ImageSource.FromFile("verificado.png");
                break;

            case AccountBadges.VerifiedGold:
                displayInsignia.Show();
                displayInsignia.Source = ImageSource.FromFile("verificadogold.png");
                break;

            default:
                displayInsignia.Hide();
                break;
        }

    }



   





















    #region Eventos



    /// <summary>
    /// Evento: Un dispositivo se deconecta
    /// </summary>
    private void OnSomeoneLeave(object? sender, string e)
    {
        Dispatcher.DispatchAsync(new Action(() =>
        {

            

        }));

    }



    /// <summary>
    /// Evento: Recibir un dispositivo
    /// </summary>
    private void OnReceiveDevice(object? sender, DeviceModel e)
    {
        Dispatcher.DispatchAsync(() =>
        {

            // Contador
            var models = Devices.Where(T => T.DeviceKey == e.DeviceKey).ToList();

            // Remplaza la informacion
            if (models.Count > 0)
            {
                models[0].BateryLevel = e.BateryLevel;
                models[0].BateryConected = e.BateryConected;
                models[0].Estado = e.Estado;
                models[0].ID = e.ID;
                models[0].Logitud = e.Logitud;
                models[0].Latitud = e.Latitud;
                return;
            }

            // Agrega el nuevo dispositivo a la lista
            Devices.Add(e);

            // Renderiza un modelo
            RenderDevice(e);

        });
    }



    /// <summary>
    /// Evento: Reciben todos los dispositivos
    /// </summary>
    private void OnRecieveAll(object? sender, List<DeviceModel> e)
    {
        Dispatcher.DispatchAsync(() =>
        {


        });
    }



    #endregion














    /// <summary>
    /// Evento: Alguien sale
    /// </summary>
    [Obsolete("Metodo obsoleto, Eliminar")]
    private void Hub_OnSomeoneLeave(object? sender, string e)
    {


    }



    /// <summary>
    /// Evento: Recibir un dispositivo
    /// </summary>
    [Obsolete("Metodo obsoleto, Eliminar")]
    private void Hub_OnReceiveDevice(object? sender, DeviceModel e)
    {
        Dispatcher.DispatchAsync(() =>
         {

             // Contador
             var models = Devices.Where(T => T.DeviceKey == e.DeviceKey).ToList();

             // Remplaza la informacion
             if (models.Count > 0)
             {
                 models[0].BateryLevel = e.BateryLevel;
                 models[0].BateryConected = e.BateryConected;
                 models[0].Estado = e.Estado;
                 models[0].ID = e.ID;
                 models[0].Logitud = e.Logitud;
                 models[0].Latitud = e.Latitud;
                 return;
             }

             // Agrega el nuevo dispositivo a la lista
             Devices.Add(e);

             // Renderiza un modelo
             RenderDevice(e);

         });
    }



    /// <summary>
    /// Cuando se obtienen los modelos
    /// </summary>
    [Obsolete("Metodo obsoleto, Eliminar")]
    private void Hub_OnRecieveAll(object? sender, List<DeviceModel> e)
    {
        Dispatcher.DispatchAsync(() =>
        {

            if (e.Count == Devices.Count)
            {
                e = e.OrderBy(T => T.Name).ToList();
                Devices = Devices.OrderBy(T => T.Name).ToList();

                bool ret = true;
                for (var i = 0; i < Devices.Count; i++)
                {
                    if (Devices[i] == e[i])
                        continue;
                    else
                    {
                        ret = false;
                        break;
                    }
                }
                if (ret)
                    return;

            }


            Devices = e;
            contenido.Clear();

            // Renderiza los controles
            Devices.Clear();
            RenderDevices(Devices);

        });
    }



    /// <summary>
    /// Pagina apareciendo
    /// </summary>
    bool rendering = false;
    private async void AccountPage_Appearing(object? sender, EventArgs e)
    {

        if (AppShell.Hub == null)
            return;

        AppShell.Hub.SendTest();
        AppShell.ActualPage = this;

        if (rendering)
            return;

        rendering = true;

      // var devices = await LIN.Access.Controllers.Devices.ReadAll(AppShell.Hub.ID, Session.Instance.Informacion.ID);


     //OnRecieveAll(this, devices.Models);

        rendering = false;

        AppShell.Hub.TestConnection();

    }





    private void RenderDevices(List<DeviceModel> modelos)
    {
        foreach (var model in modelos)
            RenderDevice(model);
    }


    private void RenderDevice(DeviceModel modelo)
    {
       
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {


    }

    private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
    {



    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {




    }

    private void Label_Clicked(object sender, EventArgs e)
    {

    }

    private void lbName_Clicked(object sender, EventArgs e)
    {

    }

    private async void LogOutEvent(object sender, EventArgs e)
    {
        Services.Login.Logout.Start();
    }

    private void Control_Clicked(object? sender, EventArgs e)
    {
      
    }
}