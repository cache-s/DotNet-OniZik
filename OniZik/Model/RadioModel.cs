using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WpfApplication1.Model
{
    public class RadioItem
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }
        public ICommand PlayRadio { get; set; }
        public ICommand DeleteRadio { get; set; }
        public RadioItem(string name, int id, string image, ICommand playRadio, ICommand deleteRadio)
        {
            Name = name;
            Id = id;
            Image = image;
            PlayRadio = playRadio;
            DeleteRadio = deleteRadio;
        }
    }
}
