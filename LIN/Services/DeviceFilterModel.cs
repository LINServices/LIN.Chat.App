namespace LIN.Services;


public class DeviceFilterModel
{

    /// <summary>
    /// Aplicaciones que pueden aparecer en la lista
    /// </summary>
    public Applications[] App { get; set; } = new[] { Applications.Undefined };


    /// <summary>
    /// Plataformas que pueden aparecer en la lista
    /// </summary>
    public Platforms[] Plataformas { get; set; } = new[] { Platforms.Undefined };


    /// <summary>
    /// HasMe
    /// </summary>
    public bool HasMe { get; set; } = false;


    /// <summary>
    /// Si se selecciona el primer dispositivo si existe solo uno
    /// </summary>
    public bool AutoSelect { get; set; } = false;



    public DeviceFilterModel(bool hasMe = false, bool autoSelect = false)
    {
        this.HasMe = hasMe;
        this.AutoSelect = autoSelect;
    }

}
