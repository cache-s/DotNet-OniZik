using System;
using System.ComponentModel;
using System.Windows.Input;
using WpfApplication1.Util;
using WpfApplication1.ViewModel;
using WpfApplication1.View;

namespace WpfApplication1
{
    class ControlMenuViewModel : INotifyPropertyChanged
    {
        private MainWindow window;
        private MainDisplayViewModel mwmv;

        private static double volume;

        private int timeClicked = 0;
        private MediaFunctions utils;
        public event PropertyChangedEventHandler PropertyChanged;

        private string _speed;

        public RelayCommand prevBtnClick { get; set; }
        public RelayCommand nextBtnClick { get; set; }
        public RelayCommand playButton_Click { get; set; }
        public RelayCommand pauseButton_Click { get; set; }
        public RelayCommand fullscreenButton_Click { get; set; }
        public RelayCommand downScreenButton_Click { get; set; }
        public RelayCommand shuffleButton_Click { get; set; }
        public RelayCommand shuffleButtonSelected_Click { get; set; }
        public RelayCommand repeatButton_Click { get; set; }
        public RelayCommand repeatButtonSelected_Click { get; set; }
        public RelayCommand volumeButton_Click { get; set; }
        public RelayCommand volumeButtonOff_Click { get; set; }
        public RelayCommand SliderValueRelay { get; set; }
        public RelayCommand SpeedClicked { get; set; }

        public ControlMenuViewModel(MainWindow window)
        {
            this.window = window;
            Speed = "x1";
            utils = new MediaFunctions(window);
            mwmv = window.mainDisplay.DataContext as MainDisplayViewModel;

            prevBtnClick = new RelayCommand(prevBtn);
            nextBtnClick = new RelayCommand(nextBtn);
            playButton_Click = new RelayCommand(playButton);
            pauseButton_Click = new RelayCommand(pauseMediaButton);
            fullscreenButton_Click = new RelayCommand(fullscreenButton);
            downScreenButton_Click = new RelayCommand(downscreenButton);
            shuffleButton_Click = new RelayCommand(shuffleOn);
            shuffleButtonSelected_Click = new RelayCommand(shuffleOff);
            repeatButton_Click = new RelayCommand(repeatOn);
            repeatButtonSelected_Click = new RelayCommand(repeatOff);
            volumeButtonOff_Click = new RelayCommand(volumeUnMuted);
            volumeButton_Click = new RelayCommand(volumeMuted);
            SpeedClicked = new RelayCommand(manageSpeed);
        }

        public string Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                FirePropertyChanged("Speed");
            }
        }

        private void manageSpeed(object sender)
        {
            if (timeClicked == 0)
            {
                window.mainDisplay.mediaElement.SpeedRatio = (double)2;
                timeClicked = 1;
                Speed = "x2";
            }
            else if (timeClicked == 1)
            {
                window.mainDisplay.mediaElement.SpeedRatio = (double)4;
                timeClicked = 2;
                Speed = "x4";
            }
            else if (timeClicked == 2)
            {
                window.mainDisplay.mediaElement.SpeedRatio = (double)8;
                timeClicked = 3;
                Speed = "x8";
            }
            else if (timeClicked == 3)
            {
                window.mainDisplay.mediaElement.SpeedRatio = (double)1;
                timeClicked = 0;
                Speed = "x1";
            }
        }

        public void progressBarClicked(object sender, MouseButtonEventArgs e)
        {
             double MousePosition = e.GetPosition(window.controlMenu.progressBar).X;
             int pos = Convert.ToInt32(window.controlMenu.progressBar.Value = SetProgressBarValue(MousePosition));
             window.mainDisplay.mediaElement.Position = new TimeSpan(0, 0, 0, pos, 0);
             window.controlMenu.timeVideo.Text = window.mainDisplay.mediaElement.Position.ToString(@"mm\:ss");
        }

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void nextBtn(object sender)
        {
            utils.nextMedia();
        }

        private void prevBtn(object sender)
        {
            utils.prevMedia();
        }

        private void pauseMediaButton(object sender)
        {
            utils.pauseMedia();
        }

        private void fullscreenButton(object sender)
        {
            utils.fullscreen();
        }

        private void downscreenButton(object send)
        {
            utils.downscreen();
        }

        public void volumeMuted(object sender)
        {
            setVolume();
            window.controlMenu.volumeBar.Value = 0;
            window.mainDisplay.mediaElement.Volume = 0;
            utils.hide(window.controlMenu.volumeButton);
            utils.show(window.controlMenu.volumeButtonOff);
        }

        public void volumeUnMuted(object sender)
        {
            window.controlMenu.volumeBar.Value = volume;
            window.mainDisplay.mediaElement.Volume = volume;
            utils.hide(window.controlMenu.volumeButtonOff);
            utils.show(window.controlMenu.volumeButton);
        }

        private void setVolume()
        {
            volume = window.controlMenu.volumeBar.Value;
        }

        private void playButton(object sender)
        {
            utils.playMedia(null);
        }

        private void shuffleOff(object sende)
        {
            mwmv.shuffle = false;
            utils.hide(window.controlMenu.shuffleButtonSelected);
            utils.show(window.controlMenu.shuffleButton);
        }

        private void shuffleOn(object sender)
        {
            mwmv.shuffle = true;
            utils.show(window.controlMenu.shuffleButtonSelected);
            utils.hide(window.controlMenu.shuffleButton);
        }

        private void repeatOff(object sender)
        {
            mwmv.repeat = false;
            utils.hide(window.controlMenu.repeatButtonSelected);
            utils.show(window.controlMenu.repeatButton);
        }

        private void repeatOn(object sender)
        {
            mwmv.repeat = true;
            utils.show(window.controlMenu.repeatButtonSelected);
            utils.hide(window.controlMenu.repeatButton);
        }

        private double SetProgressBarValue(double MousePosition)
        {
            double ratio = MousePosition / window.controlMenu.progressBar.ActualWidth;
            double ProgressBarValue = ratio * window.controlMenu.progressBar.Maximum;
            return ProgressBarValue;
        }

        public void volumeBarClicked(object sender, MouseButtonEventArgs e)
        {
            var x = e.GetPosition(window.controlMenu.volumeBar).X;
            var ratio = x / window.controlMenu.volumeBar.ActualWidth;
            window.mainDisplay.mediaElement.Volume = ratio * window.controlMenu.volumeBar.Maximum;
            window.controlMenu.volumeBar.Value = ratio * window.controlMenu.volumeBar.Maximum;
        }
    }
}
