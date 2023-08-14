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
            case InventoryRols.Administrator:
                inpRol.SelectedIndex = 0;
                break;
            case InventoryRols.Member:
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


        InventoryRols now;

        switch (inpRol.SelectedIndex)
        {

            case 0:
                now = InventoryRols.Administrator;
                break;

            case 1:
                now = InventoryRols.Member;
                break;

            case 2:
                now = InventoryRols.Guest;
                break;

            default:
                now = InventoryRols.Undefined;
                break;

        }


        if (now == Modelo.Rol)
        {
            Close("no");
            return;
        }


        Prepare();
        var res = await Inventories.UpdateRol(Modelo.AccessID, now, Sesion.Instance.Token);


        switch (res.Response)
        {
            case Shared.Responses.Responses.Success:
                this.Close(now);
                return;

            case Shared.Responses.Responses.DontHavePermissions:
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