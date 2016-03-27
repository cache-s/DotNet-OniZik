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

namespace WpfApplication1.View
{
    /// <summary>
    /// Logique d'interaction pour ControlMenu.xaml
    /// </summary>
    public partial class ControlMenu : UserControl
    {
        MainWindow window;

        public ControlMenu()
        {
            InitializeComponent();
        }

        public void setMainWindow(MainWindow _window)
        {
            window = _window;
            this.DataContext = new ControlMenuViewModel(_window);
        }

        private void progressBar_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ControlMenuViewModel cmv = window.controlMenu.DataContext as ControlMenuViewModel;

            cmv.progressBarClicked(sender, e);
        }

        private void volumeBar_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ControlMenuViewModel cmv = window.controlMenu.DataContext as ControlMenuViewModel;

            cmv.volumeBarClicked(sender, e);
        }
    }
}
