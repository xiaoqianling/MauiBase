namespace MauiBase.Views;

public partial class NewWindowPage : ContentPage
{
	public NewWindowPage()
	{
		InitializeComponent();
	}

    private void NewWindow(object sender, EventArgs e)
    {
        var newWindow = new ContentPage
        {
            Content = new Label
            {
                Text = "New Window"
            }
        };

        // 在MAUI中显示新窗口
        Application.Current.MainPage.Navigation.PushAsync(newWindow);
    }

    private async void BtnDisplayAlert(object sender, EventArgs e)
    {
        await DisplayAlert("欢迎！", "感谢支持", "确认", "取消");

    }
    private async void BtnDisplaySheet(object sender, EventArgs e)
    {
        await DisplayActionSheet("ActionSheet: Send to?", "Cancel", null, "Email", "Twitter", "Facebook");
    }
    private async void BtnDisplayPrompt(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("请输入您的用户名", null, accept:"确认", cancel:"取消");
    }
}