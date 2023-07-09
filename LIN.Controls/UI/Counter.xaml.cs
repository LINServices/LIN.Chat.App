namespace LIN.Controls.UI;

public partial class Counter : ContentView
{


    //======== Eventos =========//

    public event EventHandler<Events.EventIntValue>? OnValueChange;

    public event EventHandler<EventArgs>? OnMaximunLimitExceeded;

    public event EventHandler<EventArgs>? OnMinimumLimitExceeded;


    //======== Propiedades =========//

    /// <summary>
    /// Valor maximo al que puede contar
    /// </summary>
    public int MaxValue
    {
        get => (int)GetValue(MaxValueProperty);
        set { SetValue(MaxValueProperty, value); }
    }



    /// <summary>
    /// Valor minimo al que puede contar
    /// </summary>
    public int MinValue
    {
        get => (int)GetValue(MinValueProperty);
        set { SetValue(MinValueProperty, value); }
    }



    /// <summary>
    /// Valor actual
    /// </summary>
    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set { SetValue(ValueProperty, value); }
    }



    /// <summary>
    /// Color de fondo
    /// </summary>
    public Color ColorBG
    {
        get => (Color)GetValue(BackgroundProperty);
        set { SetValue(BackgroundProperty, value); }
    }


    /// <summary>
    /// Color de fondo
    /// </summary>
    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set { SetValue(TextColorProperty, value); }
    }




    /// <summary>
    /// Constructor
    /// </summary>
    public Counter()
    {
        InitializeComponent();
    }



    /// <summary>
    /// Envia el evento
    /// </summary>
    private void SendEvent(int @old, int @new)
    {
        OnValueChange?.Invoke(this, new(@old, @new));
    }



    /// <summary>
    /// Aumenta el contador
    /// </summary>
    private void CounterAument(object sender, EventArgs e)
    {
        if (Value + 1 <= MaxValue)
        {
            var old = Value;
            Value++;
            SendEvent(old, Value);
        }

    }



    /// <summary>
    /// Decrementa el contador
    /// </summary>
    private void CounterDecrement(object sender, EventArgs e)
    {
        if (Value - 1 >= MinValue)
        {
            var old = Value;
            Value--;
            SendEvent(old, Value);
        }
    }



    #region BINDABLE


    /// <summary>
    /// Propiedad MaxValue
    /// </summary>
    public static readonly BindableProperty MaxValueProperty = BindableProperty.Create(
        propertyName: nameof(MaxValue),
        returnType: typeof(int),
        declaringType: typeof(Counter),
        defaultValue: 100_000,
        defaultBindingMode: BindingMode.TwoWay);



    /// <summary>
    /// Propiedad Value
    /// </summary>
    public static readonly BindableProperty ValueProperty = BindableProperty.Create(
        propertyName: nameof(Value),
        returnType: typeof(int),
        declaringType: typeof(Counter),
        defaultValue: 0,
        defaultBindingMode: BindingMode.TwoWay);



    /// <summary>
    /// Propiedad MinValue
    /// </summary>
    public static readonly BindableProperty MinValueProperty = BindableProperty.Create(
        propertyName: nameof(MinValue),
        returnType: typeof(int),
        declaringType: typeof(Counter),
        defaultValue: 0,
        defaultBindingMode: BindingMode.TwoWay);



    /// <summary>
    /// Propiedad Color de fondo
    /// </summary>
    public new static readonly BindableProperty BackgroundProperty = BindableProperty.Create(
        propertyName: nameof(ColorBG),
        returnType: typeof(Color),
        declaringType: typeof(Counter),
        defaultValue: Color.FromRgb(240, 240, 240),
        defaultBindingMode: BindingMode.TwoWay);


    /// <summary>
    /// Propiedad Color de fondo
    /// </summary>
    public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
        propertyName: nameof(TextColor),
        returnType: typeof(Color),
        declaringType: typeof(Counter),
        defaultValue: Color.FromRgb(7, 7, 7),
        defaultBindingMode: BindingMode.TwoWay);


    #endregion


}