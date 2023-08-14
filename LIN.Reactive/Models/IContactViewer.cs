namespace LIN.React.Models;


public interface IContactViewer
{


    /// <summary>
    /// Modelo
    /// </summary>
    public ContactDataModel Modelo { get; set; }


    public string? ContextKey { get; init; }



    /// <summary>
    /// Renderiza la nueva informacion del modelo
    /// </summary>
    public void RenderNewData();



    /// <summary>
    /// Envia los cambios de modelo
    /// </summary>
    public abstract void ModelHasChange();


}
