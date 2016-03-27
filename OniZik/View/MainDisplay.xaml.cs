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
using System.Windows.Threading;
using WpfApplication1.Util;
using WpfApplication1.ViewModel;

namespace WpfApplication1.View
{
    /// <summary>
    /// Logique d'interaction pour MainDisplay.xaml
    /// </summary>
    public partial class MainDisplay : UserControl
    {
        MainWindow mainWindow;
        MainDisplayViewModel mwmv;

        public MainDisplay()
        {
            InitializeComponent();
        }

        public void setMainWindow(MainWindow _window)
        {
            mainWindow = _window;
            this.DataContext = new MainDisplayViewModel(_window);
            mwmv = mainWindow.mainDisplay.DataContext as MainDisplayViewModel;
        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            mwmv.MouseDoubleClick(sender, e);
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {   
            mwmv.MouseMove(sender, e);
        }

        private void mediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            mwmv.mediaOpened(sender, e);
        }

        private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            mwmv.mediaEnded(sender, e);
        }

        private void mediaMusic_MediaEnded(object sender, RoutedEventArgs e)
        {
            mwmv.mediaMusicEnded(sender, e);
        }
    }
}
