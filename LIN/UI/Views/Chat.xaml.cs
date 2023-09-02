namespace LIN.UI.Views;


public partial class Chat : ContentPage
{

    /// <summary>
    /// Estancia del HUB de Chat
    /// </summary>
   //private Hub? Hub = null;


    /// <summary>
    /// Nombre del grupo
    /// </summary>
    private string Group { get; set; }


    /// <summary>
    /// Constructor
    /// </summary>
    public Chat(string group = "A1")
    {
        InitializeComponent();

        this.Group = group;

        StarHub();

    }



    /// <summary>
    /// Inicia la conexion del Hub
    /// </summary>
    public async void StarHub()
    {
        //// Nuevo Hub
        //Hub = new();

        //// Respuesta de conexion
        //var res = await Hub.Suscribe();

        //// Evaluacion
        //if (!res)
        //{
        //    await this.DisplayAlert("Error", "Hubo un error al conectar", "Ok");
        //    return;
        //}

        //// Unir al grupo
        //Hub.JoinTo(Group);

        //// Suscribir eventos
        //Hub.OnRecieveMessage += Hub_OnRecieveMessage;
        //Hub.OnRecievePicture += Hub_OnRecievePicture;
        //Hub.OnRecieveLocation += Hub_OnRecieveLocation;
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
        return false;
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

      catch (Exception ex) {

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

        //if (EvaluateConexion() || mensajeEntry.Text == null || mensajeEntry.Text.Length <= 0)
        //    return;

        //// Envia el mensaje
        //Hub!.SendMessage(mensajeEntry.Text, Group);
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