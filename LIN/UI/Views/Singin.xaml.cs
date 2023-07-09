using LIN.Shared.Responses;

namespace LIN.UI.Views;

public partial class Singin : ContentPage
{


    /// <summary>
    /// Constructor
    /// </summary>
	public Singin()
    {
        InitializeComponent();
    }



    /// <summary>
    /// Evento cuando se escribe sobre los txts
    /// </summary>
    private void TxtChanged(object sender, TextChangedEventArgs e)
    {
        lbInfo.Hide();
    }



    /// <summary>
    /// Evento Ir a Login
    /// </summary>
    private void GoLoginEvent(object sender, EventArgs e)
    {
        new Login().Show();
        this.Close();
    }



    /// <summary>
    /// Evento Crear
    /// </summary>
    private async void BtnCrear(object sender, EventArgs e)
    {
        // Modo de carga
        EnableChargeMode();

        await Task.Delay(10);

        // Variables
        string user = txtUser.Text ?? "";
        string name = txtName.Text ?? "";
        string pass = txtPassword.Text ?? "";

        // Campos vacios
        if (string.IsNullOrEmpty(user.Trim()) || string.IsNullOrEmpty(name.Trim()) || string.IsNullOrEmpty(pass.Trim()))
        {
            DisableChargeMode();
            lbInfo.Text = "Por favor, asegúrate de llenar todos los campos requeridos.";
            lbInfo.Show();
            return;
        }


        // Contraseña Lenght
        if (pass.Length < 4)
        {
            DisableChargeMode();
            lbInfo.Text = "La contraseña debe de tener minimo 4 digitos";
            lbInfo.Show();
            return;
        }


        // Model
        LIN.Shared.Models.UserDataModel modelo = new()
        {
            Nombre = name,
            Usuario = user,
            Contraseña = pass,
            Perfil = await inpImg.GetBytes()
        };

        // Creacion
        var res = await LIN.Access.Controllers.User.CreateAsync(modelo);


        // Respuesta
        switch (res.Response)
        {

            case Responses.Success:
                break;

            case Responses.NotConnection:
                DisableChargeMode();
                lbInfo.Text = "Error conexion";
                lbInfo.IsVisible = true;
                return;

            case Responses.ExistAccount:
                DisableChargeMode();
                lbInfo.Text = $"Ya existe un usuario con el nombre '{user}'";
                lbInfo.IsVisible = true;
                return;

            default:
                DisableChargeMode();
                lbInfo.Text = "Error grave";
                lbInfo.IsVisible = true;
                return;
        }


        Access.Sesion.GenerateSesion(res.Model, res.Token);


        await this.ShowPopupAsync(new Popups.Welcome());

        // Abre la nueva ventana
        App.Current!.MainPage = new AppShell();

        this.Close();
    }



    /// <summary>
    /// Modo de carga
    /// </summary>
    private void EnableChargeMode()
    {
        btnCrear.Hide();
        lbInfo.Hide();
        lbsCrear.Hide();
        indicador.Show();
    }



    /// <summary>
    /// Deshabilita el modo de carga
    /// </summary>
    private void DisableChargeMode()
    {
        btnCrear.Show();
        lbInfo.Hide();
        lbsCrear.Show();
        indicador.Hide();
    }


}