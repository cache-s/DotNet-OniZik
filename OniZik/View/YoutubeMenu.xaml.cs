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
using WpfApplication1.View;

namespace WpfApplication1.View
{
    /// <summary>
    /// Interaction logic for YoutubeMenu.xaml
    /// </summary>
    public partial class YoutubeMenu : UserControl
    {
        public YoutubeMenu()
        {
            try {
                InitializeComponent();
            } catch (Exception ex)
            {
                Console.Error.WriteLine("Error init" + ex);
            }
        }

        public void setMainWindow(MainWindow _window)
        {
            this.DataContext = new YoutubeMenuViewModel(_window);
        }
    }
}
