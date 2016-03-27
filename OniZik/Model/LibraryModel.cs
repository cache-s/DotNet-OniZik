using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication1.Model
{
    public class LibraryItem
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Time { get; set; }
        public int Id { get; set; }
        public LibraryItem LibItem { get; set; }
        public ICommand Command { get; set; }
        public ICommand DelCommand { get; set; }
        public bool Playing { get; set; }
        public LibraryItem(string title, string artist, string album, string time, string name, string path, int id, bool playing, ICommand command, ICommand delCommand)
        {
            Title = title;
            Artist = artist;
            Album = album;
            Time = time;
            Name = name;
            Path = path;
            Id = id;
            Playing = playing;
            Command = command;
            DelCommand = delCommand;

            LibItem = this;
        }
    }
}

