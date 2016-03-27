using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApplication1.Util
{
    public class Radios
    {
        public List<Station> Stations { get; set; }
        public Radios()
        {
            Stations = new List<Station>();
        }
    }

    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Flow { get; set; }
        public string Image { get; set; }
    }
}
