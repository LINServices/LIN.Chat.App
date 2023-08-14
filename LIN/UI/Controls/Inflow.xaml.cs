namespace LIN.UI.Controls;

public partial class Inflow : Grid
{


    /// <summary>
    /// Evento click del control
    /// </summary>
    public event EventHandler<EventArgs>? Clicked;



    /// <summary>
    /// Modelo del producto
    /// </summary>
    public InflowDataModel Modelo { get; set; }




    /// <summary>
    /// Constructor
    /// </summary>
    public Inflow(InflowDataModel modelo)
    {
        InitializeComponent();
        this.Modelo = modelo;
        // ProductSubscriber.Suscribe(this);
        LoadModelVisible();
    }




    /// <summary>
    /// Hace el modelo visible a la UI
    /// </summary>
    public async void LoadModelVisible()
    {

        // Imagen
        if (Modelo.Type == InflowsTypes.Compra)
        {
            imgTipo.Source = ImageSource.FromFile("compra.png");
            displayTipo.Text = "Compra";
        }

        else if (Modelo.Type == InflowsTypes.Regalo)
        {
            imgTipo.Source = ImageSource.FromFile("regalo.png");
            displayTipo.Text = "Regalo";
        }

        else if (Modelo.Type == InflowsTypes.Devolucion)
        {
            imgTipo.Source = ImageSource.FromFile("devolucion.png");
            displayTipo.Text = "Devolucion";
        }

        else if (Modelo.Type == InflowsTypes.Ajuste)
        {
            imgTipo.Source = ImageSource.FromFile("tuerca.png");
            displayTipo.Text = "Ajuste";
        }


        displayQuant.Text =  $"{Modelo.CountDetails} elementos";

    }



    /// <summary>
    /// Envua el evento click
    /// </summary>
    private void SendEventClick(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, new());
    }


}