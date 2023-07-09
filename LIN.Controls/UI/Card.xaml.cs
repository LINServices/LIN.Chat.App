using CommunityToolkit.Maui.Animations;

namespace LIN.Controls.UI;

public partial class Card : ContentView
{

    //=========== Eventos ===========//

    /// <summary>
    /// Evento Click sobre Titulo
    /// </summary>
    public event EventHandler<EventArgs>? TitleClicked;


    /// <summary>
    /// Evento Click sobre Subtitulo
    /// </summary>
    public event EventHandler<EventArgs>? SubTitleClicked;


    /// <summary>
    /// Evento Doble Click sobre Subtitulo
    /// </summary>
    public event EventHandler<EventArgs>? SubTitleDoubleClicked;




    //=========== Propiedades ===========//

    /// <summary>
    /// Obtiene o establece el titulo de la carta
    /// </summary>
    public string Titulo
    {
        get => (string)GetValue(TituloProperty);
        set { SetValue(TituloProperty, value); }
    }


    /// <summary>
    /// Obtiene o establece el contenido de la carta
    /// </summary>
    public string ContentText
    {
        get => (string)GetValue(ContentTextProperty);
        set { SetValue(ContentTextProperty, value); }
    }


    /// <summary>
    /// Obtiene o establece la imagen
    /// </summary>
    public ImageSource Picture
    {
        get => (ImageSource)GetValue(PictureProperty);
        set { SetValue(PictureProperty, value); }
    }


    /// <summary>
    /// Obtiene o establece el color de fondo
    /// </summary>
    public Color ColorBG
    {
        get => (Color)GetValue(ColorBGProperty);
        set { SetValue(ColorBGProperty, value); }
    }


    /// <summary>
    /// Obtiene o establece el color de soporte
    /// </summary>
    public Color ColorSupport
    {
        get => (Color)GetValue(ColorSupportProperty);
        set { SetValue(ColorSupportProperty, value); }
    }


    /// <summary>
    /// Obtiene o establece el color del texto
    /// </summary>
    public Color ColorText
    {
        get => (Color)GetValue(ColorTextProperty);
        set { SetValue(ColorTextProperty, value); }
    }



    /// <summary>
    /// Constructor
    /// </summary>
    public Card()
    {
        InitializeComponent();
    }




    /// <summary>
    /// Click On Title
    /// </summary>
    private void OnTitle(object sender, EventArgs e) => TitleClicked?.Invoke(this, new());


    /// <summary>
    /// Click On SubTitle
    /// </summary>
    private void OnSubTitle(object sender, EventArgs e)
    {
        var fadeAnimation = new FadeAnimation();
        fadeAnimation.Animate(anim);
        SubTitleClicked?.Invoke(this, new());
    }





    #region BINDABLE

    /// <summary>
    /// Propiedad Contenido
    /// </summary>
    public static readonly BindableProperty ContentTextProperty = BindableProperty.Create(
        propertyName: nameof(ContentText),
        returnType: typeof(string),
        declaringType: typeof(Card),
        defaultValue: "",
        defaultBindingMode: BindingMode.TwoWay);


    /// <summary>
    /// Propiedad Titulo
    /// </summary>
    public static readonly BindableProperty TituloProperty = BindableProperty.Create(
        propertyName: nameof(Titulo),
        returnType: typeof(string),
        declaringType: typeof(Card),
        defaultValue: "",
        defaultBindingMode: BindingMode.TwoWay);


    /// <summary>
    /// Propiedad ColorBG
    /// </summary>
    public static readonly BindableProperty ColorBGProperty = BindableProperty.Create(
        propertyName: nameof(ColorBG),
        returnType: typeof(Color),
        declaringType: typeof(Card),
        defaultValue: Color.FromRgb(0, 109, 191),
        defaultBindingMode: BindingMode.TwoWay);


    /// <summary>
    /// Propiedad ColorSupport
    /// </summary>
    public static readonly BindableProperty ColorSupportProperty = BindableProperty.Create(
        propertyName: nameof(ColorSupport),
        returnType: typeof(Color),
        declaringType: typeof(Card),
        defaultValue: Color.FromRgb(59, 143, 205),
        defaultBindingMode: BindingMode.TwoWay);


    /// <summary>
    /// Propiedad ColorText
    /// </summary>
    public static readonly BindableProperty ColorTextProperty = BindableProperty.Create(
        propertyName: nameof(ColorText),
        returnType: typeof(Color),
        declaringType: typeof(Card),
        defaultValue: Color.FromRgb(220, 228, 234),
        defaultBindingMode: BindingMode.TwoWay);


    /// <summary>
    /// Propiedad Picture
    /// </summary>
    public static readonly BindableProperty PictureProperty = BindableProperty.Create(
        propertyName: nameof(Picture),
        returnType: typeof(ImageSource),
        declaringType: typeof(Card),
        defaultValue: ImageSource.FromResource("web.png"),
        defaultBindingMode: BindingMode.TwoWay);




    #endregion


}