using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication1.Model
{
    public class YoutubeItem
    {
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public int Id { get; set; }
        public ICommand PlaySearchedVideo { get; set; }
        public YoutubeItem(string name, string thumbnail, int id, ICommand playSearchedVideo)
        {
            Name = name;
            Thumbnail = thumbnail;
            Id = id;
            PlaySearchedVideo = playSearchedVideo;
        }
    }
}
