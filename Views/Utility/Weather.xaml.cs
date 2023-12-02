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
		currentTemperature.Text = $"当前温度:{data.temp}℃";
		feelTemperature.Text = $"体感温度{data.feelsLike}℃";
		windDirection.Text = $"风向:{data.windDir}";
		windSpeed.Text = $"风速:{data.windSpeed}km/h";
		var time = DateTime.Parse(data.obsTime).ToString();
		getTime.Text = $"数据更新时间:{time}";
	}

	private void Refresh(object sender, EventArgs e)
    {
		OnAppearing();
    }
}