namespace LIN.UI.Controls;

public partial class Outflow : Grid
{


    /// <summary>
    /// Evento click del control
    /// </summary>
    public event EventHandler<EventArgs>? Clicked;



    /// <summary>
    /// Modelo del producto
    /// </summary>
    public Shared.Models.OutflowDataModel Modelo { get; set; }




    /// <summary>
    /// Constructor
    /// </summary>
    public Outflow(LIN.Shared.Models.OutflowDataModel modelo)
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


        switch (Modelo.Type)
        {
            case OutflowsTypes.Venta:
                imgTipo.Source = ImageSource.FromFile("venta.png");
                displayTipo.Text = "Venta";
                break;

            case OutflowsTypes.Caducidad:
                imgTipo.Source = ImageSource.FromFile("caducidad.png");
                displayTipo.Text = "Caducidad";
                break;

            case OutflowsTypes.Perdida:
                imgTipo.Source = ImageSource.FromFile("perdida.png");
                displayTipo.Text = "Perdida";
                break;

            case OutflowsTypes.Fraude:
                imgTipo.Source = ImageSource.FromFile("fraude.png");
                displayTipo.Text = "Fraude";
                break;

            case OutflowsTypes.Donacion:
                imgTipo.Source = ImageSource.FromFile("donacion.png");
                displayTipo.Text = "Donacion";
                break;

            case OutflowsTypes.Consumo:
                imgTipo.Source = ImageSource.FromFile("consumo.png");
                displayTipo.Text = "Consumo interno";
                break;

            default:
                imgTipo.Source = ImageSource.FromFile("venta.png");
                displayTipo.Text = "Salida";
                break;
        }


        displayQuant.Text = $"{Modelo.CountDetails} elementos";


    }



    /// <summary>
    /// Envua el evento click
    /// </summary>
    private void SendEventClick(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, new());
    }


}