namespace LIN.UI.Views;


public partial class Chat : ContentPage
{


    private readonly LocalDataBase.Data.MessagesDB LocalDB;




    private ChatHub? Hub = null;

    ConversationModel conversation = new();

    bool IsLoadOldChats = false;


    /// <summary>
    /// Constructor
    /// </summary>
    public Chat(ConversationModel conversation, ChatHub? hub)
    {

        LocalDB = new();
        InitializeComponent();

        this.conversation = conversation;
        this.Hub = hub;

        StarHub();

        GetOld();

    }



    private async void GetOld()
    {

        // Obtener los mensajes guardados
        var oldSaved = await LocalDB.Get(conversation.ID);

        // Ultimo ID
        int lastID = oldSaved.LastOrDefault()?.ID ?? 0;


        var olds = await LIN.Access.Communication.Controllers.Messages.ReadAll(conversation.ID, lastID);

        foreach (var m in olds.Models)
        {
            await LocalDB.Save(m);
        }


        oldSaved.AddRange(olds.Models);

        foreach (var m in oldSaved)
        {
            var cl = new Controls.ChatControl(m.Remitente, m.Contenido);
            chats.Add(cl);
        }

        await Task.Delay(10);
        _ = scroll.ScrollToAsync(0, scroll.Content.Height, true);
    }



    /// <summary>
    /// Inicia la conexion del Hub
    /// </summary>
    public async void StarHub()
    {

        if (Hub == null)
            return;



        Hub.JoinGroup(conversation.ID.ToString(), (e) =>
        {
            this.Dispatcher.DispatchAsync(async () =>
            {
                chats.Add(new Controls.ChatControl(e.Remitente, e.Contenido));
                await Task.Delay(100);
                await scroll.ScrollToAsync(0, scroll.Content.Height + 100, true);
            });


        });

    }




    /// <summary>
    /// Evento Mensaje
    /// </summary>
    private void Hub_OnRecieveMessage(object? sender, string e)
    {
        this.Dispatcher.DispatchAsync(() =>
        {
            RenderMessage(e);
        });
    }


    /// <summary>
    /// Evento Mensaje
    /// </summary>
    private void Hub_OnRecievePicture(object? sender, byte[] e)
    {
        this.Dispatcher.DispatchAsync(() =>
        {
            RenderPicture(e);
        });
    }


    /// <summary>
    /// Evento Mensaje
    /// </summary>
    private void Hub_OnRecieveLocation(object? sender, string e)
    {
        this.Dispatcher.DispatchAsync(() =>
        {
            RenderUbicacion(e);
        });
    }



    /// <summary>
    /// Evalua la conexion con el Hub
    /// </summary>
    private bool EvaluateConexion()
    {
        //return Hub == null;
        return true;
    }



    private async void OpenImage(object sender, EventArgs e)
    {

        try
        {
            // Carga el archivo
            var result = await FilePicker.Default.PickAsync();

            // analisa el resultado
            if (result == null)
                return;


            // Extension del archivo
            if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) || result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
            {

                FileInfo dd = new(result.FullPath);
                var stream = dd.OpenRead();

                MemoryStream ms = new();
                stream.CopyTo(ms);
                var bytes = ms.ToArray();

                //        Hub.SendPicture(bytes, Group);

                RenderPicture(bytes);
            }
            else
            {
                await DisplayAlert("Error", "Formato de imagen invalido", "OK");
            }

        }

        catch (Exception ex)
        {

            var s = ex;
        }

    }



    #region Renderizados


    /// <summary>
    /// Renderiza un mensaje
    /// </summary>
    /// <param name="message">Mensaje</param>
    public void RenderMessage(string message)
    {

        //Controles.Chat mensajeLabel = new(message);

        //chatLayout.Add(mensajeLabel);
        scroll.ScrollToAsync(0, scroll.Content.Height, true);

    }



    /// <summary>
    /// Renderiza una ubicacion
    /// </summary>
    /// <param name="ubicacion">Coordenadas</param>
    public void RenderUbicacion(string ubicacion)
    {

        //var lon =  double.Parse( ubicacion.Split('|')[0].Replace('.', ','));
        //  var lat = double.Parse( ubicacion.Split('|')[1].Replace('.',','));

        //  var mapa = new Controles.Map(lon, lat)
        //  {
        //      HeightRequest = 300,
        //      WidthRequest = 300
        //  };

        //  chatLayout.Add(mapa);

    }



    /// <summary>
    /// Renderiza una imagen
    /// </summary>
    /// <param name="picture">imagen</param>
    public void RenderPicture(byte[] picture)
    {
        //var control = new Controles.Imagen(Convert.ToBase64String(picture));
        // chatLayout.Add(control);
        scroll.ScrollToAsync(0, scroll.Content.Height, true);
    }



    #endregion



    #region Disparadores


    /// <summary>
    /// Enviar mensaje
    /// </summary>
    public void SendMensaje(object sender, EventArgs e)
    {

        if (mensajeEntry.Text == null || mensajeEntry.Text.Trim().Length <= 0)
            return;

        Hub!.SendMessage(Session.Instance.Informacion.ID, conversation.ID.ToString(), mensajeEntry.Text);
        //mensajeEntry.Text = string.Empty;


    }


    /// <summary>
    /// Enviar mensaje
    /// </summary>
    public async void SendLocation(object sender, EventArgs e)
    {

        //if (EvaluateConexion())
        //    return;

        //var ubicacion = await Servicios.gps.GetLocation();

        //// Envia el mensaje
        //Hub!.SendLocation($"{ubicacion.Longitude}|{ubicacion.Latitude}", Group);
        //mensajeEntry.Text = string.Empty;

    }


    #endregion














    public async void pruebaGPS(object sender, EventArgs e)
    {
        //var ubicacion = await Servicios.gps.GetLocation();

        //var mapa = new Controles.Map(ubicacion.Longitude, ubicacion.Latitude)
        //{
        //    HeightRequest = 300,
        //    WidthRequest = 300
        //};

        //chatLayout.Add(mapa);
    }


}