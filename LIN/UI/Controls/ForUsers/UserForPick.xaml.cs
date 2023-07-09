namespace LIN.UI.Controls;

public partial class UserForPick : Grid
{


    //========= Eventos =========//

    /// <summary>
    /// Evento Click sonbre el control
    /// </summary>
    public event EventHandler<EventArgs>? Clicked;



    //========= Propiedades =========//

    /// <summary>
    /// Model del contacto
    /// </summary>
    public LIN.Shared.Models.UserDataModel Modelo { get; set; }


    public bool IsSelected { get; set; } = false;






    /// <summary>
    /// Constructor
    /// </summary>
    public UserForPick(LIN.Shared.Models.UserDataModel modelo)
    {
        InitializeComponent();
        this.Modelo = modelo;
        //    ContactSubscriber.Suscribe(this);
        LoadModelVisible();
    }



    /// <summary>
    /// Muestra los datos del contacto en el display
    /// </summary>
    public void LoadModelVisible()
    {

        // Datos
        displayName.Text = Modelo.Nombre;
        displayUser.Text = "@" + Modelo.Usuario;

        // Si no hay imagen que mostar
        if (Modelo.Perfil.Length == 0)
        {
            img.Hide();
            lbPic.Show();
            lbPic.Text = displayName.Text[0].ToString().ToUpper();
            bgImg.BackgroundColor = Services.RandomColor.GetRandomColor();
        }
        else
        {
            lbPic.Hide();
            img.Show();
            bgImg.BackgroundColor = Microsoft.Maui.Graphics.Colors.Transparent;
            img.Source = ImageEncoder.Decode(Modelo.Perfil);
        }


        // Insignias
        switch (Modelo.Insignia)
        {

            case Insignias.Verified:
                displayInsignia.Source = ImageSource.FromFile("verificado.png");
                break;

            case Insignias.VerifiedGold:
                displayInsignia.Source = ImageSource.FromFile("verificadogold.png");
                break;

            default:
                displayInsignia.Hide();
                break;
        }




    }





    public void Select()
    {
        bg.Stroke = Microsoft.Maui.Graphics.Colors.RoyalBlue;
        IsSelected = true;
    }

    public void UnSelect()
    {
        bg.Stroke = Color.FromArgb("#e5e7eb");
        IsSelected = false;
    }


    /// <summary>
    /// Submit del evento click
    /// </summary>
    private void EventoClick(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, new());
    }


}