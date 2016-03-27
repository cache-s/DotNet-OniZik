using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using WpfApplication1.Util;
using WpfApplication1.View;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System.Collections.ObjectModel;
using WpfApplication1.Model;
using System.Net;
using System.IO;
using System.Threading;
using System.Timers;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class YoutubeMenuViewModel : INotifyPropertyChanged
    {
        private MainWindow window;
        public event PropertyChangedEventHandler PropertyChanged;

        private List<string> videoInfos;

        private string _youtubeURL;
        private string _myResearch;
        private string _thumbnail;
        private string _videoName;
        private bool _delVis = false;
       
        public RelayCommand runVideo { get; set; }
        public RelayCommand startSearch { get; set; }
        public RelayCommand PlaySearchedVideo { get; set; }
        public RelayCommand HideVideo { get; set; }
        private ObservableCollection<YoutubeItem> _youtubeList;
        public ObservableCollection<YoutubeItem> YoutubeList
        {
            get { return _youtubeList; }
            set
            {
                _youtubeList = value;
                FirePropertyChanged("YoutubeList");
            }
        }

        public Visibility DelVisib
        {
            get { return _delVis ? Visibility.Visible : Visibility.Collapsed; }
            set
            {
                if (value == Visibility.Visible)
                    _delVis = true;
                else
                    _delVis = false;
                FirePropertyChanged("DelVisib");
            }
        }
        public YoutubeMenuViewModel(MainWindow _window)
        {
            window = _window;
            runVideo = new RelayCommand(playYoutube);
            startSearch = new RelayCommand(searchOnYoutube);
            PlaySearchedVideo = new RelayCommand(playSearchedVideoYoutube);
            YoutubeList = new ObservableCollection<YoutubeItem> { };
            HideVideo = new RelayCommand(hideVideo);
        }

        public string Thumbnail
        {
            get { return _thumbnail; }
            set
            {
                _thumbnail = value;
                FirePropertyChanged("Thumbnail");
            }
        }

        public string VideoName
        {
            get { return _videoName; }
            set
            {
                _videoName = value;
                FirePropertyChanged("VideoName");
            }
        }

        public string YoutubeURL
        {
            get { return _youtubeURL; }
            set
            {
                _youtubeURL = value;
                FirePropertyChanged("YoutubeURL");
            }
        }

        public string MyResearch
        {
            get { return _myResearch; }
            set
            {
                _myResearch = value;
                FirePropertyChanged("MyResearch");
            }
        }

        private void playSearchedVideoYoutube(object sender)
        {
            int id = (int)sender;
            string[] infos = splitForId(videoInfos[id]);

            window.youtubeMenu.VideoPanel.Visibility = Visibility.Hidden;
            playVideoYoutube(infos[1]);
        }

        private void hideVideo(object obj)
        {
            window.youtubeMenu.webBrowser1.ShowYouTubeVideo(null);
            window.youtubeMenu.browser.Visibility = Visibility.Collapsed;
            DelVisib = Visibility.Collapsed;
            
        }

        private string[] splitForId(string toSplit)
        {
            string[] splitted = null;

            if (toSplit == null)
                return null;
            splitted = toSplit.Split('|');
            return (splitted);
        }
        private void getYtSearch()
        {
            videoInfos = new YoutubeSearch.Search().Run(MyResearch).Result;
        }

        private async void searchOnYoutube(object sender)
        {
            YoutubeList.Clear();
            Youtube youtube = null;
            window.youtubeMenu.VideoPanel.Visibility = Visibility.Visible;

            try
            {
                new Thread(delegate ()
                {
                    getYtSearch();
                }).Start();

                youtube = new Youtube();
                if (videoInfos != null)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        int id = 0;

                        var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                        {
                            ApiKey = "AIzaSyDhFIZosaBiPZybhmG0FLWIxsZsf_adu0E",
                            ApplicationName = this.GetType().ToString()
                        });

                        string[] videoId = splitForId(videoInfos[id]);

                        if (youtube.Videos.Count != 0)
                            id = youtube.Videos[youtube.Videos.Count - 1].Id + 1;
                        Util.Video video = new Util.Video
                        {
                            Id = id,
                            Name = getName(id),
                            Thumbnail = getThumbnail(id)
                        };

                        youtube.Videos.Add(video);
                        VideoName = "";
                        Thumbnail = "";
                        YoutubeList.Add(new YoutubeItem(video.Name, video.Thumbnail, video.Id, PlaySearchedVideo));
                    }
                }
                else
                {
                    await SearchTest();
                    searchOnYoutube(null);
                }
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.Error.WriteLine("Error: " + e.Message);
                }
            }

        }

        private async Task SearchTest()
        {
            await Task.Delay(2000);
        }

        private string getName(int id)
        {
            try {
                string[] infos = splitForId(videoInfos[id]);
                string name = infos[0];
                return (name);
            }catch (Exception ex)
            {
                Console.Error.WriteLine("error in getname Youtube : " + ex);
                return null;
            }
        }

        private string getThumbnail(int id)
        {
            string[] infos = splitForId(videoInfos[id]);
            string path = "http://img.youtube.com/vi/" + infos[1] + "/0.jpg";

            if (infos[1].Length != 11)
                return (path = "pack://application:,,,/WpfApplication1;component/Resources/noImage.png");
            return (path);
        }

        private void playVideoYoutube(string videoId)
        {
            if (videoId == null)
                return;
            window.youtubeMenu.browser.Visibility = Visibility.Visible;
            DelVisib = Visibility.Visible;
            window.youtubeMenu.webBrowser1.ShowYouTubeVideo(videoId);
        }

        private void playYoutube(object sender)
        {
            string newPath = getGoodYTPath(YoutubeURL);

            if (newPath == null)
                return;
            playVideoYoutube(newPath);
        }

        private string getGoodYTPath(string path)
        {
            string[] videoPath = null;

            if (path == null)
                return null;

            videoPath = path.Split('=');
            if (videoPath[0] != "https://www.youtube.com/watch?v")
                return (null);

            if (videoPath[1].Length < 11)
            {
                MessageBox.Show("Vidéo Youtube Incorrect");
                return null;
            }
            return (videoPath[1]);
        }

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
