namespace LIN.UI.Controls;

public partial class HomeCard : ContentView
{
	public HomeCard()
	{
		InitializeComponent();
	}




    public Color BaseColor
    {
        get => (Color)GetValue(BackgroundProperty2);
        set { SetValue(BackgroundProperty2, value); }
    }


    public Color ShadowColor
    {
        get => (Color)GetValue(ShadowColorProperty);
        set { SetValue(ShadowColorProperty, value); }
    }


    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set { SetValue(TitleProperty, value); }
    }

    public string SubTitle
    {
        get => (string)GetValue(SubTitleProperty);
        set { SetValue(SubTitleProperty, value); }
    }





    /// <summary>
    /// Propiedad Contenido
    /// </summary>
    public static readonly BindableProperty BackgroundProperty2 = BindableProperty.Create(
        propertyName: nameof(BaseColor),
        returnType: typeof(Color),
        declaringType: typeof(HomeCard),
        defaultValue: Colors.Transparent,
        defaultBindingMode: BindingMode.TwoWay);




    /// <summary>
    /// Propiedad Contenido
    /// </summary>
    public static readonly BindableProperty ShadowColorProperty = BindableProperty.Create(
        propertyName: nameof(ShadowColor),
        returnType: typeof(Color),
        declaringType: typeof(HomeCard),
        defaultValue: Colors.Black,
        defaultBindingMode: BindingMode.TwoWay);



    /// <summary>
    /// Propiedad Contenido
    /// </summary>
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        propertyName: nameof(Title),
        returnType: typeof(string),
        declaringType: typeof(HomeCard),
        defaultValue: "",
        defaultBindingMode: BindingMode.TwoWay);


    /// <summary>
    /// Propiedad Contenido
    /// </summary>
    public static readonly BindableProperty SubTitleProperty = BindableProperty.Create(
        propertyName: nameof(SubTitle),
        returnType: typeof(string),
        declaringType: typeof(HomeCard),
        defaultValue: "",
        defaultBindingMode: BindingMode.TwoWay);



}