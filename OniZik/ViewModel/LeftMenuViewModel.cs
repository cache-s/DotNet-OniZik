using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using WpfApplication1.Util;
using WpfApplication1.View;

namespace WpfApplication1.ViewModel
{
    class LeftMenuViewModel : INotifyPropertyChanged
    {
        MainWindow window;
        private BitmapImage coverImg;
        private string songName;
        private string artistName;
        private string albumName;
        private string searchText = "";
        private Boolean ExpandedVis = true;
        private Boolean CollapsedVis = false;
        private int CurrentWidth = 200;
        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand ShowPlaylistsRelay { get; set; }
        public RelayCommand ShowRadiosRelay { get; set; }
        public RelayCommand ShowMediasRelay { get; set; }
        public RelayCommand ShowYoutubeRelay { get; set; }
        public RelayCommand SwitchPanelSizeRelay { get; set; }
        public RelayCommand HomeRelay { get; set; }
        public BitmapImage CoverImage
        {
            get { return this.coverImg; }
            set
            {
                this.coverImg = value;
                FirePropertyChanged("CoverImage");
            }
        }
        public string SongName
        {
            get { return this.songName; }
            set
            {
                this.songName = value;
                FirePropertyChanged("SongName");
            }
        }
        public string ArtistName
        {
            get { return this.artistName; }
            set
            {
                this.artistName = value;
                FirePropertyChanged("ArtistName");
            }
        }
        public string AlbumName
        {
            get { return this.albumName; }
            set
            {
                this.albumName = value;
                FirePropertyChanged("AlbumName");
            }
        }
        public string SearchText
        {
            get { return this.searchText; }
            set
            {
                if (value.Equals(""))
                    this.searchText = "Rechercher";
                else
                    this.searchText = value;
                FirePropertyChanged("SearchText");
            }
        }
        public Visibility CollapsedVisibility
        {
            get { return CollapsedVis ? Visibility.Visible : Visibility.Collapsed; }
            set
            {
                if (value == Visibility.Visible)
                    CollapsedVis = true;
                else
                    CollapsedVis = false;
                FirePropertyChanged("CollapsedVisibility");
            }
        }
        public Visibility ExpandedVisibility
        {
            get { return ExpandedVis ? Visibility.Visible : Visibility.Collapsed; }
            set
            {
                if (value == Visibility.Visible)
                    ExpandedVis = true;
                else
                    ExpandedVis = false;
                FirePropertyChanged("ExpandedVisibility");
            }
        }
        public int MenuWidth
        {
            get { return CurrentWidth; }
            set
            {
                CurrentWidth = value;
                FirePropertyChanged("MenuWidth");
            }
        }
        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public LeftMenuViewModel(MainWindow mainWindow)
        {
            window = mainWindow;
            ShowPlaylistsRelay = new RelayCommand(ShowPlaylists);
            ShowRadiosRelay = new RelayCommand(ShowRadios);
            ShowMediasRelay = new RelayCommand(ShowMedias);
            ShowYoutubeRelay = new RelayCommand(ShowYoutube);
            HomeRelay = new RelayCommand(ShowHome);
            SwitchPanelSizeRelay = new RelayCommand(SwitchPanelSize);
        }

        public void ShowPlaylists(object obj)
        {
            window.mainDisplay.mediaElement.Visibility = Visibility.Collapsed;
            window.playlistMenu.Visibility = Visibility.Visible;
            playlistViewModel p = window.playlistMenu.DataContext as playlistViewModel;
            p.SearchMedia(null);
            window.libraryMenu.Visibility = Visibility.Collapsed;
            window.radioMenu.Visibility = Visibility.Collapsed;
            window.youtubeMenu.Visibility = Visibility.Collapsed;
        }

        public void ShowRadios(object obj)
        {
            window.youtubeMenu.Visibility = Visibility.Collapsed;
            window.radioMenu.Visibility = Visibility.Visible;
            window.playlistMenu.Visibility = Visibility.Collapsed;
            window.libraryMenu.Visibility = Visibility.Collapsed;
            window.mainDisplay.mediaElement.Visibility = Visibility.Collapsed;
        }

        public void ShowYoutube(object obj)
        {
            window.youtubeMenu.Visibility = Visibility.Visible;
            window.radioMenu.Visibility = Visibility.Collapsed;
            window.playlistMenu.Visibility = Visibility.Collapsed;
            window.libraryMenu.Visibility = Visibility.Collapsed;
            window.mainDisplay.mediaElement.Visibility = Visibility.Collapsed;
        }

        public void ShowMedias(object obj)
        {
            window.youtubeMenu.Visibility = Visibility.Collapsed;
            window.radioMenu.Visibility = Visibility.Collapsed;
            window.mainDisplay.mediaElement.Visibility = Visibility.Collapsed;
            LibraryViewModel l = window.libraryMenu.DataContext as LibraryViewModel;
            l.printMedias();
            window.playlistMenu.Visibility = Visibility.Collapsed;
            window.libraryMenu.Visibility = Visibility.Visible;
        }

        public void ShowHome(object obj)
        {
            window.youtubeMenu.Visibility = Visibility.Collapsed;
            window.radioMenu.Visibility = Visibility.Collapsed;
            window.libraryMenu.Visibility = Visibility.Collapsed;
            window.playlistMenu.Visibility = Visibility.Collapsed;
            window.mainDisplay.mediaElement.Visibility = Visibility.Visible;
        }

        public void setCover(BitmapImage image)
        {
            if (image != null)
            {
                CoverImage = image;
            }
            else
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("pack://application:,,,/WpfApplication1;component/Resources/Playlist/titres.png");
                bitmap.EndInit();
                CoverImage = bitmap;
            }
        }

        private void SwitchPanelSize(object obj)
        {
            if (ExpandedVis == true)
            {
                CollapsedVisibility = Visibility.Visible;
                ExpandedVisibility = Visibility.Collapsed;
                MenuWidth = 40;
            }
            else
            {
                CollapsedVisibility = Visibility.Collapsed;
                ExpandedVisibility = Visibility.Visible;
                MenuWidth = 200;
            }
        }

        public void setInformation(string[] info)
        {
            if (info == null)
            {
                SongName = "Titre inconnu";
                ArtistName = "Artiste inconnu";
                AlbumName = "Album inconnu";
            }
            else
            {
                SongName = info[0];
                ArtistName = info[1];
                AlbumName = info[2];
            }
        }
    }
}
