namespace LIN.Controls;


public static class DateTimeExtensions
{

    public static bool IsToday(this DateTime value)
    {
        var now = DateTime.Now;
        var xx = now.Day == value.Day && now.Month == value.Month && value.Year == now.Year;
        return xx;
    }


}
