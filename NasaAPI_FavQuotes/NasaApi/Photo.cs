using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NasaApi
{
    internal class Photo
    {
        public int id { get; set; }
        public int sol { get; set; }

        //[JsonIgnore]
        //public Camera camera { get; set; }
        public string img_src { get; set; }
        public string earth_date { get; set; }
        
        //[JsonIgnore]
        //public Rover rover { get; set; }
    }
}
