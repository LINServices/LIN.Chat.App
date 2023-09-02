namespace LIN.Services
{


    public static class TextShortener
    {





        public static string Short(this string value, int cantidad)
        {


            if (cantidad <= 0)
                return "";

            if (value.Length < cantidad)
                return value;

            return value[..cantidad] + "...";

        }


    }
}
