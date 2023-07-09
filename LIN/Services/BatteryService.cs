namespace LIN.Services;


/// <summary>
/// Servicio de Batería
/// </summary>
public static class BatteryService
{

    /// <summary>
    /// Obtiene si el servicio esta inicializado
    /// </summary>
    private static bool IsInitialized = false;



    /// <summary>
    /// Cuando el estado cambie
    /// </summary>
    public static event EventHandler<BatteryStatus>? StatusChange;



    /// <summary>
    /// Obtiene el si la bateria se esta cargando
    /// </summary>
    public static bool IsChargin
    {
        get
        {
            var estado = Battery.Default.State;
            return (estado == BatteryState.Charging);
        }
    }



    /// <summary>
    /// Obtiene el estado de la bateria actual
    /// </summary>
    public static int Percent => (int)Math.Ceiling(Battery.Default.ChargeLevel * 100);



    /// <summary>
    /// Inicia el servicio
    /// </summary>
    public static void Initialize()
    {

        if (IsInitialized)
            return;

        Microsoft.Maui.Devices.Battery.Default.BatteryInfoChanged += Evento;
        System.Diagnostics.Debug.WriteLine("Servicio: BatteryService iniciado");
        IsInitialized = true;
    }



    /// <summary>
    /// Evento
    /// </summary>
    private static void Evento(object? sender, BatteryInfoChangedEventArgs e)
    {

        int percent = (int)Math.Ceiling(e.ChargeLevel * 100);
        var estado = e.State == BatteryState.Charging;

        StatusChange?.Invoke(null, new(percent, estado));
    }



}



/// <summary>
/// Clase de estado
/// </summary>
public class BatteryStatus
{

    /// <summary>
    /// Porcentaje de bateria
    /// </summary>
    public int Percent { get; set; }


    /// <summary>
    /// Obtiene si la bateria se esta cargando
    /// </summary>
    public bool IsChargin { get; set; }


    /// <summary>
    /// Constructor
    /// </summary>
    public BatteryStatus(int percent, bool isChangin)
    {
        this.Percent = percent;
        this.IsChargin = isChangin;
    }

}
