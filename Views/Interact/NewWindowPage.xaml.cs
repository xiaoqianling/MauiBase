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

        // ��MAUI����ʾ�´���
        Application.Current.MainPage.Navigation.PushAsync(newWindow);
    }

    private async void BtnDisplayAlert(object sender, EventArgs e)
    {
        await DisplayAlert("��ӭ��", "��л֧��", "ȷ��", "ȡ��");

    }
    private async void BtnDisplaySheet(object sender, EventArgs e)
    {
        await DisplayActionSheet("ActionSheet: Send to?", "Cancel", null, "Email", "Twitter", "Facebook");
    }
    private async void BtnDisplayPrompt(object sender, EventArgs e)
    {
        string result = await DisplayPromptAsync("�����������û���", null, accept:"ȷ��", cancel:"ȡ��");
    }
}