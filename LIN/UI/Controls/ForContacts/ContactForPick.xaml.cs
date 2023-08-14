namespace LIN.UI.Controls;

public partial class ContactForPick : Grid
{


    //========= Eventos =========//

    /// <summary>
    /// Evento Click sobre el control
    /// </summary>
    public event EventHandler<EventArgs>? Clicked;



    //========= Propiedades =========//

    /// <summary>
    /// Modelo
    /// </summary>
    public ContactDataModel Modelo { get; set; }



    /// <summary>
    /// Constructor
    /// </summary>
    public ContactForPick(ContactDataModel modelo)
    {
        InitializeComponent();
        this.Modelo = modelo;
        LoadModelVisible();
    }



    /// <summary>
    /// Muestra los datos del contacto en el display
    /// </summary>
    public void LoadModelVisible()
    {

        // Si el modelo fue eliminado
        if (Modelo.State == ContactStatus.Deleted)
        {
            this.Hide();
            return;
        }

        // Datos
        lbName.Text = Modelo.Name;
        lbMail.Text = Modelo.Mail;
        lbTelefono.Text = Modelo.Phone;

        // Si no hay imagen que mostrar
        if (Modelo.Picture.Length == 0)
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
            img.Source = ImageEncoder.Decode(Modelo.Picture);
        }

    }



    /// <summary>
    /// Actualiza la UI (Seleccionado)
    /// </summary>
    public void Select()
    {
        bg.Stroke = Microsoft.Maui.Graphics.Colors.RoyalBlue;
        bg.StrokeThickness = 1;
    }



    /// <summary>
    /// Actualiza la UI (No Seleccionado)
    /// </summary>
    public void UnSelect()
    {
        bg.Stroke = Microsoft.Maui.Graphics.Colors.LightGray;
        bg.StrokeThickness = 0.5;
    }



    /// <summary>
    /// Submit del evento click
    /// </summary>
    private void EventoClick(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, new());
    }


}