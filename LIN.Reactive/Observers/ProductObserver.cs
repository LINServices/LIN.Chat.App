namespace LIN.React.Observers;


public sealed class ProductObserver
{


    /// <summary>
    /// Lista de modelos
    /// </summary>
    private readonly static List<IProductViewer> _data = new();



    /// <summary>
    /// Agrega al nuevo viewer
    /// </summary>
    public static void Add(IProductViewer viewer)
    {

        if (viewer.ContextKey != null && viewer.ContextKey != "")
            _data.RemoveAll(T => T.ContextKey == viewer.ContextKey);
        
        if (!_data.Contains(viewer))
            _data.Add(viewer);
    }


    /// <summary>
    /// Elimina un viewer
    /// </summary>
    public static void Remove(IProductViewer viewer)
    {
        _data.Remove(viewer);
    }




    public static bool FillWith(int id, ProductDataTransfer data)
    {


        var modelo = _data.Where(T => T.Modelo.ProductID == id).FirstOrDefault()?.Modelo;

        if (modelo == null)
        {
            return false;
        }

        modelo.FillWith(data);
        return true;

    }






    /// <summary>
    /// Envia los cambios
    /// </summary>
    public static bool Update(IProductViewer context, From from)
    {

        var notificates = _data.Where(x => x.Modelo.ProductID == context.Modelo.ProductID).ToList();

        if (!notificates.Any())
            return false;

        foreach (var certificate in notificates)
        {
            certificate.RenderNewData(from);
        }
        return true;

    }


    /// <summary>
    /// Envia los cambios
    /// </summary>
    public static bool Update(ProductDataTransfer context, From from)
    {

        var notificates = _data.Where(x => x.Modelo.ProductID == context.ProductID).ToList();

        if (!notificates.Any())
            return false;

        foreach (var certificate in notificates)
        {
            certificate.Modelo.FillWith(context);
            certificate.RenderNewData(from);
        }
        return true;

    }




}
