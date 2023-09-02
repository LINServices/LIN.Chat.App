namespace LIN.Controls.UI;

public partial class EntryControl : Grid
{

    //================= Eventos =================//

    public event EventHandler<TextChangedEventArgs>? TextChanged;


    public bool ReadOnly
    {
        get => txtEntry.IsReadOnly;
        set => txtEntry.IsReadOnly = value;
    }


    public void LoadWithEvents()
    {
        txtEntry.Focus();
        txtEntry.Unfocus();
    }

    //================= Propiedades =================//

    /// <summary>
    /// Obtiene o establece el texto
    /// </summary>
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set 
        {  
            SetValue(TextProperty, value);
            ToFocus(txtEntry, new(txtEntry, true));
        }
    }


    /// <summary>
    /// Obtiene o establece el 'Placeholder' del control
    /// </summary>
    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set { SetValue(PlaceholderProperty, value); }
    }


    /// <summary>
    /// Obtiene o establece el color en estado focus
    /// </summary>
    public Color FocusColor
    {
        get => (Color)GetValue(FocusColorProperty);
        set { SetValue(FocusColorProperty, value); }
    }


    /// <summary>
    /// Obtiene o establece el color en estado focus
    /// </summary>
    public Color UnFocusColor
    {
        get => (Color)GetValue(UnFocusColorProperty);
        set { SetValue(UnFocusColorProperty, value); }
    }

    /// <summary>
    /// Obtiene o establece el si es un txt de contraseña
    /// </summary>
    public bool IsPassword
    {
        get => (bool)GetValue(IsPassWordProperty);
        set { SetValue(IsPassWordProperty, value); }
    }


    /// <summary>
    /// Base margin
    /// </summary>
    private bool BaseMargin { get; set; }



    /// <summary>
    /// Constructor
    /// </summary>
    public EntryControl()
    {
        InitializeComponent();
        txtEntry.TextChanged += TextChanged;
        LoadWithEvents();
    }



    //================= Propiedades para el Indexer =================//


    /// <summary>
    /// ¿Es Contraseña?
    /// </summary>
    public static readonly BindableProperty IsPassWordProperty = BindableProperty.Create(
       propertyName: nameof(IsPassword),
       returnType: typeof(bool),
       declaringType: typeof(EntryControl),
       defaultValue: false,
       defaultBindingMode: BindingMode.TwoWay);



    /// <summary>
    /// Propiedad de texto
    /// </summary>
    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        propertyName: nameof(Text),
        returnType: typeof(string),
        declaringType: typeof(EntryControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay);



    /// <summary>
    /// Propiedad de Color Fucus
    /// </summary>
    public static readonly BindableProperty FocusColorProperty = BindableProperty.Create(
        propertyName: nameof(FocusColor),
        returnType: typeof(Color),
        declaringType: typeof(EntryControl),
        defaultValue: Color.FromRgb(99, 102, 241),
        defaultBindingMode: BindingMode.TwoWay);


    /// <summary>
    /// Propiedad de Color Fucus
    /// </summary>
    public static readonly BindableProperty UnFocusColorProperty = BindableProperty.Create(
        propertyName: nameof(UnFocusColor),
        returnType: typeof(Color),
        declaringType: typeof(EntryControl),
        defaultValue: Color.FromRgb(79, 79, 79),
        defaultBindingMode: BindingMode.TwoWay);



    /// <summary>
    /// Propiedad de placeholder
    /// </summary>
    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
      propertyName: nameof(Placeholder),
      returnType: typeof(string),
      declaringType: typeof(EntryControl),
      defaultValue: null,
      defaultBindingMode: BindingMode.OneWay);



    /// <summary>
    /// Evento Focus
    /// </summary>
    private void ToFocus(object sender, FocusEventArgs e)
    {
        if (IsFocus)
            return;

        if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            ToFocusAndroid();
        else if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
            ToFocusWindows();

        IsFocus = true;
    }



    /// <summary>
    /// Evento UnFocus
    /// </summary>
    private void NoFocus(object sender, FocusEventArgs e)
    {

        if (!IsFocus)
            return;


        if (DeviceInfo.Current.Platform == DevicePlatform.Android)
            NoFocusAndroid();
        else if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
            NoFocusWindows();

        IsFocus = false;
    }


    bool IsFocus = false;



    /// <summary>
    /// Focus On Android
    /// </summary>
    private void ToFocusAndroid()
    {

       

        // Propiedades de margin
        double left = Margin.Left;
        double top = Margin.Top;
        double right = Margin.Right;
        double bottom = Margin.Bottom;

        // Colores
        frame.BorderColor = FocusColor;
        lblPlaceholder.TextColor = FocusColor;

        // Nueva margin
        if (!BaseMargin)
            Margin = new(left, top + 15, right, bottom);


        lblPlaceholder.FontSize = 11;
        lblPlaceholder.TranslateTo(-10, -30, 80, easing: Easing.Linear);

    }



    /// <summary>
    /// Unfocus On Android
    /// </summary>
    private void NoFocusAndroid()
    {

        // Propiedades de margin
        double left = Margin.Left;
        double top = Margin.Top;
        double right = Margin.Right;
        double bottom = Margin.Bottom;

        // Cambio de color
        frame.BorderColor = UnFocusColor;
        lblPlaceholder.TextColor = UnFocusColor;


        if (string.IsNullOrWhiteSpace(Text))
        {
            lblPlaceholder.FontSize = 12;
            lblPlaceholder.TranslateTo(0, 0, 80, easing: Easing.Linear);
            BaseMargin = false;
            this.Margin = new(left, top - 15, right, bottom);
        }
        else
        {
            lblPlaceholder.FontSize = 11;
            lblPlaceholder.TranslateTo(-10, -30, 80, easing: Easing.Linear);
            BaseMargin = true;
        }

    }



    /// <summary>
    /// Focus On Windows
    /// </summary>
    private void ToFocusWindows()
    {

        // Propiedades de margin
        double left = Margin.Left;
        double top = Margin.Top;
        double right = Margin.Right;
        double bottom = Margin.Bottom;

        // Nueva margin
        if (!BaseMargin)
            Margin = new(left, top + 20, right, bottom);


        lblPlaceholder.FontSize = 11;
        lblPlaceholder.TranslateTo(-10, -27, 80, easing: Easing.Linear);

    }



    /// <summary>
    /// Unfocus On Windows
    /// </summary>
    private void NoFocusWindows()
    {

        // Propiedades de margin
        double left = Margin.Left;
        double top = Margin.Top;
        double right = Margin.Right;
        double bottom = Margin.Bottom;


        if (string.IsNullOrWhiteSpace(Text))
        {
            lblPlaceholder.FontSize = 10;
            lblPlaceholder.TranslateTo(0, -1, 80, easing: Easing.Linear);
            BaseMargin = false;
            this.Margin = new(left, top - 20, right, bottom);
        }
        else
        {
            lblPlaceholder.FontSize = 11;
            lblPlaceholder.TranslateTo(-10, -27, 80, easing: Easing.Linear);
            BaseMargin = true;
        }

    }





    /// <summary>
    /// Click sobre el 'Placeholder'
    /// </summary>d
    private void TapGestureRecognizer_Tapped(object sender, EventArgs e) => txtEntry.Focus();



    /// <summary>
    /// Ejectita el evento TxtChange
    /// </summary>
    private void SendTextChange(object sender, TextChangedEventArgs e)
    {
        TextChanged?.Invoke(this, e);
    }

    public static explicit operator InputView(EntryControl v)
    {
        throw new NotImplementedException();
    }
}