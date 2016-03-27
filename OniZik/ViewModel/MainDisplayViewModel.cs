using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WpfApplication1.Util;
using WpfApplication1.View;
using WpfApplication1.ViewModel;

namespace WpfApplication1
{
    class MainDisplayViewModel
    {

        private MainWindow mainWindow;
        private MediaFunctions utils;

        public bool fullScreen = false;
        TimeSpan _position;
        DispatcherTimer _timer = new DispatcherTimer();
        public DispatcherTimer showBar = new DispatcherTimer();
        public bool repeat = false;
        public bool shuffle = false;
        public bool isMusic = false;

        public MainDisplayViewModel(MainWindow window)
        {
            mainWindow = window;
            
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += new EventHandler(ticktock);
            _timer.Start();
        }

        void ticktock(object sender, EventArgs e)
        {
            if (mainWindow.mainDisplay.mediaElement.NaturalDuration.HasTimeSpan)
            {
                mainWindow.controlMenu.progressBar.Value = mainWindow.mainDisplay.mediaElement.Position.TotalSeconds;
                mainWindow.controlMenu.timeVideo.Text = mainWindow.mainDisplay.mediaElement.Position.ToString(@"mm\:ss");
            }
        }

        public void MouseMove(object sender, MouseEventArgs e)
        {
            utils = new MediaFunctions(mainWindow);

            if (fullScreen == true)
            {
                showBar.Interval = TimeSpan.FromSeconds(2);
                showBar.Tick += new EventHandler(callBar);
                showBar.Start();
                utils.show(mainWindow.controlMenu);
                Mouse.OverrideCursor = Cursors.Arrow;
            }
        }

        private void callBar(object sender, EventArgs e)
        {
            utils = new MediaFunctions(mainWindow);
            utils.hide(mainWindow.controlMenu);
            Mouse.OverrideCursor = Cursors.None;
        }

        public void MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            utils = new MediaFunctions(mainWindow);
            if (fullScreen == false)
            {
                utils.fullscreen();
            }
            else
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                utils.downscreen();
            }
        }

        public void mediaOpened(object sender, RoutedEventArgs e)
        {
            utils = new MediaFunctions(mainWindow);
            if (!mainWindow.mainDisplay.mediaElement.NaturalDuration.HasTimeSpan)
            {
                //utils.stopMedia();
                return;
            }
            else
            {
                mainWindow.controlMenu.timeVideo.Text = mainWindow.mainDisplay.mediaElement.Position.ToString(@"mm\:ss");
                mainWindow.controlMenu.endTimeVideo.Text = mainWindow.mainDisplay.mediaElement.NaturalDuration.TimeSpan.ToString(@"mm\:ss");
                _position = mainWindow.mainDisplay.mediaElement.NaturalDuration.TimeSpan;
                mainWindow.controlMenu.progressBar.Minimum = 0;
                mainWindow.controlMenu.progressBar.Maximum = _position.TotalSeconds;

                mainWindow.controlMenu.volumeBar.Minimum = 0;
                mainWindow.controlMenu.volumeBar.Value = 0.5;
                mainWindow.controlMenu.volumeBar.Maximum = 1;
            }
        }

        public void mediaMusicEnded(object send, RoutedEventArgs e)
        {
            mainWindow.mainDisplay.mediaMusic.Position = TimeSpan.Zero;
            utils.startMusicMedia();
        }

        public void mediaEnded(object sender, RoutedEventArgs e)
        {
            playlistViewModel lvm = mainWindow.playlistMenu.DataContext as playlistViewModel;
            LibraryViewModel libvm = mainWindow.libraryMenu.DataContext as LibraryViewModel;

            utils = new MediaFunctions(mainWindow);
            string path = utils.getCurentPath();

            if (repeat == true)
            {
                mainWindow.mainDisplay.mediaElement.Position = TimeSpan.Zero;
                utils.playMedia(path);
            }
            else if (lvm.playingPlaylist == true)
                lvm.playPlayList(null);
            else if (libvm.playingMedias == true)
                libvm.playMedias(null);
            else if (isMusic == true)
            {
                utils.stopMusicMedia();
                isMusic = false;
            }
            else
            {
                utils.stopMedia();
            }
        }
    }
}