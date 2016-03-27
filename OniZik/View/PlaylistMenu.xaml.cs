using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication1.ViewModel;

namespace WpfApplication1.View
{
    /// <summary>
    /// Logique d'interaction pour PlaylistMenu.xaml
    /// </summary>
    public partial class PlaylistMenu : UserControl
    {
        public PlaylistMenu()
        {
            InitializeComponent();
        }

        public void setMainWindow(MainWindow mainWindow)
        {
            this.DataContext = new playlistViewModel(mainWindow);
        }

        public void addFileToPlaylist(string file)
        {
            string[] send = new string[1];
            send[0] = file;
        }
    }
}
