using GongSolutions.Wpf.DragDrop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Xml.Serialization;
using WpfApplication1.Model;
using WpfApplication1.Util;
using WpfApplication1.View;

namespace WpfApplication1.ViewModel
{
    public class playlistViewModel : INotifyPropertyChanged, GongSolutions.Wpf.DragDrop.IDropTarget
    {
        private MainWindow mainWindow;
        private MediaFunctions utils;
        private MainDisplayViewModel mwmv;

        private Boolean showAdd = false;
        private string _playlistName;
        private string _searchText = "";
        private string title;
        private string album;
        private string artist;
        private string time;
        private int lastId = -1;
        private int sortTitle = 0;
        private int sortArtist = 0;
        private int sortAlbum = 0;
        private int curPlaylist = -1;
        public bool playingPlaylist = false;
        public int currentListening;
        private ObservableCollection<LibraryItem> _libList;
        public RelayCommand ReadPlayListRelay { get; set; }
        public RelayCommand CreatePlaylistRelay { get; set; }
        public RelayCommand ShowPlaylistRelay { get; set; }
        public RelayCommand DeletePlaylistRelay { get; set; }
        public RelayCommand PlayMediaRelay { get; set; }
        public RelayCommand DelMediaRelay { get; set; }
        public RelayCommand AddMediaRelay { get; set; }
        public RelayCommand SearchMediaRelay { get; set; }
        public RelayCommand SortTitleRelay { get; set; }
        public RelayCommand SortArtistRelay { get; set; }
        public RelayCommand SortAlbumRelay { get; set; }
        public ObservableCollection<PlaylistItem> PlaylistList { get; set; }
        public ObservableCollection<LibraryItem> LibraryList
        {
            get { return _libList; }
            set
            {
                _libList = value;
                FirePropertyChanged("LibraryList");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public Visibility AddVisibility
        {
            get { return showAdd ? Visibility.Visible : Visibility.Collapsed; }
            set
            {
                if (value == Visibility.Visible)
                    showAdd = true;
                else
                    showAdd = false;
                FirePropertyChanged("AddVisibility");
            }
        }
        public string PlaylistName
        {
            get { return this._playlistName; }
            set
            {
                _playlistName = value;
                FirePropertyChanged("PlaylistName");
            }
        }
        public string SearchText
        {
            get { return this._searchText; }
            set
            {
                _searchText = value;
                SearchMedia(null);
                FirePropertyChanged("SearchText");
            }
        }
         public string Title
        {
            get { return title; }
            set
            {
                title = value;
                FirePropertyChanged("Title");
            }
        }
        public string Artist
        {
            get { return artist; }
            set
            {
                artist = value;
                FirePropertyChanged("Artist");
            }
        }
        public string Album
        {
            get { return album; }
            set
            {
                album = value;
                FirePropertyChanged("Album");
            }
        }
        public string Time
        {
            get { return time; }
            set
            {
                time = value;
                FirePropertyChanged("Time");
            }
        }


        public playlistViewModel(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            utils = new MediaFunctions(mainWindow);
            mwmv = mainWindow.mainDisplay.DataContext as MainDisplayViewModel;
            ReadPlayListRelay = new RelayCommand(playPlayList);
            CreatePlaylistRelay = new RelayCommand(selectPlaylistSongs);
            ShowPlaylistRelay = new RelayCommand(setPlaylist);
            DeletePlaylistRelay = new RelayCommand(deletePlaylist);
            PlayMediaRelay = new RelayCommand(PlayMedia);
            DelMediaRelay = new RelayCommand(DeleteMedia);
            AddMediaRelay = new RelayCommand(AddMedia);
            SearchMediaRelay = new RelayCommand(SearchMedia);
            SortTitleRelay = new RelayCommand(SortTitle);
            SortArtistRelay = new RelayCommand(SortArtist);
            SortAlbumRelay = new RelayCommand(SortAlbum);
            PlaylistList = new ObservableCollection<PlaylistItem> { };
            LibraryList = new ObservableCollection<LibraryItem> { };
            printPlaylist();
        }

        public bool checkFileValidity(string fileName)
        {
            string extension = System.IO.Path.GetExtension(fileName);

            string[] playableVideo = new[] {
            ".mov", ".mkv", ".aaf", ".3gp", ".gif", ".asf", ".avchd", ".avi", ".cam", ".dat", ".dsh", ".dvr - ms", ".flv", ".m1v", ".m2v", ".fla", ".flr", ".sol", ".m4v", ".wrap", ".mng", ".mov", ".mpeg", ".mpg", ".mpe", ".mp4", ".mxf", ".rm", ".svi", ".smi", ".swf", ".wmv", ".wtv",
            };
            string[] playableAudio = new[] {
            ".8svx", ".16svx", ".aif", ".aifc", ".aiff", ".au", ".bwf", ".cdda", ".raw", ".wav", ".flac", ".la", ".pac", ".m4a", ".ape", ".ofr", ".ofs", ".off", ".rka", ".shn", ".tak", ".tta", ".wv", ".brstm", ".dts", ".dtshd", ".dtsma", ".ast", ".amr", ".mp2", ".mp3", ".psx", ".gsm", ".wma", ".aac", ".m4a", ".m4p", ".mpc", ".vqf", ".ra", ".rm", ".ots", ".swa", ".vox", ".voc", ".dwd", ".smp"
            };
            string[] playableImage = new[] {
            ".jpg", ".jpeg", ".png", ".gif", ".bmp"
            };

            foreach (string ext in playableAudio)
                if (ext.Equals(extension) && File.Exists(fileName))
                    return true;
            foreach (string ext in playableVideo)
                if (ext.Equals(extension) && File.Exists(fileName))
                    return true;
            foreach (string ext in playableImage)
                if (ext.Equals(extension) && File.Exists(fileName))
                    return true;
            return false;

        }

        void GongSolutions.Wpf.DragDrop.IDropTarget.DragOver(IDropInfo dropInfo)
        {
            var dragFileList = ((System.Windows.DataObject)dropInfo.Data).GetFileDropList().Cast<string>();
            dropInfo.Effects = dragFileList.Any(item =>
            {
                return checkFileValidity(item);
            }) ? System.Windows.DragDropEffects.Copy : System.Windows.DragDropEffects.None;
        }

        void GongSolutions.Wpf.DragDrop.IDropTarget.Drop(IDropInfo dropInfo)
        {
            var dragFileList = ((System.Windows.DataObject)dropInfo.Data).GetFileDropList().Cast<string>();
            dropInfo.Effects = dragFileList.All(item =>
            {
                bool val = checkFileValidity(item);
                if (val)
                {
                    if (curPlaylist == -1)
                        curPlaylist = addToPlaylist(new[] { item });
                    else
                        AddToExistingPlaylist(new[] { item });
                }
                return val;
            }) ? System.Windows.DragDropEffects.Copy : System.Windows.DragDropEffects.None;
        }



        public void selectPlaylistSongs(object obj)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Supported Files|*.jpg;*.jpeg;*.jpe;*.jfif;*.png;*.mkv;*.aaf;*.mp4;*.3gp;*.gif;*.asf;*.avchd;*.avi;*.cam;*.dat;*.dsh;*.dvr-ms;*.flv;*.m1v;*.m2v;*.fla;*.flr;*.sol;*.m4v;*.wrap;*.mng;*.mov;*.mpeg;*.mpg;*.mpe;*.mp4;*.mxf;*.rm;*.svi;*.smi;*.swf;*.wmv;*.wtv;*.8svx;*.16svx;*.aif;*.aifc;*.aiff;*.au;*.bwf;*.cdda;*.raw;*.wav;*.flac;*.la;*.pac;*.m4a;*.ape;*.ofr;*.ofs;*.off;*.rka;*.shn;*.tak;*.tta;*.wv;*.brstm;*.dts;*.dtshd;*.dtsma;*.ast;*.amr;*.mp2;*.mp3;*.psx;*.gsm;*.wma;*.aac;*.m4a;*.m4p;*.mpc;*.vqf;*.ra;*.rm;*.ots;*.swa;*.vox;*.voc;*.dwd;*.smp;";
            dlg.Filter += "|Audio Files|*.8svx;*.16svx;*.aif;*.aifc;*.aiff;*.au;*.bwf;*.cdda;*.raw;*.wav;*.flac;*.la;*.pac;*.m4a;*.ape;*.ofr;*.ofs;*.off;*.rka;*.shn;*.tak;*.tta;*.wv;*.brstm;*.dts;*.dtshd;*.dtsma;*.ast;*.amr;*.mp2;*.mp3;*.psx;*.gsm;*.wma;*.aac;*.m4a;*.m4p;*.mpc;*.vqf;*.ra;*.rm;*.ots;*.swa;*.vox;*.voc;*.dwd;*.smp;";
            dlg.Filter += "|Video Files|*.aaf;*.mvk;*.mp4;*.3gp;*.gif;*.asf;*.avchd;*.avi;*.cam;*.dat;*.dsh;*.dvr-ms;*.flv;*.m1v;*.m2v;*.fla;*.flr;*.sol;*.m4v;*.wrap;*.mng;*.mov;*.mpeg;*.mpg;*.mpe;*.mp4;*.mxf;*.rm;*.svi;*.smi;*.swf;*.wmv;*.wtv;";
            dlg.Filter += "|Image files|*.jpg;*.jpeg;*.jpe;*.jfif;*.png";
            dlg.Multiselect = true;
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
                addToPlaylist(dlg.FileNames);
        }

        public void importPlayList(string path)
        {
            if (File.Exists(path))
                File.Copy(path, "Playlist.xml", true);
            printPlaylist();
        }

        public int addToPlaylist(string[] titles, string pName = "Playlist")
        {
            Playlist playlist = openPlaylistFile();
            if (_playlistName != null && _playlistName.Length != 0)
                pName = _playlistName;
            List<Media> mediaList = createMusicList(titles);
            int id = 1;
            if (playlist.Playlists.Count != 0)
                id = playlist.Playlists[playlist.Playlists.Count - 1].Id + 1;
            Library lib = new Library
            {
                Id = id,
                Name = pName,
                Titles = mediaList,
            };
            playlist.Playlists.Add(lib);
            serializePlaylist(playlist);
            PlaylistName = "";
            printPlaylist();
            return id;
        }

        private void serializePlaylist(Playlist playlist)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Playlist));
            using (StreamWriter wr = new StreamWriter("Playlist.xml"))
            {
                xs.Serialize(wr, playlist);
            }
        }

        private Playlist deserializePlaylist()
        {
            Playlist playlistList = null;
            XmlSerializer ds = new XmlSerializer(typeof(Playlist));
            if (File.Exists("Playlist.xml"))
            {
                try
                {
                    using (StreamReader rd = new StreamReader("Playlist.xml"))
                    {
                        playlistList = ds.Deserialize(rd) as Playlist;
                    }
                } catch (System.InvalidOperationException ex)
                {
                    File.Delete("Playlist.xml");
                    System.Windows.Forms.MessageBox.Show("Fichier playlist corrompu, création d'un nouveau fichier", "OniZik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    playlistList = new Playlist();
                    Console.Error.WriteLine(ex.ToString());
                }
            }
            else
                playlistList = new Playlist();
            return playlistList;
        }

        private List<Media> createMusicList(string[] titles)
        {
            try {
                List<Media> musicList = new List<Media>();
                int id = getCurId();
                LibraryViewModel lvm = mainWindow.libraryMenu.DataContext as LibraryViewModel;
                foreach (string title in titles)
                {
                    Media music = new Media
                    {
                        Id = id++,
                        Name = title.Substring(title.LastIndexOf('\\') + 1, title.LastIndexOf('.') - title.LastIndexOf('\\') - 1),
                        Path = title,
                        Type = lvm.GetType(title)
                    };
                    musicList.Add(music);
                }
                return musicList;
            }catch (Exception ex)
            {
                Console.Error.WriteLine("error in createMusicList playlist : " + ex.Message);
                return null;
            }
        }

        private int getCurId()
        {
            Playlist playlist = openPlaylistFile();
            foreach (var Playlist in playlist.Playlists)
            {
                if (Playlist.Id == curPlaylist)
                    if (Playlist.Titles.Count() > 0)
                        return Playlist.Titles.Last().Id + 1;
                break;
            }
            return 0;
        }

        public  Playlist openPlaylistFile(String pName = "Playlist.xml")
        {
            Playlist playlist = null;

            if (File.Exists(pName))
            {
                XmlSerializer ds = new XmlSerializer(typeof(Playlist));
                using (StreamReader rd = new StreamReader(pName))
                {
                    try { playlist = ds.Deserialize(rd) as Playlist;
                    }
                    catch (Exception ex)
                    {
                        rd.Close();
                        File.Delete("Library.xml");
                        System.Windows.MessageBox.Show("Fichier média corrompu, création d'un nouveau fichier", "OniZik", MessageBoxButton.OK, MessageBoxImage.Error);
                        playlist = new Playlist();
                        LibraryList.Clear();
                        Console.Error.WriteLine(ex.ToString());
                    }
                }
            }
            else
                playlist = new Playlist();
            return playlist;
        }

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void setPlaylist(object obj)
        {
            AddVisibility = Visibility.Visible;
            LibraryList.Clear();
            int id = (int)obj;
            curPlaylist = id;
            SearchText = "";
        }

        public void printPlaylist()
        {
            PlaylistList.Clear();
            if (File.Exists("Playlist.xml"))
            {
                Playlist playlistList = deserializePlaylist();

                foreach (var Playlist in playlistList.Playlists)
                {
                    PlaylistList.Add(new PlaylistItem(Playlist.Name, Playlist.Id, ShowPlaylistRelay, DeletePlaylistRelay));
                }
            }
            PlaylistName = "";
        }

        public void deletePlaylist(object obj)
        {
            int id = (int)obj;
            if (curPlaylist.Equals(id))
            {
                utils.stopMedia();
                curPlaylist = -1;
            }
            AddVisibility = Visibility.Collapsed;
            LibraryList.Clear();
            if (File.Exists("Playlist.xml"))
            {
                Playlist playlistList = deserializePlaylist();
                int position = playlistList.Playlists.Count - id;
                int index = -1;
                foreach (var Playlist in playlistList.Playlists)
                {
                    ++index;
                    if (Playlist.Id == id)
                    {
                        playlistList.Playlists.Remove(Playlist);
                        PlaylistList.RemoveAt(index);
                        break;
                    }
                }
                serializePlaylist(playlistList);
            }
        }

        public void playPlayList(object obj)
        {
            playingPlaylist = true;
            string action = "next";
            if (obj != null)
                action = obj as string;
            Playlist playlist = openPlaylistFile();
            int index = -1;
            foreach (var Playlist in playlist.Playlists)
            {
                if (Playlist.Id == curPlaylist)
                {
                    if (Playlist.Titles.Count() > 0)
                    {
                        if (lastId == -1)
                        {
                            mainWindow.mainDisplay.mediaElement.Source = new Uri(Playlist.Titles.First().Path);
                            utils.setCurentPath(Playlist.Titles.First().Path);
                            utils.playMusic(Playlist.Titles.First().Path);
                            lastId = Playlist.Titles.First().Id;
                            break;
                        } else if (mwmv.shuffle == true)
                        {
                            Random rand = new Random();
                            int next = rand.Next(0, Playlist.Titles.Count());
                            index = -1;
                            foreach (var Music in Playlist.Titles)
                            {
                                ++index;
                                if (index == next)
                                {
                                    mainWindow.mainDisplay.mediaElement.Source = new Uri(Music.Path);
                                    utils.setCurentPath(Music.Path);
                                    utils.playMusic(Music.Path);
                                    lastId = Music.Id;
                                    break;
                                }
                            }
                        } else
                        {
                            foreach (var Music in Playlist.Titles)
                            {
                                if (action.Equals("next") && Music.Equals(Playlist.Titles.Last()))
                                {
                                    utils.stopMedia();
                                    break;
                                }
                                    index++;
                                if (Music.Id == lastId)
                                {
                                    if (action.Equals("prev") && Music.Equals(Playlist.Titles.First()))
                                    {
                                        mainWindow.mainDisplay.mediaElement.Source = new Uri(Playlist.Titles.First().Path);
                                        utils.setCurentPath(Playlist.Titles.First().Path);
                                        utils.playMusic(Playlist.Titles.First().Path);
                                        lastId = Playlist.Titles.First().Id;
                                        break;
                                    }
                                    int i = action.Equals("next") ? 1 : -1;
                                    mainWindow.mainDisplay.mediaElement.Source = new Uri(Playlist.Titles[index + i].Path);
                                    utils.setCurentPath(Playlist.Titles[index + i].Path);
                                    utils.playMedia(Playlist.Titles[index + i].Path);
                                    lastId = Playlist.Titles[index + i].Id;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            SearchMedia(null);
        }

        public void PlayMedia(object obj)
        {
            LibraryViewModel lvm = mainWindow.libraryMenu.DataContext as LibraryViewModel;
            LibraryItem media = obj as LibraryItem;
            lastId = media.Id;
            lvm.playingMedias = false;
            playingPlaylist = true;
            mainWindow.mainDisplay.mediaElement.Source = new Uri(media.Path);
            utils.setCurentPath(media.Path);
            if (media.Playing == true)
            {
                media.Playing = false;
                utils.pauseMedia();
                lastId = -1;
            }
            else
            {
                media.Playing = true;
                utils.playMedia(media.Path);
                lastId = media.Id;
            }
            SearchMedia(null);
        }

        public void DeleteMedia(object obj)
        {
            int id = (int)obj;
            int index = -1;
            Playlist playlist = openPlaylistFile();
            foreach (var Playlist in playlist.Playlists)
            {
                if (Playlist.Id == curPlaylist)
                {
                    foreach (var Music in Playlist.Titles)
                    {
                        ++index;
                        if (Music.Id == id)
                        {
                            Playlist.Titles.Remove(Music);
                            LibraryList.RemoveAt(index);
                            break;
                        }
                    }
                }
            }
            serializePlaylist(playlist);
            SearchMedia(null);
        }

        public int getCurrentPlaylist()
        {
            return curPlaylist;
        }

        public void AddMedia(object obj)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Supported Files|*.jpg;*.jpeg;*.jpe;*.jfif;*.png;*.mkv;*.aaf;*.mp4;*.3gp;*.gif;*.asf;*.avchd;*.avi;*.cam;*.dat;*.dsh;*.dvr-ms;*.flv;*.m1v;*.m2v;*.fla;*.flr;*.sol;*.m4v;*.wrap;*.mng;*.mov;*.mpeg;*.mpg;*.mpe;*.mp4;*.mxf;*.rm;*.svi;*.smi;*.swf;*.wmv;*.wtv;*.8svx;*.16svx;*.aif;*.aifc;*.aiff;*.au;*.bwf;*.cdda;*.raw;*.wav;*.flac;*.la;*.pac;*.m4a;*.ape;*.ofr;*.ofs;*.off;*.rka;*.shn;*.tak;*.tta;*.wv;*.brstm;*.dts;*.dtshd;*.dtsma;*.ast;*.amr;*.mp2;*.mp3;*.psx;*.gsm;*.wma;*.aac;*.m4a;*.m4p;*.mpc;*.vqf;*.ra;*.rm;*.ots;*.swa;*.vox;*.voc;*.dwd;*.smp;";
            dlg.Filter += "|Audio Files|*.8svx;*.16svx;*.aif;*.aifc;*.aiff;*.au;*.bwf;*.cdda;*.raw;*.wav;*.flac;*.la;*.pac;*.m4a;*.ape;*.ofr;*.ofs;*.off;*.rka;*.shn;*.tak;*.tta;*.wv;*.brstm;*.dts;*.dtshd;*.dtsma;*.ast;*.amr;*.mp2;*.mp3;*.psx;*.gsm;*.wma;*.aac;*.m4a;*.m4p;*.mpc;*.vqf;*.ra;*.rm;*.ots;*.swa;*.vox;*.voc;*.dwd;*.smp;";
            dlg.Filter += "|Video Files|*.aaf;*.mvk;*.mp4;*.3gp;*.gif;*.asf;*.avchd;*.avi;*.cam;*.dat;*.dsh;*.dvr-ms;*.flv;*.m1v;*.m2v;*.fla;*.flr;*.sol;*.m4v;*.wrap;*.mng;*.mov;*.mpeg;*.mpg;*.mpe;*.mp4;*.mxf;*.rm;*.svi;*.smi;*.swf;*.wmv;*.wtv;";
            dlg.Filter += "|Image files|*.jpg;*.jpeg;*.jpe;*.jfif;*.png";
            dlg.Multiselect = true;
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
                AddToExistingPlaylist(dlg.FileNames);
        }

        public void AddToExistingPlaylist(string[] filesName)
        {
            try {
                Playlist playlist = openPlaylistFile();
                List<Media> musicList = createMusicList(filesName);
                if (playlist.Playlists[curPlaylist - 1].Titles == null)
                    playlist.Playlists[curPlaylist - 1].Titles = musicList;
                else
                    playlist.Playlists[curPlaylist - 1].Titles.AddRange(musicList);
                serializePlaylist(playlist);
                setPlaylist(curPlaylist);
            }catch (Exception ex)
            {
                Console.Error.WriteLine("Error, can't add to current playlist :  " + ex.Message); 
            }
        }

        private void SortTitle(object obj)
        {
            sortTitle = (sortTitle == 0) ? 1 : (sortTitle == 1) ? 2 : 0;
            sortArtist = sortAlbum = 0;
            SearchMedia(null);
        }

        private void SortArtist(object obj)
        {
            sortArtist = (sortArtist == 0) ? 1 : (sortArtist == 1) ? 2 : 0;
            sortTitle = sortAlbum = 0;
            SearchMedia(null);
        }

        private void SortAlbum(object obj)
        {
            sortAlbum = (sortAlbum == 0) ? 1 : (sortAlbum == 1) ? 2 : 0;
            sortTitle = sortArtist = 0;
            SearchMedia(null);
        }

        public void SearchMedia(object obj)
        {
            string[] infos;
            double timeInDouble;

            LibraryList.Clear();
            printPlaylist();
            Playlist playlist = openPlaylistFile();
            if (File.Exists("Playlist.xml"))
            {
                foreach (var Playlist in playlist.Playlists)
                {
                    if (Playlist.Id == curPlaylist)
                    {
                        var v = from c in Playlist.Titles
                                where utils.GetAudioFileInfo(c.Path) != null && (
                                utils.GetAudioFileInfo(c.Path)[0].Contains(_searchText) ||
                                utils.GetAudioFileInfo(c.Path)[1].Contains(_searchText) ||
                                utils.GetAudioFileInfo(c.Path)[2].Contains(_searchText) ||
                                c.Name.Contains(_searchText))
                                select new
                                {
                                    c.Name,
                                    c.Path,
                                    c.Id
                                };

                        foreach (var c in v)
                        {
                            timeInDouble = utils.getDurationFromFile(c.Path);
                            TimeSpan t = TimeSpan.FromMilliseconds(timeInDouble);
                            string duration = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                            infos = utils.GetAudioFileInfo(c.Path);
                            if (infos[0] == "Titre Inconnu")
                                Title = c.Name;
                            else
                                Title = infos[0];
                            Artist = infos[1];
                            Album = infos[2];
                            Time = duration;
                            if (playingPlaylist == true && lastId == c.Id)
                                LibraryList.Add(new LibraryItem(Title, Artist, Album, Time, c.Name, c.Path, c.Id, true, PlayMediaRelay, DelMediaRelay));
                            else
                                LibraryList.Add(new LibraryItem(Title, Artist, Album, Time, c.Name, c.Path, c.Id, false, PlayMediaRelay, DelMediaRelay));
                        }
                        break;
                    }
                }
                IEnumerable<LibraryItem> temp = null;
                if (sortTitle == 1)
                    temp = (LibraryList.OrderBy(p => p.Title));
                else if (sortTitle == 2)
                    temp = (LibraryList.OrderByDescending(p => p.Title));
                if (sortArtist == 1)
                    temp = (LibraryList.OrderBy(p => p.Artist));
                else if (sortArtist == 2)
                    temp = (LibraryList.OrderByDescending(p => p.Artist));
                if (sortAlbum == 1)
                    temp = (LibraryList.OrderBy(p => p.Album));
                else if (sortAlbum == 2)
                    temp = (LibraryList.OrderByDescending(p => p.Album));
                if (temp != null)
                    LibraryList = new ObservableCollection<LibraryItem> (temp);
            }
            else
                AddVisibility = Visibility.Collapsed;
        }

    }
}
