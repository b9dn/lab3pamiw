using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Configuration
{
    internal class BaseFilmEndpoint
    {
        public string Base_url { get; set; }
        public string AddFilmAsync { get; set; }
        public string DeleteFilmAsync { get; set; }
        public string GetFilmAsync { get; set; }
        public string UpdateFilmAsync { get; set; }

    }
}
