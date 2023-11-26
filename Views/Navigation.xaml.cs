namespace MauiBase.Views;

public partial class Navigation : ContentPage
{
	public Navigation()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private void To_BirthdayPage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new BirthdayPage());
    }

    private void To_MoonPage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MoonPhasePage());
    }
    private void To_SunPage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SunrisePage());
    }

    private void To_Weather(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Weather());
    }
}