namespace LIN.UI.Controls;

public partial class InfoCard : ContentView
{


    public string Titulo
    {
        get => (string)GetValue(TituloProperty);
        set { SetValue(TituloProperty, value); }
    }

    public string Contenido
    {
        get => (string)GetValue(ContenidoProperty);
        set { SetValue(ContenidoProperty, value); }
    }


    public string ChartText
    {
        get => (string)GetValue(ChartProperty);
        set { SetValue(ChartProperty, value); }
    }



    public ImageSource Picture
    {
        get => (ImageSource)GetValue(PictureProperty);
        set { SetValue(PictureProperty, value); }
    }



    public Color ColorBG
    {
        get => (Color)GetValue(BGProperty);
        set { SetValue(BGProperty, value); }
    }


    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set { SetValue(TextColorProperty, value); }
    }






    public InfoCard()
	{
		InitializeComponent();
	}





    /// <summary>
    /// Propiedad Contenido
    /// </summary>
    public static readonly BindableProperty TituloProperty = BindableProperty.Create(
        propertyName: nameof(Titulo),
        returnType: typeof(string),
        declaringType: typeof(InfoCard),
        defaultValue: "",
        defaultBindingMode: BindingMode.TwoWay);



    /// <summary>
    /// Propiedad Contenido
    /// </summary>
    public static readonly BindableProperty ChartProperty = BindableProperty.Create(
        propertyName: nameof(ChartText),
        returnType: typeof(string),
        declaringType: typeof(InfoCard),
        defaultValue: "",
        defaultBindingMode: BindingMode.TwoWay);




    /// <summary>
    /// Propiedad Contenido
    /// </summary>
    public static readonly BindableProperty ContenidoProperty = BindableProperty.Create(
        propertyName: nameof(Contenido),
        returnType: typeof(string),
        declaringType: typeof(InfoCard),
        defaultValue: "",
        defaultBindingMode: BindingMode.TwoWay);




    /// <summary>
    /// Propiedad Contenido
    /// </summary>
    public static readonly BindableProperty BGProperty = BindableProperty.Create(
        propertyName: nameof(ColorBG),
        returnType: typeof(Color),
        declaringType: typeof(InfoCard),
        defaultValue: Colors.Transparent,
        defaultBindingMode: BindingMode.TwoWay);



    /// <summary>
    /// Propiedad Contenido
    /// </summary>
    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
        propertyName: nameof(TextColor),
        returnType: typeof(Color),
        declaringType: typeof(InfoCard),
        defaultValue: Colors.Black,
        defaultBindingMode: BindingMode.TwoWay);



    /// <summary>
    /// Propiedad Contenido
    /// </summary>
    public static readonly BindableProperty PictureProperty = BindableProperty.Create(
        propertyName: nameof(Picture),
        returnType: typeof(ImageSource),
        declaringType: typeof(InfoCard),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay);





}