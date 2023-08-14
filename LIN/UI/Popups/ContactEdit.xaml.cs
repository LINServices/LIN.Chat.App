using LIN.Shared.Responses;
using LIN.UI.Views;

namespace LIN.UI.Popups;


public partial class ContactEdit : Popup
{

    // Modelo
    public ContactDataModel Modelo { get; set; }



    /// <summary>
    /// Constructor
    /// </summary>
    public ContactEdit(ContactDataModel product)
    {
        InitializeComponent();
        this.CanBeDismissedByTappingOutsideOfPopup = false;
        Modelo = product;
        LoadData();
    }



    /// <summary>
    /// Carga los datos y los controles
    /// </summary>
    private void LoadData()
    {

        // Metadatos
        txtName.Text = Modelo.Name;
        txtMail.Text = Modelo.Mail;
        txtPhone.Text = Modelo.Phone;
        txtDireccion.Text = Modelo.Direction;

    }




    private void BtnCancelClick(object sender, EventArgs e)
    {
        this.Close(null);
    }


    private async void BtnSelectClick(object sender, EventArgs e)
    {

        if (Modelo.Name == txtName.Text &&
            Modelo.Mail == txtMail.Text &&
            Modelo.Direction == txtDireccion.Text &&
            Modelo.Phone == txtPhone.Text)
        {
            Close();
            return;
        }


        // Nuevos datos
        {
            Modelo.Name = txtName.Text ?? "";
            Modelo.Direction = txtDireccion.Text ?? "";
            Modelo.Phone = txtPhone.Text ?? "";
            Modelo.Mail = txtMail.Text ?? "";
            Modelo.Picture = Modelo.Picture;
        }



        scrollView.Hide();
        indi.Show();
        await Task.Delay(5);


        var response = await Access.Inventory.Controllers.Contact.Update(Modelo);

        if (response.Response == Responses.Success)
        {
            AppShell.Hub.SendContactModel(Sesion.Instance.Informacion.ID, Modelo.ID);
            ContactObserver.Update(Modelo);
        }

        this.Close();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        this.Close();
    }

}