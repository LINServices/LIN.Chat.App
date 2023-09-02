namespace LIN.UI.Controls;


public partial class Conversation : Grid
{


    /// <summary>
    /// Evento click del control
    /// </summary>
    public event EventHandler<EventArgs>? Clicked;



    /// <summary>
    /// Modelo del producto
    /// </summary>
    public MemberChatModel Modelo { get; set; }


    public string? ContextKey { get; init; }




    /// <summary>
    /// Constructor
    /// </summary>
    public Conversation(MemberChatModel modelo)
    {
        InitializeComponent();
        this.Modelo = modelo;
        LoadModelVisible();
    }



    protected override void ChangeVisualState()
    {
        System.Diagnostics.Debug.WriteLine("#SEARH-ME#-VisualState");
        base.ChangeVisualState();
    }



    /// <summary>
    /// Hace el modelo visible a la UI
    /// </summary>
    public void LoadModelVisible()
    {

        displayName.Text = Modelo.Conversation.Name;


    }



    /// <summary>
    /// Envua el evento click
    /// </summary>
    private void SendEventClick(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, new());
    }

    private void displayImagen_Clicked(object sender, EventArgs e)
    {

    }

}