namespace LIN.UI.Controls;

public partial class Contact : Grid, IContactViewer
{


    //======== Eventos =========//


    /// <summary>
    /// Evento Click
    /// </summary>
    public event EventHandler<EventArgs>? Clicked;


    /// <summary>
    /// Modelo
    /// </summary>
    public ContactDataModel Modelo { get; set; }


    public string? ContextKey { get; init; }




    /// <summary>
    /// Constructor
    /// </summary>
    public Contact(ContactDataModel modelo)
    {
        InitializeComponent();
        this.Modelo = modelo;
        ContextKey = $"ct.{modelo.ID}";
        ContactObserver.Add(this);
        LoadModelVisible();
    }



    /// <summary>
    /// Renderiza el modelo
    /// </summary>
    public void LoadModelVisible()
    {

        // Si el modelo fue eliminado
        if (Modelo.State == ContactStatus.Deleted)
        {
            this.AnimateRight(true);
            return;
        }

        // Metadatos
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
    /// Envía el evento click
    /// </summary>
    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, new());
    }


    public void RenderNewData()
    {
        if (Modelo.State == ContactStatus.OnTrash)
            this.AnimateRight(true);
        
        LoadModelVisible();
    }



    public void ModelHasChange()
    {
        ContactObserver.Update(this);
    }
}