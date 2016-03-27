using System;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using WpfApplication1.ViewModel;
using WpfApplication1.View;
using System.Timers;

namespace WpfApplication1.Util
{
    class MediaFunctions
    {
        private MainWindow window;
        private MainDisplayViewModel mwmv;

        private static double sizeW = 0;
        private static double sizeH = 0;
        private string[] infos;
        private BitmapImage images;
        private static string curentPath;

        public void nextMedia()
        {
            playlistViewModel pvm = window.playlistMenu.DataContext as playlistViewModel;
            LibraryViewModel lvm = window.libraryMenu.DataContext as LibraryViewModel;
            if (pvm.playingPlaylist == true)
                pvm.playPlayList("next");
            else if (lvm.playingMedias == true)
                lvm.playMedias("next");
        }

        public void prevMedia()
        {
            playlistViewModel pvm = window.playlistMenu.DataContext as playlistViewModel;
            LibraryViewModel lvm = window.libraryMenu.DataContext as LibraryViewModel;

            if (pvm.playingPlaylist == true)
                pvm.playPlayList("prev");
            else if (lvm.playingMedias == true)
                lvm.playMedias("prev");
        }

        public MediaFunctions(MainWindow _window)
        {
            window = _window;
            mwmv = window.mainDisplay.DataContext as MainDisplayViewModel;
        }

        public void setCurentPath(string _path)
        {
            curentPath = _path;
        }

        public string getCurentPath()
        {
            return (curentPath);
        }

        public void fullscreen()
        {

            sizeH = window.mainDisplay.mediaElement.ActualHeight;
            sizeW = window.mainDisplay.mediaElement.ActualWidth;

            if (!(sizeH > 0) || !(sizeW > 0))
                return;

            window.mainDisplay.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            window.mainDisplay.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            window.mainDisplay.mediaElement.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            window.mainDisplay.mediaElement.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            hide(window.controlMenu.fullscreenButton);
            show(window.controlMenu.downScreenButton);

            hide(window.leftMenu);
            hide(window.lyricsMenu);
            hide(window.topMenu);
            hide(window.controlMenu);

            window.Visibility = Visibility.Collapsed;
            window.WindowState = System.Windows.WindowState.Maximized;
            window.WindowStyle = WindowStyle.None;
            window.Visibility = Visibility.Visible;

            mwmv.fullScreen = true;
        }

        public void downscreen()
        {
            window.mainDisplay.Width = sizeW;
            window.mainDisplay.Height = sizeH;
            window.mainDisplay.mediaElement.Width = sizeW;
            window.mainDisplay.mediaElement.Height = sizeH;

            show(window.controlMenu.fullscreenButton);
            hide(window.controlMenu.downScreenButton);

            show(window.leftMenu);
            show(window.lyricsMenu);
            show(window.topMenu);
            show(window.controlMenu);

            window.WindowStyle = WindowStyle.SingleBorderWindow;
            window.WindowState = WindowState.Maximized;
            window.ResizeMode = ResizeMode.CanResize;

            mwmv.fullScreen = false;
            mwmv.showBar.Stop();
        }

        public void show(UIElement toShow)
        {
            toShow.Visibility = Visibility.Visible;
        }

        public void hide(UIElement toHide)
        {
            toHide.Visibility = Visibility.Hidden;
        }

        public void playMusic(string path)
        {
            LeftMenuViewModel lvm = window.leftMenu.DataContext as LeftMenuViewModel;
            LibraryViewModel bvm = window.libraryMenu.DataContext as LibraryViewModel;
            playlistViewModel pvm = window.playlistMenu.DataContext as playlistViewModel;

            setLeftMenu(path);
            setLyricsMenu(path);
            startMusicMedia();
            hide(window.controlMenu.playButton);
            show(window.controlMenu.pauseButton);
            window.mainDisplay.mediaElement.LoadedBehavior = MediaState.Play;
            if (mwmv.fullScreen)
                downscreen();
            if (bvm.playingMedias)
                lvm.ShowMedias(null);
            else if (pvm.playingPlaylist)
                lvm.ShowPlaylists(null);

        }

        public void playImage(string path)
        {
                LeftMenuViewModel lvm = window.leftMenu.DataContext as LeftMenuViewModel;

                window.controlMenu.timeVideo.Text = "00:00:00";
                window.controlMenu.endTimeVideo.Text = "00:00:00";
                window.controlMenu.progressBar.Value = 0;

                lvm.ShowHome(null);
                hide(window.controlMenu.playButton);
                show(window.controlMenu.pauseButton);
                window.mainDisplay.mediaElement.LoadedBehavior = MediaState.Play;
        }

        public void playVideo(string path)
        {
            LeftMenuViewModel lvm = window.leftMenu.DataContext as LeftMenuViewModel;
            RadioViewModel rvm = window.radioMenu.DataContext as RadioViewModel;

            if (path == null)
                if (curentPath == null)
                    return;
                else
                {
                    hide(window.controlMenu.playButton);
                    show(window.controlMenu.pauseButton);
                    window.mainDisplay.mediaElement.LoadedBehavior = MediaState.Play;
                }
            if (rvm.inRadio == false)
            {
                if (path == null)
                    path = getCurentPath();
                setLeftMenu(path);
                lvm.ShowHome(null);
            }
            hide(window.controlMenu.playButton);
            show(window.controlMenu.pauseButton);
            setCurentPath(path);
            window.mainDisplay.mediaElement.LoadedBehavior = MediaState.Play;
        }

