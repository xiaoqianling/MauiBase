using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MauiBase.Data
{
    class WeatherService
    {
        string weatherURL = "https://devapi.qweather.com/v7/weather/now";
        string key = "117211697ffe4aa08073211f8d1544bf";
        public WeatherService() { }
        public async Task<WeatherData> GetWeatherData(double latitude, double longitude)
        {
            var query = $"{weatherURL}?key={key}&location={longitude},{latitude}";
            var client = new HttpClient(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip });
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var response = await client.GetAsync(query);
            Debug.WriteLine(query);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"json:{json}");
                var rootData = JsonSerializer.Deserialize<WeatherRootobject>(json);
                Debug.WriteLine(rootData.ToString());
                return rootData.now;
            }
            else
            {
                // 请求失败
                return null;
            }
        }
    }

    public class WeatherRootobject
    {
        public string code { get; set; }
        public string updateTime { get; set; }
        public WeatherData now { get; set; }
    }

    public class WeatherData
    {
        public string obsTime { get; set; }
        public string temp { get; set; }
        public string feelsLike { get; set; }
        public string icon { get; set; }
        public string text { get; set; }
        public string wind360 { get; set; }
        public string windDir { get; set; }
        public string windScale { get; set; }
        public string windSpeed { get; set; }
        public string humidity { get; set; }
        public string precip { get; set; }
        public string pressure { get; set; }
        public string vis { get; set; }
        public string cloud { get; set; }
        public string dew { get; set; }
    }
}
