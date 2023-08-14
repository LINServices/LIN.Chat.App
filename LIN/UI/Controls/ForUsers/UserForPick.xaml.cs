using LIN.Types.Auth.Abstracts;
using LIN.Types.Auth.Enumerations;

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
    public SessionModel<ProfileModel> Modelo { get; set; }


    public bool IsSelected { get; set; } = false;






    /// <summary>
    /// Constructor
    /// </summary>
    public UserForPick(SessionModel<ProfileModel> modelo)
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
        displayName.Text = Modelo.Account.Nombre;
        displayUser.Text = "@" + Modelo.Account.Usuario;

        // Si no hay imagen que mostar
        if (Modelo.Account.Perfil.Length == 0)
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
            img.Source = ImageEncoder.Decode(Modelo.Account.Perfil);
        }


        // Insignias
        switch (Modelo.Account.Insignia)
        {

            case AccountBadges.Verified:
                displayInsignia.Source = ImageSource.FromFile("verificado.png");
                break;

            case AccountBadges.VerifiedGold:
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