using Microsoft.Maui.Graphics;

namespace MauiBase.Views;

public partial class ColorSelectPage : ContentPage
{
	public ColorSelectPage()
	{
		InitializeComponent();
		Initial();
	}

    private void Initial()
	{
        ViewModels.ColorSelectViewModel colorSelect = new() { HSLColor = Colors.Aqua, RGBColor = Colors.MediumPurple };
		colorSelect.HSLColorHex = colorSelect.HSLColor.ToHex();
		BindingContext = colorSelect;
	}
}