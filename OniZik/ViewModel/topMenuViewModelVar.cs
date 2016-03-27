using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WpfApplication1.Util;
using WpfApplication1.View;



namespace WpfApplication1
{
    public partial class topMenuViewModel : INotifyPropertyChanged
    {
        private MainWindow mainWindow;

        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand fluxOpener { get; set; }
        public RelayCommand fileOpener { get; set; }
        public RelayCommand folderOpener { get; set; }
        public RelayCommand folderBrowser { get; set; }
        public RelayCommand goNext { get; set; }
        public RelayCommand goPrev { get; set; }
        public RelayCommand playMedia { get; set; }
        public RelayCommand pauseMedia { get; set; }
        public RelayCommand stopMedia { get; set; }
        public RelayCommand muteVol { get; set; }
        public RelayCommand unmuteVol { get; set; }
        public RelayCommand playlistGenerator { get; set; }
        public RelayCommand ReadFluxBtn { get; set; }
        public RelayCommand closeBrowseFolder { get; set; }
        public RelayCommand setFullScreen { get; set; }
        public RelayCommand closeapp { get; set; }
        public RelayCommand aboutOpener { get; set; }
        public RelayCommand aboutCloser { get; set; }
        public RelayCommand fluxCloser { get; set; }
        public RelayCommand createPlayList { get; set; }
        public RelayCommand importPlayList { get; set; }
        public RelayCommand takeScreenShot { get; set; }

        private bool _imageCheck;
        private bool _videoCheck;
        private bool _audioCheck;
        private bool _recurCheck;

        public bool imageCheck
        {
            get
            {return _imageCheck;}
            set
            {
                _imageCheck = value;
                FirePropertyChanged("imageCheck");
            }
        }
        public bool videoCheck
        {
            get
            {return _videoCheck;}
            set
            {
                _videoCheck = value;
                FirePropertyChanged("videoCheck");
            }
        }
        public bool audioCheck
        {
            get
            {return _audioCheck;}
            set
            {
                _audioCheck = value;
                FirePropertyChanged("audioCheck");
            }
        }
        public bool recurCheck
        {
            get
            {return _recurCheck;}
            set
            {
                _recurCheck = value;
                FirePropertyChanged("recurCheck");
            }
        }

        private string _fluxPath;
        public string fluxPath
        {
            get
            { return _fluxPath; }
            set
            {
                _fluxPath = value;
                FirePropertyChanged("fluxPath");
            }
        }

        private string _browsePath;
        public string browsePath
        {
            get
            {return _browsePath;}
            set
            {
                _browsePath = value;
                FirePropertyChanged("browsePath");
            }
        }

        private bool _browseIsOpen;
        public bool browseIsOpen
        {
            get { return _browseIsOpen; }
            set
            {
                if (_browseIsOpen == value) return;
                _browseIsOpen = value;
                FirePropertyChanged("browseIsOpen");
            }
        }

        private bool _aboutIsOpen;
        public bool aboutIsOpen
        {
            get { return _aboutIsOpen; }
            set
            {
                if (_aboutIsOpen == value) return;
                _aboutIsOpen = value;
                FirePropertyChanged("aboutIsOpen");
            }
        }

        private bool _fluxIsOpen;
        public bool fluxIsOpen
        {
            get { return _fluxIsOpen; }
            set
            {
                if (_fluxIsOpen == value) return;
                _fluxIsOpen = value;
                FirePropertyChanged("fluxIsOpen");
            }
        }

        public string aboutText
        {
            get { return About.aboutText; }
            set
            {
                About.aboutText = value;
                FirePropertyChanged("aboutIsOpen");
            }
        }

        string[] playableVideo = new[] {
            ".mov", ".mkv", ".aaf", ".3gp", ".gif", ".asf", ".avchd", ".avi", ".cam", ".dat", ".dsh", ".dvr - ms", ".flv", ".m1v", ".m2v", ".fla", ".flr", ".sol", ".m4v", ".wrap", ".mng", ".mov", ".mpeg", ".mpg", ".mpe", ".mp4", ".mxf", ".rm", ".svi", ".smi", ".swf", ".wmv", ".wtv",
            };
        string[] playableAudio = new[] {
            ".8svx", ".16svx", ".aif", ".aifc", ".aiff", ".au", ".bwf", ".cdda", ".raw", ".wav", ".flac", ".la", ".pac", ".m4a", ".ape", ".ofr", ".ofs", ".off", ".rka", ".shn", ".tak", ".tta", ".wv", ".brstm", ".dts", ".dtshd", ".dtsma", ".ast", ".amr", ".mp2", ".mp3", ".psx", ".gsm", ".wma", ".aac", ".m4a", ".m4p", ".mpc", ".vqf", ".ra", ".rm", ".ots", ".swa", ".vox", ".voc", ".dwd", ".smp"
            };
        string[] playableImage = new[] {
            ".jpg", ".jpeg", ".png", ".gif", ".bmp"
            };
    }
}
