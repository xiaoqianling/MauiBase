using MauiBase.Data;

namespace MauiBase.Views;

public partial class Weather : ContentPage
{
	ILatLongService LatLongService { get; set; }
	public Weather()
	{
		InitializeComponent();
		LatLongService = new LatLongService();
	}

    protected override async void OnAppearing()
	{
		base.OnAppearing();
        activityWaiting.IsRunning = true;
		var data = await GetWeatherData();
        activityWaiting.IsRunning = false;
        InitializeUI(data);
    }

	async Task<WeatherData> GetWeatherData()
	{
		var location = await LatLongService.GetLatLong();
		var data = await new WeatherService().GetWeatherData(location.Latitude, location.Longitude);
		return data;
	}

     void InitializeUI(WeatherData data)
    {
		text.Text = $"{data.text}";
		currentTemperature.Text = $"��ǰ�¶�:{data.temp}��";
		feelTemperature.Text = $"����¶�{data.feelsLike}��";
		windDirection.Text = $"����:{data.windDir}";
		windSpeed.Text = $"����:{data.windSpeed}km/h";
		var time = DateTime.Parse(data.obsTime).ToString();
		getTime.Text = $"���ݸ���ʱ��:{time}";
	}

	private void Refresh(object sender, EventArgs e)
    {
		OnAppearing();
    }
}