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
using System.Windows.Shapes;
using WpfApplication1.View;

namespace WpfApplication1.View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainDisplay.setMainWindow(this);
            topMenu.setMainWindow(this);
            controlMenu.setMainWindow(this);
            lyricsMenu.setMainWindow(this);
            libraryMenu.setMainWindow(this);
            leftMenu.setMainWindow(this);
            playlistMenu.setMainWindow(this);
            radioMenu.setMainWindow(this);
            youtubeMenu.setMainWindow(this);
        }
    }
}