        public void playMedia(string path)
        {
            LeftMenuViewModel lvm = window.leftMenu.DataContext as LeftMenuViewModel;

            string[] playableVideo = new[] {
                                ".mov", ".mkv", ".aaf", ".3gp", ".gif", ".asf", ".avchd", ".avi", ".cam", ".dat", ".dsh", ".dvr - ms", ".flv", ".m1v", ".m2v", ".fla", ".flr", ".sol", ".m4v", ".wrap", ".mng", ".mov", ".mpeg", ".mpg", ".mpe", ".mp4", ".mxf", ".rm", ".svi", ".smi", ".swf", ".wmv", ".wtv",
                            };
            string[] playableAudio = new[] {
                                ".8svx", ".16svx", ".aif", ".aifc", ".aiff", ".au", ".bwf", ".cdda", ".raw", ".wav", ".flac", ".la", ".pac", ".m4a", ".ape", ".ofr", ".ofs", ".off", ".rka", ".shn", ".tak", ".tta", ".wv", ".brstm", ".dts", ".dtshd", ".dtsma", ".ast", ".amr", ".mp2", ".mp3", ".psx", ".gsm", ".wma", ".aac", ".m4a", ".m4p", ".mpc", ".vqf", ".ra", ".rm", ".ots", ".swa", ".vox", ".voc", ".dwd", ".smp"
                            };
            string[] playableImage = new[] {
                                ".jpg", ".jpeg", ".png", ".gif", ".bmp"
                            };

            if (path == null)
                path = curentPath;

            string extension = System.IO.Path.GetExtension(path);

            foreach (string ext in playableAudio)
                if (ext.Equals(extension) && File.Exists(path))
                    playMusic(path);
            foreach (string ext in playableVideo)
                if (ext.Equals(extension) && File.Exists(path))
                    playVideo(path);
            foreach (string ext in playableImage)
                if (ext.Equals(extension) && File.Exists(path))
                    playImage(path);

        }

        public void setLeftMenu(string path)
        {
            LeftMenuViewModel lvm = window.leftMenu.DataContext as LeftMenuViewModel;
            infos = GetAudioFileInfo(path);
            lvm.setInformation(infos);
            images = getImgFromFile(path);
            lvm.setCover(images);
        }

        public void setLyricsMenu(string path)
        {
            LyricsViewModel lvm = window.lyricsMenu.DataContext as LyricsViewModel;
            infos = GetAudioFileInfo(path);
            lvm.setInformation(infos);
        }

        public double getDurationFromFile(string path)
        {
            if (path != null && File.Exists(path))
            {
                double time;
                try { 
                    var f = TagLib.File.Create(path);
                    time = f.Properties.Duration.TotalMilliseconds;
                    return (time);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("A handled exception just occurred: " + ex.Message, "Exception Sample");
                    Console.Error.WriteLine("concerned path = " + path);
                    return (0);
                }
            }
            return 0;
        }

        public BitmapImage getImgFromFile(string path)
        {
            if (path != null && File.Exists(path))
            {
                try {
                        var f = TagLib.File.Create(path);
                    if (f.Tag.Pictures.Length >= 1)
                    {
                        TagLib.IPicture pic = f.Tag.Pictures[0];
                        MemoryStream ms = new MemoryStream(pic.Data.Data);
                        ms.Seek(0, SeekOrigin.Begin);

                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.StreamSource = ms;
                        bitmap.EndInit();

                        return (bitmap);
                    }
                    else
                        return null;
                }catch (Exception ex)
                {
                    Console.Error.WriteLine("Media corrupted : " + path + ". Can't find image from file");
                    return null;
                }
            }
            return null;

        }

        public string[] GetAudioFileInfo(string path)
        {
            string[] infos = new string[3]; // Title - Artiste - Album

            try
            {
                if (path != null && File.Exists(path))
                {


                TagLib.File tagFile = TagLib.File.Create(path);
                if (tagFile.Tag.Title != null)
                    infos[0] = tagFile.Tag.Title;
                else
                    infos[0] = "Titre Inconnu";
                if (tagFile.Tag.FirstPerformer != null)
                    infos[1] = tagFile.Tag.FirstPerformer;
                else
                    infos[1] = "Artiste Inconnu";
                if (tagFile.Tag.Album != null)
                    infos[2] = tagFile.Tag.Album;
                else
                    infos[2] = "Album Inconnu";
                return (infos);
            }
            else
                return (null);
            }catch (Exception ex)
            {
                Console.WriteLine("A handled exception just occurred: " + ex.Message, "Exception Sample");
                Console.WriteLine("concerned path = " + path);
                infos[0] = "Titre Inconnu";
                infos[1] = "Artiste Inconnu";
                infos[2] = "Album Inconnu";
                return (infos);
            }
        }

        public void pauseMedia()
        {
            hide(window.controlMenu.pauseButton);
            show(window.controlMenu.playButton);
            window.mainDisplay.mediaElement.LoadedBehavior = MediaState.Pause;
        }

        public void stopMedia()
        {
            hide(window.controlMenu.pauseButton);
            show(window.controlMenu.playButton);
            window.mainDisplay.mediaElement.LoadedBehavior = MediaState.Stop;
        }

        public void startMusicMedia()
        {
            MainDisplayViewModel mdvm = window.mainDisplay.DataContext as MainDisplayViewModel;

            mdvm.isMusic = true;
            window.mainDisplay.mediaMusic.Source = new Uri("pack://application:,,,/WpfApplication1;component/Resources/RingEqualizer.mp4");
            window.mainDisplay.mediaMusic.Visibility = Visibility.Visible;
            window.mainDisplay.mediaMusic.LoadedBehavior = MediaState.Play;
        }

        public void stopMusicMedia()
        {
            window.mainDisplay.mediaMusic.Visibility = Visibility.Collapsed;
            window.mainDisplay.mediaMusic.LoadedBehavior = MediaState.Stop;
        }



    }
}
