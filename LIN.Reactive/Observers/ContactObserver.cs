using LIN.React.Models;
using LIN.Shared.Models;

namespace LIN.React.Observers;

public sealed class ContactObserver
{


    /// <summary>
    /// Lista de modelos
    /// </summary>
    private readonly static List<IContactViewer> _data = new();



    /// <summary>
    /// Agrega al nuevo viewer
    /// </summary>
    public static void Add(IContactViewer viewer)
    {

        if (viewer.ContextKey != null && viewer.ContextKey != "")
            _data.RemoveAll(T => T.ContextKey == viewer.ContextKey);
        
        if (!_data.Contains(viewer))
            _data.Add(viewer);
    }


    /// <summary>
    /// Elimina un viewer
    /// </summary>
    public static void Remove(IContactViewer viewer)
    {
        _data.Remove(viewer);
    }


    /// <summary>
    /// Envia los cambios
    /// </summary>
    public static bool Update(IContactViewer context)
    {

        var notificates = _data.Where(x => x.Modelo.ID == context.Modelo.ID).ToList();
        if (!notificates.Any())
            return false;
        foreach (var certificate in notificates)
        {
            certificate.RenderNewData();
        }
        return true;
    }


    /// <summary>
    /// Envia los cambios
    /// </summary>
    public static bool Update(ContactDataModel modelo)
    {

        var notificates = _data.Where(x => x.Modelo.ID == modelo.ID).ToList();

        if (!notificates.Any())
            return false;

        foreach (var certificate in notificates)
        {
            certificate.Modelo.FillWith(modelo);
            certificate.RenderNewData();
        }

      return true;

    }




}
