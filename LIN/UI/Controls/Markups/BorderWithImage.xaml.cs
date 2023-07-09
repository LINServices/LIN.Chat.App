namespace LIN.UI.Controls.Markups;

public partial class BorderWithImage : ContentView
{


    public string Titulo
    {
        get => (string)GetValue(TitleProperty);
        set { SetValue(TitleProperty, value); }
    }

    public string SubTitulo
    {
        get => (string)GetValue(SubTitleProperty);
        set { SetValue(SubTitleProperty, value); }
    }

    public ImageSource Imagen
    {
        get => (ImageSource)GetValue(ImageProperty);
        set { SetValue(ImageProperty, value); }
    }


    public BorderWithImage()
	{
		InitializeComponent();
	}



    public static readonly BindableProperty ImageProperty = BindableProperty.Create(
       propertyName: nameof(Imagen),
       returnType: typeof(ImageSource),
       declaringType: typeof(BorderWithImage),
       defaultValue: ImageSource.FromFile("icono.png"),
       defaultBindingMode: BindingMode.TwoWay);


    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        propertyName: nameof(Titulo),
        returnType: typeof(string),
        declaringType: typeof(BorderWithImage),
        defaultValue: "",
        defaultBindingMode: BindingMode.TwoWay);


    public static readonly BindableProperty SubTitleProperty = BindableProperty.Create(
        propertyName: nameof(SubTitulo),
        returnType: typeof(string),
        declaringType: typeof(BorderWithImage),
        defaultValue: "",
        defaultBindingMode: BindingMode.TwoWay);





}