using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppSample.Models
{
    /// <summary>
    /// Temperature value and associated colour
    /// </summary>
    public class Location
    {
        public Location(float latitude, float longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public float Latitude { get; }

        public float Longitude { get; }
    }
}
