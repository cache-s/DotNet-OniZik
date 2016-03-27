using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication1.Util;
using WpfApplication1.View;
using System.Net;
using System.IO;
using System.Xml;
using System.Threading;

namespace WpfApplication1.ViewModel
{
    class LyricsViewModel : INotifyPropertyChanged
    {
        private MainWindow window;
        private int CurrentWidth = 200;
        private Boolean ExpandedVis = true;
        private Boolean CollapsedVis = false;
        private string lyrics, SongName, ArtistName, AlbumName;
        public event PropertyChangedEventHandler PropertyChanged;
        public RelayCommand SwitchPanelSizeRelay { get; set; }
        public string Lyrics
        {
            get { return this.lyrics; }
            set
            {
                lyrics = value;
                FirePropertyChanged("Lyrics");
            }
        }
        public LyricsViewModel(MainWindow _window)
        {
            this.window = _window;
            SwitchPanelSizeRelay = new RelayCommand(SwitchPanelSize);
        }

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
            Lyrics = "Chargement des paroles pour " + SongName;
            new Thread(delegate () {
                GetLyrics();
            }).Start();
        }

        private void GetLyrics()
        {
            SongName = Uri.EscapeDataString(SongName);
            ArtistName= Uri.EscapeDataString(ArtistName);
            string url = "http://api.musixmatch.com/ws/1.1/track.search?apikey=58a0690db314a1dbd74f19b60e377abc&q_artist=" + ArtistName + "&q_track=" + SongName +"&format=xml&page_size=1&f_has_lyrics=1";
            string id_track = null;
            string lyrics = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream resStream = response.GetResponseStream();
            StreamReader s = new StreamReader(resStream);
            XmlDocument xm = new XmlDocument();
            xm.LoadXml(s.ReadToEnd());
            XmlNodeList elemList = xm.GetElementsByTagName("track_id");
            for (int i = 0; i < elemList.Count; i++)
            {
                id_track = elemList[i].InnerXml;
            }
            url = "http://api.musixmatch.com/ws/1.1/track.lyrics.get?apikey=58a0690db314a1dbd74f19b60e377abc&track_id=" + id_track + "&format=xml";
            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();

            resStream = response.GetResponseStream();
            s = new StreamReader(resStream);
            xm = new XmlDocument();
            xm.LoadXml(s.ReadToEnd());
            elemList = xm.GetElementsByTagName("lyrics_body");
            for (int i = 0; i < elemList.Count; i++)
            {
                lyrics = elemList[i].InnerXml;
            }
            if (lyrics.Equals(""))
                Lyrics = "Aucune paroles trouvées";
            else
                Lyrics = lyrics + "\n\nThis lyrics were provided by Musixmatch";
        }
    }
}
