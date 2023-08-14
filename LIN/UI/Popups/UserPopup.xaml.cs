using LIN.Access.Inventory.Controllers;
using LIN.UI.Views;


namespace LIN.UI.Popups;


public partial class UserPopup : Popup
{

    /// <summary>
    /// Modelo
    /// </summary>
    public IntegrantDataModel Modelo { get; set; }



    /// <summary>
    /// Nuevo Popop de usuario
    /// </summary>
    /// <param name="modelo">Modelo del usuario</param>
    public UserPopup(IntegrantDataModel modelo)
    {
        InitializeComponent();
        this.Modelo = modelo;
        RenderModel();
    }



    /// <summary>
    /// Renderiza la informacion del modelo
    /// </summary>
    public void RenderModel()
    {
        // Info
        lbName.Text = Modelo.Nombre;
        lbUser.Text = "@" + Modelo.Usuario;

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


        switch (Modelo.Rol)
        {
            case InventoryRoles.Administrator:
                inpRol.SelectedIndex = 0;
                break;
            case InventoryRoles.Member:
                inpRol.SelectedIndex = 1;
                break;
            default:
                inpRol.SelectedIndex = 2;
                break;
        }

    }




























    private void Button_Clicked(object sender, EventArgs e)
    {
        this.Close();
    }

    private async void Save(object sender, EventArgs e)
    {


        InventoryRoles now;

        switch (inpRol.SelectedIndex)
        {

            case 0:
                now = InventoryRoles.Administrator;
                break;

            case 1:
                now = InventoryRoles.Member;
                break;

            case 2:
                now = InventoryRoles.Guest;
                break;

            default:
                now = InventoryRoles.Undefined;
                break;

        }


        if (now == Modelo.Rol)
        {
            Close("no");
            return;
        }


        Prepare();
        var res = await Inventories.UpdateRol(Modelo.AccessID, now, Session.Instance.Token);


        switch (res.Response)
        {
            case Responses.Success:
                this.Close(now);
                return;

            case Responses.Unauthorized:
                lbInfo.Text = "No tienes permisos";
                break;

            default:
                lbInfo.Text = "Hubo un error";
                break;
        }


        ShowAgain();

    }




    private void Prepare()
    {
        indicador.Show();
        lbName.Hide();
        lbUser.Hide();
        inpRol.Hide();
    }


    private void ShowAgain()
    {
        indicador.Hide();
        lbName.Show();
        lbUser.Show();
        inpRol.Show();
    }



    private void ToggleButton_Clicked(object sender, EventArgs e)
    {

    }

    private  void ToggleButton_Clicked_1(object sender, EventArgs e)
    {

    }
}