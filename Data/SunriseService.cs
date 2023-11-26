using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiBase.Data
{
    internal class SunriseService
    {
        const string SunriseSunsetServiceUrl = "https://api.sunrise-sunset.org";

        // 发送http请求 根据地理位置获取日升日落时间
        public async Task<(DateTime Sunrise, DateTime Sunset)> GetSunriseSunsetTimes(double latitude, double longitude)
        {
            //https://api.sunrise-sunset.org/json?lat=39.924901728059424&lng=119.55089783548094&date=today
            var query = $"{SunriseSunsetServiceUrl}/json?lat={latitude}&lng={longitude}&date=today";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var json = await client.GetStringAsync(query);
            Debug.WriteLine(json);
            // 将api返回的json字符串解析
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var data = JsonSerializer.Deserialize<SunriseSunsetData>(json, options);

            return (DateTime.Parse(data.Results.Sunrise), DateTime.Parse(data.Results.Sunset));
        }

        class SunriseSunsetData
        {
#pragma warning disable 0649
            // Field is only set via JSON deserialization, so disable warning that the field is never set.
            //public SunriseSunsetResults Results;
            public SunriseSunsetResults Results { get; set; }
#pragma warning restore 0649
        }

        class SunriseSunsetResults
        {
#pragma warning disable 0649
            // Fields are only set via JSON deserialization, so disable warning that the fields are never set.
            public string Sunrise { get; set; }
            public string Sunset { get; set; }
#pragma warning restore 0649
        }
    }
}
