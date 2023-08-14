namespace LIN.Services
{


    public static class TextShortener
    {










        public static ProductCategories ToProductCategory(string value)
        {

            switch (value)
            {

                case "Tecnología":
                    return ProductCategories.Tecnología;
                case "Hogar y decoración":
                    return ProductCategories.Hogar;
                case "Agricultura y jardinería":
                    return ProductCategories.Agricultura;
                case "Salud":
                    return ProductCategories.Salud;
                case "Limpieza":
                    return ProductCategories.Limpieza;
                case "Arte y manualidades":
                    return ProductCategories.Arte;
                case "Automóviles y motocicletas":
                    return ProductCategories.Automóviles;
                case "Deporte y fitness":
                    return ProductCategories.Deporte;
                case "Juguetes y entretenimiento":
                    return ProductCategories.Juguetes;
                case "Moda":
                    return ProductCategories.Moda;
                case "Software o servicios":
                    return ProductCategories.Servicios;
                case "Alimentos":
                    return ProductCategories.Alimentos;
                case "Frutas y verduras":
                    return ProductCategories.Frutas;
                case "Animales":
                    return ProductCategories.Animales;
                default:
                    return ProductCategories.Undefined;

            }
        }



        public static string Humanize(this ProductCategories value)
        {

            switch (value)
            {

                case ProductCategories.Tecnología:
                    return "Tecnología";
                case ProductCategories.Hogar:
                    return "Hogar y decoración";
                case ProductCategories.Agricultura:
                    return "Agricultura y jardinería";
                case ProductCategories.Salud:
                    return "Salud";
                case ProductCategories.Limpieza:
                    return "Limpieza";
                case ProductCategories.Arte:
                    return "Arte y manualidades";
                case ProductCategories.Automóviles:
                    return "Automóviles y motocicletas";
                case ProductCategories.Deporte:
                    return "Deporte y fitness";
                case ProductCategories.Juguetes:
                    return "Juguetes y entretenimiento";
                case ProductCategories.Moda:
                    return "Moda";
                case ProductCategories.Servicios:
                    return "Software o servicios";
                case ProductCategories.Alimentos:
                    return "Alimentos";
                case ProductCategories.Frutas:
                    return "Frutas y verduras";
                case ProductCategories.Animales:
                    return "Animales";
                default:
                    return "Sin categoria";

            }
        }


        public static string Humanize(this OutflowsTypes value)
        {

            return value switch
            {
                OutflowsTypes.Fraude => "Fraude",
                OutflowsTypes.Donacion => "Donacion",
                OutflowsTypes.Caducidad => "Caducidad",
                OutflowsTypes.Perdida => "Perdida",
                OutflowsTypes.Venta => "Venta",
                OutflowsTypes.Consumo => "Consumo interno",
                _ => "Sin definir",
            };
        }


        public static string Humanize(this InventoryRoles value)
        {

            return value switch
            {
                InventoryRoles.Undefined => "Indefinido",
                InventoryRoles.Administrator => "Administrador",
                InventoryRoles.Guest => "Invitado",
                InventoryRoles.Member => "Miembro",
                InventoryRoles.Banned => "Eliminado",
                _ => "Indefinido",
            };
        }


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
