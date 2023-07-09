namespace LIN.UI.Controls;

public partial class Integrant : Grid
{

    //======== Eventos =========//

    public event EventHandler<EventArgs>? Clicked;

    public event EventHandler<EventArgs>? OnDelete;

    public event EventHandler<EventArgs>? OnRolClick;



    //======== Propiedades =========//

    /// <summary>
    /// Modelo
    /// </summary>
    public LIN.Shared.Models.IntegrantDataModel Modelo { get; set; }


    /// <summary>
    /// Inventario
    /// </summary>
    private int Inventario { get; set; }


    /// <summary>
    /// Rol
    /// </summary>
    private InventoryRols AccountRol { get; set; }




    /// <summary>
    /// Constructor
    /// </summary>
    public Integrant(LIN.Shared.Models.IntegrantDataModel modelo, InventoryRols accountRol, int inventario)
    {
        InitializeComponent();
        this.AccountRol = accountRol;
        this.Modelo = modelo;
        this.Inventario = inventario;
        LoadModelVisible();
    }




    /// <summary>
    /// Renderiza el modelo
    /// </summary>
    public void LoadModelVisible()
    {

        // Metadatos
        lbName.Text = Modelo.Nombre;
        lbMail.Text = "@" + Modelo.Usuario;
        displayRol.Text = Modelo.Rol.Humanize();


        // Permisos para eliminar
        if (AccountRol == InventoryRols.Administrator)
        {
            btnDelete.Show();
        }
        else
        {
            btnDelete.Hide();
        }



        // Si no hay imagen que mostar
        if (Modelo.Perfil.Length == 0)
        {
            img.Hide();
            lbPic.Show();
            lbPic.Text = lbName.Text[0].ToString().ToUpper();
            bgImg.BackgroundColor = Services.RandomColor.GetRandomColor();
        }
        else
        {
            lbPic.Hide();
            img.Show();
            bgImg.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent;
            img.Source = ImageEncoder.Decode(Modelo.Perfil);
        }

    }







    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, new());
    }

    private void ClickRol(object sender, EventArgs e)
    {
        OnRolClick?.Invoke(this, new());
    }

    private async void btnDelete_Clicked(object sender, EventArgs e)
    {
        OnDelete?.Invoke(this, new());
    }
}