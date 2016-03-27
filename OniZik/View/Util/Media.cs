using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Library
    {
        public List<Media> Titles { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public Library()
        {
            Titles = new List<Media>();
        }
    }

    public class Media
    {
        public enum eType
        {
            MUSIC,
            IMAGE,
            VIDEO,
            UNKNOWN
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public eType Type { get; set; }
    }

    public class Playlist
    {
        public List<Library> Playlists { get; set; }
        public Playlist()
        {
            Playlists = new List<Library>();
        }
    }
}
