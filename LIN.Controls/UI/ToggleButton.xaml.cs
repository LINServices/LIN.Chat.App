namespace LIN.Controls.UI;

public partial class ToggleButton : ContentView
{

    /// <summary>
    /// Evento Click sobre Subtitulo
    /// </summary>
    public event EventHandler<EventArgs>? Clicked;



    /// <summary>
    /// Obtiene o establece la imagen del boton
    /// </summary>
    public ImageSource Picture
    {
        get => (ImageSource)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }



    public Color ColorBG
    {
        get => (Color)GetValue(ColorProperty);
        set =>SetValue(ColorProperty, value);
    }


    public ToggleButton()
    {
        this.SizeChanged += E!;
        InitializeComponent();
    }



    public void E(object sender, EventArgs e)
    {
        uio.HeightRequest = this.Height - 20;
        uio.WidthRequest = this.Width - 20;
        uio.Margin = new(10);
    }




    /// <summary>
    /// Propiedad 'Picture'
    /// </summary>
    public static readonly BindableProperty SourceProperty = BindableProperty.Create(
        propertyName: nameof(Picture),
        returnType: typeof(ImageSource),
        declaringType: typeof(Button),
        defaultValue: ImageSource.FromResource("web.png"),
        defaultBindingMode: BindingMode.TwoWay);


    /// <summary>
    /// Propiedad Color de fondo
    /// </summary>
    public static readonly BindableProperty ColorProperty = BindableProperty.Create(
        propertyName: nameof(ColorBG),
        returnType: typeof(Color),
        declaringType: typeof(Button),
        defaultValue: Colors.WhiteSmoke,
        defaultBindingMode: BindingMode.TwoWay);



    /// <summary>
    /// Envia el evento Click
    /// </summary>
    private protected void SubmitClick(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, new());
    }
}