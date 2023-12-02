namespace MauiBase.Views;

public partial class GesturesPage : ContentPage
{
	public GesturesPage()
	{
		InitializeComponent();
	}

    void OnDragStarting(object sender, DragStartingEventArgs e)
    {
        activity.IsRunning = true;
        e.Data.Text = "My text data goes here";
    }

    void OnDragOver(object sender, DragEventArgs e)
    {
        e.AcceptedOperation = DataPackageOperation.None;
    }
}