namespace LIN.Services;


internal class Date
{


    public static string TiempoTranscurrido(DateTime fecha)
    {
        // Segundos
        TimeSpan tiempoTranscurrido = DateTime.Now - fecha;
        int segundos = (int)tiempoTranscurrido.TotalSeconds;

        // Fecha humanizada
        return (segundos < 0) ? TimeFuture(fecha) : TimePast(fecha);

    }




    private static string TimePast(DateTime fecha)
    {
        TimeSpan tiempoTranscurrido = DateTime.Now - fecha;
        int segundos = (int)tiempoTranscurrido.TotalSeconds;

        if (segundos == 0)
        {
            return "Justo ahora";
        }
        else if (segundos < 60)
        {
            return "Hace menos de un minuto";
        }
        else if (segundos < 120)
        {
            return "Hace un minuto";
        }
        else if (segundos < 2700)
        {
            return $"Hace {Math.Floor(tiempoTranscurrido.TotalMinutes)} minutos";
        }
        else if (segundos < 5400)
        {
            return "Hace una hora";
        }
        else if (segundos < 86400)
        {
            return $"Hace {Math.Floor(tiempoTranscurrido.TotalHours)} horas";
        }
        else if (segundos < 172800)
        {
            return "Ayer";
        }
        else if (segundos < 604800)
        {
            return $"Hace {Math.Floor(tiempoTranscurrido.TotalDays)} días";
        }
        else if (segundos < 1209600)
        {
            return "La semana pasada";
        }
        else
        {
            return $"Hace {Math.Floor(tiempoTranscurrido.TotalDays / 7)} semanas";
        }
    }



    private static string TimeFuture(DateTime fecha)
    {
        TimeSpan tiempoTranscurrido = DateTime.Now - fecha;
        int segundos = (int)Math.Abs(tiempoTranscurrido.TotalSeconds);

        if (segundos == 0)
        {
            return "Justo ahora";
        }
        else if (segundos < 60)
        {
            return "En menos de un minuto";
        }
        else if (segundos < 120)
        {
            return "En un minuto";
        }
        else if (segundos < 2700)
        {
            return $"En {Math.Abs(Math.Floor(tiempoTranscurrido.TotalMinutes))} minutos";
        }
        else if (segundos < 5400)
        {
            return "En una hora";
        }
        else if (segundos < 86400)
        {
            return $"En {Math.Abs(Math.Floor(tiempoTranscurrido.TotalHours))} horas";
        }
        else if (segundos < 172800)
        {
            return "Mañana";
        }
        else if (segundos < 604800)
        {
            return $"En {Math.Abs(Math.Floor(tiempoTranscurrido.TotalDays))} días";
        }
        else if (segundos < 1209600)
        {
            return "La proxima semana";
        }
        else
        {
            return $"En {Math.Abs(Math.Floor(tiempoTranscurrido.TotalDays / 7))} semanas";
        }
    }



}
