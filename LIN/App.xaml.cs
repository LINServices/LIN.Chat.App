namespace LIN;

public partial class App : Application
{
	public App()
	{

		InitializeComponent();

        var form = new UI.Views.Login();
        NavigationPage.SetHasNavigationBar(form, false);

        MainPage = new NavigationPage(form);
        NavigationPage.SetHasNavigationBar(MainPage, false);

    }
}
