namespace MauiBase.Views;

public partial class DataBindPage : ContentPage
{
    private int count = 0;
	public DataBindPage()
	{
		InitializeComponent();
	}

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        valueLabel.Text = e.NewValue.ToString("F3"); 
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        count++;
        ((Button)sender).Text = $"you have clicked {count} times";
    }
}