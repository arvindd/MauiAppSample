using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location = MauiAppSample.Models.Location;

namespace MauiAppSample.ViewModels
{
    public class LocationViewCellVM: BaseViewModel
    {
        public LocationViewCellVM(Location loc) : base("Location") 
        { 
            _location = loc;
        }

        private readonly Location _location;

        public float Latitude => _location.Latitude;
        public float Longitude => _location.Longitude;
    }
}
