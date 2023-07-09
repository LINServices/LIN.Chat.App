namespace LIN.UI.Controls.Others;

public partial class ProductDetailMobile : Grid
{


    /// <summary>
    /// Model del detalle
    /// </summary>
    public LIN.Shared.Models.ProductDataTransfer Detalle { get; set; } = new();



    /// <summary>
    /// Constructor
    /// </summary>
    public ProductDetailMobile(LIN.Shared.Models.ProductDataTransfer detalle)
    {
        InitializeComponent();
        this.Detalle = detalle;
        LoadModel();
    }




    /// <summary>
    /// Carga el modelo a la vista
    /// </summary>
    private async void LoadModel()
    {

        // Obtiene el contacto
        var contact = LIN.Access.Controllers.Contact.Read(Detalle.Provider);

        // Muestra el modelo
        displayCompra.Contenido = $"${Detalle.PrecioCompra}";
        displayVenta.Contenido = $"${Detalle.PrecioVenta}";
        displayCantidad.Text = Detalle.Quantity.ToString();


        // Muesta el contacto
        displayContacto.Modelo = (await contact).Model;
        displayContacto.LoadModelVisible();

        // Pone los colores adecuados
        SetImageAndColors();

        // Muestra las estadisticas
        var (porcent, ganancia) = Calculate();
        lbPorcent.Text += $"{porcent}%";
        lbGanancias.Text = $"${ganancia}";

    }



    /// <summary>
    /// Calcula el porcentaje de ganacia / perdida
    /// </summary>
    private (decimal porcent, decimal ganancia) Calculate()
    {

        try
        {
            // Ganancia o perdida neta
            decimal neto = Detalle.PrecioVenta - Detalle.PrecioCompra;

            // Porcentaje
            decimal percent = Math.Round((neto / Detalle.PrecioCompra) * 100, 2);

            // Retorna
            return (percent, neto * Detalle.Quantity);
        }
        catch 
        {
            return (0m, 0m);
        }


    }



    /// <summary>
    /// Pone las imagenes y colores
    /// </summary>
    private void SetImageAndColors()
    {

        // Si el precio de venta supera al de compra
        if (Detalle.PrecioVenta > Detalle.PrecioCompra)
        {
            img.Source = ImageSource.FromFile("subir.png");
            lbPorcent.Text = "+ ";
            lbPorcent.TextColor = new(80, 175, 0);
        }

        // Si el precio de venta es igual al de compra
        else if (Detalle.PrecioVenta == Detalle.PrecioCompra)
        {

            img.Source = ImageSource.FromFile("menos.png");
            lbPorcent.Text = "";
            lbPorcent.TextColor = new(243, 156, 18);
        }

        // Si el precio de venta es menor al de compra
        else if (Detalle.PrecioVenta < Detalle.PrecioCompra)
        {
            img.Source = ImageSource.FromFile("bajar.png");
            lbPorcent.TextColor = new(234, 67, 53);
        }

    }




}