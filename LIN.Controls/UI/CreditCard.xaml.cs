namespace LIN.Controls.UI;

public partial class CreditCard : ContentView
{


    public decimal Creditos
    {
        set => displayCreditos.Text = value.ToString();
    }

    public string Cuenta
    {
        set => displayCuenta.Text = value;
    }

    public CreditCard()
    {
        InitializeComponent();
    }
}