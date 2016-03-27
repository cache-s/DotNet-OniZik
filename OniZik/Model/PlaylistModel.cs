using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication1.Model
{
    public class PlaylistItem
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public ICommand Command { get; set; }
        public ICommand DelCommand { get; set; }
        public PlaylistItem(string name, int id, ICommand command, ICommand delCommand)
        {
            Name = name;
            Id = id;
            Command = command;
            DelCommand = delCommand;
        }
    }
}
