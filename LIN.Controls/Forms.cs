using CommunityToolkit.Maui.Views;

namespace LIN.Controls;


/// <summary>
/// Extensiones para ContextPages
/// </summary>
public static class ContextPageExtensions
{

    /// <summary>
    /// Muestra un Popup
    /// </summary>
    public static async Task<object?> Show(this Popup pop)
    {

        try
        {

            // Obtenemos el objeto Navigation
            Page? navigation = Application.Current?.MainPage;

            // Evalua
            if (navigation == null)
                return null;

            // Ejecuta el popup
            return await navigation.ShowPopupAsync(pop);
        }
        catch
        {
        }
        return null;
    }


    public static List<ContentPage> Pages = new();
    /// <summary>
    /// Abre una nueva pagina
    /// </summary>
    public static async void Show(this ContentPage newPage)
    {
        try
        {
            // Obtiene la pagina actual
            var actualPage = Application.Current?.MainPage;

            if (actualPage == null) return;

            // Propiedades para la nueva pagina
            NavigationPage.SetHasNavigationBar(newPage, false);

            newPage.BackgroundColor = new(247, 248, 253);
            newPage.Title = string.Empty;

            // Muestra la nueva pagina
            Pages.Add(newPage);
            await actualPage.Navigation.PushAsync(newPage, true);
        }
        catch
        {
        }
    }






    /// <summary>
    /// Cierra la ventana una nueva ventana
    /// </summary>
    public static void Close(this ContentPage context)
    {
        try
        {
            Pages.Remove(context);
            context?.Navigation.RemovePage(context);
        }
        catch { }
    }


}
