namespace LIN.Services;


internal static class RandomColor


{


    /// <summary>
    /// Lista de colores para mostrar 
    /// </summary>
    private readonly static Color[] Colors =
        {
             Color.FromRgb(233, 69, 59),
             Color.FromRgb(168, 119, 89),
             Color.FromRgb(240,126,29),
             Color.FromRgb(156, 119, 214),
             Color.FromRgb(77, 188, 195),
             Color.FromRgb(48, 196, 110),
             Color.FromRgb(242, 107, 176),
             Color.FromRgb(50, 151, 219),
             Color.FromRgb(50, 151, 219)
       };


    /// <summary>
    /// Obtiene un color random
    /// </summary>
    public static Color GetRandomColor()
    {
        var rd = new Random();
        var value = rd.Next(0, Colors.Length - 1);
        return Colors[value];
    }


}