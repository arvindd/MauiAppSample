using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Location = MauiAppSample.Models.Location;

namespace MauiAppSample.Services.Base;
internal abstract class LocationSensor : SensorService<Location> { }