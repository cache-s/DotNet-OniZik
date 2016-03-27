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
using WpfApplication1.ViewModel;

namespace WpfApplication1
{
    public partial class topMenuViewModel : INotifyPropertyChanged
    {
        private MediaFunctions utilsFnc;
        public void folderClosing(object obj)
        {
            browseIsOpen = false;
        }

        public void folderBrowsing(object obj)
        {
            System.Windows.Forms.FolderBrowserDialog fb = new System.Windows.Forms.FolderBrowserDialog();
            fb.ShowDialog();
            if (fb.SelectedPath.Length > 0)
                browsePath = fb.SelectedPath;
        }

        public void ReadFlux(object obj)
        {
            utilsFnc = new MediaFunctions(mainWindow);
            string url = fluxPath;

            if (url != null)
            {
                mainWindow.mainDisplay.mediaElement.Source = new Uri(url, UriKind.Absolute);
                utilsFnc.playMedia("StreamFile");
            }
        }

        public void openFile(object obj)
        {
            utilsFnc = new MediaFunctions(mainWindow);
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Video Files|*.aaf;*.3gp;*.gif;*.asf;*.avchd;*.avi;*.cam;*.dat;*.dsh;*.dvr-ms;*.flv;*.m1v;*.m2v;*.fla;*.flr;*.sol;*.m4v;*.wrap;*.mng;*.mov;*.mpeg;*.mpg;*.mpe;*.mp4;*.mxf;*.rm;*.svi;*.smi;*.swf;*.wmv;*.wtv;";
            dlg.Filter += "|Audio Files|*.8svx;*.16svx;*.aif;*.aifc;*.aiff;*.au;*.bwf;*.cdda;*.raw;*.wav;*.flac;*.la;*.pac;*.m4a;*.ape;*.ofr;*.ofs;*.off;*.rka;*.shn;*.tak;*.tta;*.wv;*.brstm;*.dts;*.dtshd;*.dtsma;*.ast;*.amr;*.mp2;*.mp3;*.psx;*.gsm;*.wma;*.aac;*.m4a;*.mp4;*.m4p;*.mpc;*.vqf;*.ra;*.rm;*.ots;*.swa;*.vox;*.voc;*.dwd;*.smp;";
            dlg.Filter += "|Playlists|*.xml;*.asx;*.m3u;*.pls;*.ram;*.txt;*.xpl;*.xspf;*.zpl;*.aimppl";
            dlg.Filter += "|All Files (*.*)|*.*";
            dlg.ShowDialog();
            try
            {
                if (dlg.FileName.Length != 0)
                {
                    mainWindow.mainDisplay.mediaElement.Source = new Uri(dlg.FileName);
                    utilsFnc.setCurentPath(dlg.FileName);
                }

                switch (checkFileType(dlg.FileName))
                {
                    case "video":
                        utilsFnc.playMedia(dlg.FileName);
                        break;
                    case "audio":
                        utilsFnc.playMusic(dlg.FileName);
                        break;
                    case "image":
                        utilsFnc.playImage(dlg.FileName);
                        break;
                    default:
                        MessageBox.Show("Fichier non reconnu par l'application");
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("A handled exception just occurred in topMenu OpenFile : " + ex.Message, "Exception Sample");
                return;
            }

        }

        private string checkFileType(string fileName)
        {
            string extension = System.IO.Path.GetExtension(fileName);

            foreach (string ext in playableAudio)
                if (ext.Equals(extension) && File.Exists(fileName))
                    return "audio";
            foreach (string ext in playableVideo)
                if (ext.Equals(extension) && File.Exists(fileName))
                {
                    //MessageBox.Show(fileName + " is a valid video. ext from lists = " + ext + " extension = " + extension);
                    return "video";
                }
            foreach (string ext in playableImage)
                if (ext.Equals(extension) && File.Exists(fileName))
                    return "image";
            return "invalid";
        }

        public void listDirContent(string dir)
        {
            string[] fileEntries = Directory.GetFiles(dir);
            foreach (string fileName in fileEntries)
                addFileToPlayList(fileName);

            // Recurse on all sub-directories.
            if (recurCheck == true)
            {
                string[] subdirectoryEntries = Directory.GetDirectories(dir);
                foreach (string subdirectory in subdirectoryEntries)
                    listDirContent(subdirectory);
            }
        }

        public void addFileToPlayList(string file)
        {
            LibraryViewModel lvm = mainWindow.libraryMenu.DataContext as LibraryViewModel;

            switch (checkFileType(file))
            {
                case "video":
                    if (videoCheck == true)
                    {
                        //MessageBox.Show("ajout de la video " + file);
                        Console.WriteLine("ajout de " + file);
                        lvm.addToLibrary(file);
                    }
                    break;
                case "audio":
                    if (audioCheck == true)
                    {
                        //MessageBox.Show("ajout de l'audio " + file);
                        Console.WriteLine("ajout de " + file);
                        lvm.addToLibrary(file);
                    }
                    break;
                case "image":
                    if (imageCheck == true)
                    {
                        //MessageBox.Show("ajout de l'image" + file);
                        Console.WriteLine("ajout de " + file);
                        lvm.addToLibrary(file);
                    }
                    break;
                default:
                    break;
            }
        }

        public void generatePlayList(object obj)
        {
            try
            {
                listDirContent(browsePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("A handled exception just occurred in topMenu generatePlayList: " + ex.Message, "Exception Sample");
                return;
            }
            browseIsOpen = false;
        }

        public void playListCreation(object obj)
        {
            //TODO
        }

        public void playListImportation(object obj)
        {
            playlistViewModel pvm = mainWindow.playlistMenu.DataContext as playlistViewModel;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Playlists|*.xml;*.asx;*.m3u;*.pls;*.ram;*.txt;*.xpl;*.xspf;*.zpl;*.aimppl";
            dlg.ShowDialog();
            try
            {
                if (dlg.FileName.Length != 0)
                {
                    MessageBox.Show("ajout à la playlist" + dlg.FileName);
                    pvm.openPlaylistFile(dlg.FileName);
                }
                //todo

            }
            catch (Exception ex)
            {
                Console.WriteLine("A handled exception just occurred in topMenu PlayListImportation : " + ex.Message, "Exception Sample");
                return;
            }


        }
    }
}
