using GongSolutions.Wpf.DragDrop;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using WpfApplication1;
using WpfApplication1.Model;
using WpfApplication1.Util;
using WpfApplication1.View;
using WpfApplication1.ViewModel;

namespace WpfApplication1
{
    public class LibraryViewModel : INotifyPropertyChanged, IDropTarget
    {
        private MediaFunctions utils;
        private MainDisplayViewModel mwmv;
        private MainWindow window;
        public RelayCommand AddMedia { get; set; }
        public RelayCommand EmptyLib { get; set; }
        public RelayCommand PlayMediaRelay{ get; set; }
        public RelayCommand DelMediaRelay { get; set; }
        public RelayCommand SortTitleRelay { get; set; }
        public RelayCommand SortArtistRelay { get; set; }
        public RelayCommand SortAlbumRelay { get; set; }
        public RelayCommand ReadLibraryRelay { get; set; }
        private int sortTitle = 0;
        private int sortArtist = 0;
        private int sortAlbum = 0;
        private int lastId = -1;
        private string _searchText = "";
        public bool playingMedias = false;
        private ObservableCollection<LibraryItem> _libList;
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

        public string SearchText
        {
            get { return this._searchText; }
            set
            {
                _searchText = value;
                printMedias();
                FirePropertyChanged("SearchText");
            }
        }

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public LibraryViewModel(MainWindow window)
        {
            this.window = window;
            utils = new MediaFunctions(window);
            mwmv = window.mainDisplay.DataContext as MainDisplayViewModel;
            AddMedia = new RelayCommand(selectMedia);
            EmptyLib = new RelayCommand(EmptyLibrary);
            SortTitleRelay = new RelayCommand(SortTitle);
            SortArtistRelay = new RelayCommand(SortArtist);
            SortAlbumRelay = new RelayCommand(SortAlbum);
            DelMediaRelay = new RelayCommand(DeleteMedia);
            PlayMediaRelay = new RelayCommand(PlayMedia);
            ReadLibraryRelay = new RelayCommand(playMedias);
            LibraryList = new ObservableCollection<LibraryItem> { };

            printMedias();
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


        void IDropTarget.DragOver(IDropInfo dropInfo)
        {
            var dragFileList = ((DataObject)dropInfo.Data).GetFileDropList().Cast<string>();
            dropInfo.Effects = dragFileList.Any(item =>
            {
                var extension = Path.GetExtension(item);
                return checkFileValidity(item);
            }) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        void IDropTarget.Drop(IDropInfo dropInfo)
        {
            var dragFileList = ((DataObject)dropInfo.Data).GetFileDropList().Cast<string>();
            dropInfo.Effects = dragFileList.All(item =>
            {
                addToLibrary(new[]{ item });
                var extension = Path.GetExtension(item);
                return checkFileValidity(item);
            }) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        public void selectMedia(object obj)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Supported Files|*.jpg;*.jpeg;*.jpe;*.jfif;*.png;*.mkv;*.aaf;*.mp4;*.3gp;*.gif;*.asf;*.avchd;*.avi;*.cam;*.dat;*.dsh;*.dvr-ms;*.flv;*.m1v;*.m2v;*.fla;*.flr;*.sol;*.m4v;*.wrap;*.mng;*.mov;*.mpeg;*.mpg;*.mpe;*.mp4;*.mxf;*.rm;*.svi;*.smi;*.swf;*.wmv;*.wtv;*.8svx;*.16svx;*.aif;*.aifc;*.aiff;*.au;*.bwf;*.cdda;*.raw;*.wav;*.flac;*.la;*.pac;*.m4a;*.ape;*.ofr;*.ofs;*.off;*.rka;*.shn;*.tak;*.tta;*.wv;*.brstm;*.dts;*.dtshd;*.dtsma;*.ast;*.amr;*.mp2;*.mp3;*.psx;*.gsm;*.wma;*.aac;*.m4a;*.m4p;*.mpc;*.vqf;*.ra;*.rm;*.ots;*.swa;*.vox;*.voc;*.dwd;*.smp;";
            dlg.Filter += "|Audio Files|*.8svx;*.16svx;*.aif;*.aifc;*.aiff;*.au;*.bwf;*.cdda;*.raw;*.wav;*.flac;*.la;*.pac;*.m4a;*.ape;*.ofr;*.ofs;*.off;*.rka;*.shn;*.tak;*.tta;*.wv;*.brstm;*.dts;*.dtshd;*.dtsma;*.ast;*.amr;*.mp2;*.mp3;*.psx;*.gsm;*.wma;*.aac;*.m4a;*.m4p;*.mpc;*.vqf;*.ra;*.rm;*.ots;*.swa;*.vox;*.voc;*.dwd;*.smp;";
            dlg.Filter += "|Video Files|*.aaf;*.mvk;*.mp4;*.3gp;*.gif;*.asf;*.avchd;*.avi;*.cam;*.dat;*.dsh;*.dvr-ms;*.flv;*.m1v;*.m2v;*.fla;*.flr;*.sol;*.m4v;*.wrap;*.mng;*.mov;*.mpeg;*.mpg;*.mpe;*.mp4;*.mxf;*.rm;*.svi;*.smi;*.swf;*.wmv;*.wtv;";
            dlg.Filter += "|Image files|*.jpg;*.jpeg;*.jpe;*.jfif;*.png";
            dlg.Multiselect = true;
            dlg.ShowDialog();
            addToLibrary(dlg.FileNames);
        }


        public void addToLibrary(string[] paths)
        {
            if (paths.Length == 0)
                return;
            try
            {
                Library library = null;

                if (File.Exists("Library.xml"))
                {
                    XmlSerializer ds = new XmlSerializer(typeof(Library));
                    using (StreamReader rd = new StreamReader("Library.xml"))
                    {
                        library = ds.Deserialize(rd) as Library;
                    }
                }
                else
                    library = new Library();

                foreach (var path in paths)
                {
                    if (checkFileValidity(path) == true)
                    {
                        int id = 1;
                        if (library.Titles.Count != 0)
                            id = library.Titles[library.Titles.Count - 1].Id + 1;
                        Media music = new Media
                        {
                            Id = id,
                            Name = path.Substring(path.LastIndexOf('\\') + 1, path.LastIndexOf('.') - path.LastIndexOf('\\') - 1),
                            Path = path,
                            Type = GetType(path)
                        };
                        library.Titles.Add(music);
                    }
                }

                XmlSerializer xs = new XmlSerializer(typeof(Library));
                using (StreamWriter wr = new StreamWriter("Library.xml"))
                {
                    xs.Serialize(wr, library);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            printMedias();
        }

        public Media.eType GetType(string path)
        {
            string[] musicExt = { ".8svx", ".16svx", ".aif", ".aifc", ".aiff", ".au", ".bwf", ".cdda", ".raw", ".wav", ".flac", ".la", ".pac", ".m4a", ".ape", ".ofr", ".ofs", ".off", ".rka", ".shn", ".tak", ".tta", ".wv", ".brstm", ".dts", ".dtshd", ".dtsma", ".ast", ".amr", ".mp2", ".mp3", ".psx", ".gsm", ".wma", ".aac", ".m4a", ".m4p", ".mpc", ".vqf", ".ra", ".rm", ".ots", ".swa", ".vox", ".voc", ".dwd", ".smp" };
            string[] imageExt = { ".jpg", ".jpeg", ".jpe", ".jfif", ".png" };
            string[] videoExt = { ".mp4", ".mkv", ".aaf", ".3gp", ".gif", ".asf", ".avchd", ".avi", ".cam", ".dat", ".dsh", ".dvr - ms", ".flv", ".m1v", ".m2v", ".fla", ".flr", ".sol", ".m4v", ".wrap", ".mng", ".mov", ".mpeg", ".mpg", ".mpe", ".mp4", ".mxf", ".rm", ".svi", ".smi", ".swf", ".wmv", ".wtv" };

            foreach (var ext in musicExt)
            {
                if (path.Substring(path.LastIndexOf('.')) == ext)
                    return (Media.eType.MUSIC);
            }
            foreach (var ext in imageExt)
            {
                if (path.Substring(path.LastIndexOf('.')) == ext)
                    return (Media.eType.IMAGE);
            }
            foreach (var ext in videoExt)
            {
                if (path.Substring(path.LastIndexOf('.')) == ext)
                    return (Media.eType.VIDEO);
            }
            return (Media.eType.UNKNOWN);
        }

        public void printMedias()
        {
            string[] infos;
            double timeInDouble;

            try {

                LibraryList.Clear();
                Library library = null;

                if (File.Exists("Library.xml"))
                {
                    XmlSerializer ds = new XmlSerializer(typeof(Library));
                    try {
                        using (StreamReader rd = new StreamReader("Library.xml"))
                        {
                            library = ds.Deserialize(rd) as Library;
                        }
                    } catch (Exception ex)
                    {
                        File.Delete("Library.xml");
                        MessageBox.Show("Fichier média corrompu, création d'un nouveau fichier", "OniZik", MessageBoxButton.OK, MessageBoxImage.Error);
                        library = new Library();
                        Console.Error.WriteLine(ex.ToString());
                    }

                    var v = from c in library.Titles
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
                        string Title, Artist, Album, Time;
                        infos = utils.GetAudioFileInfo(c.Path);
                        timeInDouble = utils.getDurationFromFile(c.Path);
                        TimeSpan t = TimeSpan.FromMilliseconds(timeInDouble);
                        string duration = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds);
                        if (infos != null)
                        {
                            if (infos[0] == "Titre Inconnu")
                                Title = c.Name;
                            else
                                Title = infos[0];
                            Artist = infos[1];
                            Album = infos[2];
                            Time = duration;
                            if (playingMedias == true && lastId == c.Id)
                                LibraryList.Add(new LibraryItem(Title, Artist, Album, Time, c.Name, c.Path, c.Id, true, PlayMediaRelay, DelMediaRelay));
                            else
                                LibraryList.Add(new LibraryItem(Title, Artist, Album, Time, c.Name, c.Path, c.Id, false, PlayMediaRelay, DelMediaRelay));
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
                        LibraryList = new ObservableCollection<LibraryItem>(temp);
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Error in printMedia : " + ex.Message);
            }
        }
        
        public void EmptyLibrary(object obj)
        {
            if (File.Exists("Library.xml"))
            {
                File.Delete("Library.xml");
                LibraryList.Clear();
            }
        }

        public void DeleteMedia(object obj)
        {
            int id = (int) obj;
            Library library;
            if (File.Exists("Library.xml"))
            {
                XmlSerializer ds = new XmlSerializer(typeof(Library));
                using (StreamReader rd = new StreamReader("Library.xml"))
                {
                    library = ds.Deserialize(rd) as Library;
                }
                int position = library.Titles.Count - id;
                int index = -1;
                foreach (var Music in library.Titles)
                {
                    ++index;
                    if (Music.Id == id)
                    {
                        library.Titles.Remove(Music);
                        LibraryList.RemoveAt(index);
                        break;
                    }
                }
                XmlSerializer xs = new XmlSerializer(typeof(Library));
                using (StreamWriter wr = new StreamWriter("Library.xml"))
                {
                    xs.Serialize(wr, library);
                }
            }
        }

        public void playMedias(object obj)
        {
            playingMedias = true;
            string action = "next";
            int index = -1;
            if (obj != null)
                action = obj as string;
            Library lib = null;
            if (File.Exists("Library.xml"))
            {
                XmlSerializer ds = new XmlSerializer(typeof(Library));
                using (StreamReader rd = new StreamReader("Library.xml"))
                {
                    lib = ds.Deserialize(rd) as Library;
                }
            }
            if (lib != null && lib.Titles.Count() > 0)
            {
                if (lastId == -1)
                {
                    window.mainDisplay.mediaElement.Source = new Uri(lib.Titles.First().Path);
                    utils.setCurentPath(lib.Titles.First().Path);
                    utils.playMusic(lib.Titles.First().Path);
                    lastId = lib.Titles.First().Id;
                } else if (mwmv.shuffle == true)
                {
                    Random rand = new Random();
                    int next = rand.Next(0, lib.Titles.Count());
                    index = -1;
                    foreach (var Music in lib.Titles)
                    {
                        ++index;
                        if (index == next)
                        {
                            window.mainDisplay.mediaElement.Source = new Uri(Music.Path);
                            utils.setCurentPath(Music.Path);
                            utils.playMedia(Music.Path);
                            lastId = Music.Id;
                            break;
                        }
                    }
                } else
                foreach (var Music in lib.Titles)
                {
                    ++index;
                    if (action.Equals("next") && Music.Equals(lib.Titles.Last()))
                    {
                        utils.stopMedia();
                        break;
                    }
                    if (Music.Id == lastId)
                    {
                        if (action.Equals("prev") && Music.Equals(lib.Titles.First()))
                        {
                            window.mainDisplay.mediaElement.Source = new Uri(lib.Titles.First().Path);
                            utils.setCurentPath(lib.Titles.First().Path);
                            utils.playMedia(lib.Titles.First().Path);
                            lastId = lib.Titles.First().Id;
                            break;
                        }
                        int i = action.Equals("next") ? 1 : -1;
                        window.mainDisplay.mediaElement.Source = new Uri(lib.Titles[index + i].Path);
                        utils.setCurentPath(lib.Titles[index + i].Path);
                        utils.playMedia(lib.Titles[index + i].Path);
                        lastId = lib.Titles[index + i].Id;
                        break;
                    }
                }
            }
            printMedias();
        }

        public void PlayMedia(object obj)
        {
            playlistViewModel pvm = window.playlistMenu.DataContext as playlistViewModel;
            LibraryItem music = obj as LibraryItem;
            pvm.playingPlaylist = false;
            playingMedias = true;
            window.mainDisplay.mediaElement.Source = new Uri(music.Path);
            utils.setCurentPath(music.Path);
            if (music.Playing == true)
            {
                music.Playing = false;
                utils.pauseMedia();
                lastId = -1;
            }
            else
            {
                music.Playing = true;
                utils.playMedia(music.Path);
                lastId = music.Id;
            }
            printMedias();
        }

       private void SortTitle(object obj)
        {
            sortTitle = (sortTitle == 0) ? 1 : (sortTitle == 1) ? 2 : 0;
            sortArtist = sortAlbum = 0;
            printMedias();
        }

        private void SortArtist(object obj)
        {
            sortArtist = (sortArtist == 0) ? 1 : (sortArtist == 1) ? 2 : 0;
            sortTitle = sortAlbum = 0;
            printMedias();
        }

        private void SortAlbum(object obj)
        {
            sortAlbum = (sortAlbum == 0) ? 1 : (sortAlbum == 1) ? 2 : 0;
            sortTitle = sortArtist = 0;
            printMedias();
        }

        private string title;
        private string album;
        private string artist;
        private string time;

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
    }
}
