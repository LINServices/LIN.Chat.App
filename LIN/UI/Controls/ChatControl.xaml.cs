namespace LIN.UI.Controls;


public partial class ChatControl : ContentView
{
	public ChatControl(ProfileModel remitenete, string message)
	{
		InitializeComponent();


		if (remitenete.ID == Session.Instance.Informacion.ID)
		{
			frame.HorizontalOptions = LayoutOptions.EndAndExpand;
			displayName.Hide();
			frame.BackgroundColor = Color.FromArgb("#6366f1");
			frame.StrokeShape = new Microsoft.Maui.Controls.Shapes.RoundRectangle()
			{
				CornerRadius = new(10,10,10,0)
			};
		}
		else
		{
            frame.HorizontalOptions = LayoutOptions.Start;
            displayName.Show();
			displayName.Text = remitenete.Alias;
            frame.BackgroundColor = Color.FromArgb("#e0e7ff");
			MessageDesign.TextColor = Color.FromArgb("#0C0A2A ");
            frame.StrokeShape = new Microsoft.Maui.Controls.Shapes.RoundRectangle()
            {
                CornerRadius = new(10, 10, 0, 10)
            };
        }

		MessageDesign.Text = message;
    }
}