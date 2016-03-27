using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.Util
{
    public class Youtube
    {
        public List<Video> Videos { get; set; }
        public Youtube()
        {
            Videos = new List<Video>();
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
    }
}
