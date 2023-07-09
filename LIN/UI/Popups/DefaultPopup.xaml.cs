namespace LIN.UI.Popups;

public partial class DefaultPopup : Popup
{


    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="seconds">Segundo para cerrar el popup</param>
    [Obsolete("Propiedad de segundo fue eliminada")]
    public DefaultPopup(int seconds)
    {
        InitializeComponent();
    }


    /// <summary>
    /// Constructor
    /// </summary>
    public DefaultPopup(string message = "Correcto", string icono = "cheque.png")
    {
        InitializeComponent();
        displayMessage.Text = message ?? "";
        displayIcono.Source = ImageSource.FromFile(icono);
    }


}