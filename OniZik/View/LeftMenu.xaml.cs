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
    /// Logique d'interaction pour LeftMenu.xaml
    /// </summary>
    public partial class LeftMenu : UserControl
    {
        public LeftMenu()
        {
            InitializeComponent();
        }

        public void setMainWindow(MainWindow window)
        {
            this.DataContext = new LeftMenuViewModel(window);
        }
    }
}
