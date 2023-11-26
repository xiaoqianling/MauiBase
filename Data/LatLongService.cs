using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBase.Data
{
    internal class LatLongService : ILatLongService
    {
        // 获取设备的经纬度
        public async Task<(double Latitude, double Longitude)> GetLatLong()
        {
            var latLoc = 0.0;
            var longLoc = 0.0;

            var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            if (status == PermissionStatus.Granted)
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLocationAsync(request);
                latLoc = location.Latitude;
                longLoc = location.Longitude;
            }
            return (latLoc, longLoc);
        }
    }
}
