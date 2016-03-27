using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfApplication1.Util;
using WpfApplication1.View;

namespace WpfApplication1
{
    public partial class topMenuViewModel : INotifyPropertyChanged
    {
        private MediaFunctions utils;

        public topMenuViewModel(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            utils = new MediaFunctions(mainWindow);
            fileOpener = new RelayCommand(openFile);
            fluxOpener = new RelayCommand(fluxOpening);
            playlistGenerator = new RelayCommand(generatePlayList);
            folderBrowser = new RelayCommand(folderBrowsing);
            folderOpener = new RelayCommand(folderOpening);
            closeBrowseFolder = new RelayCommand(folderClosing);
            setFullScreen = new RelayCommand(fullscreen);
            goNext = new RelayCommand(nextMedia);
            goPrev = new RelayCommand(prevMedia);
            playMedia = new RelayCommand(mediaPlaying);
            pauseMedia = new RelayCommand(mediaPausing);
            stopMedia = new RelayCommand(mediaStopping);
            muteVol = new RelayCommand(volumeMuting);
            unmuteVol = new RelayCommand(volumeUnmuting);
            closeapp = new RelayCommand(closeApp);
            ReadFluxBtn = new RelayCommand(ReadFlux);
            fluxCloser = new RelayCommand(fluxClosing);
            aboutOpener = new RelayCommand(aboutOpening);
            aboutCloser = new RelayCommand(aboutClosing);
            importPlayList = new RelayCommand(playListImportation);
            takeScreenShot = new RelayCommand(screenShotTaking);
        }

        public void screenShotTaking(object obj)
        {
            

            double actualHeight = mainWindow.RenderSize.Height;
            double actualWidth = mainWindow.RenderSize.Width;

            RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)actualWidth,
        (int)actualHeight, 96, 96, PixelFormats.Pbgra32);
            VisualBrush sourceBrush = new VisualBrush(mainWindow.mainDisplay.mediaElement);

            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            using (drawingContext)
            {
                drawingContext.PushTransform(new ScaleTransform(1, 1));
                drawingContext.DrawRectangle(sourceBrush, null, new Rect(new System.Windows.Point(0, 0),
                    new System.Windows.Point(actualWidth, actualHeight)));
            }
            renderTarget.Render(drawingVisual);

            JpegBitmapEncoder jpgEncoder = new JpegBitmapEncoder();
            jpgEncoder.QualityLevel = 90;
            jpgEncoder.Frames.Add(BitmapFrame.Create(renderTarget));

            Byte[] imageArray;

            using (MemoryStream outputStream = new MemoryStream())
            {
                jpgEncoder.Save(outputStream);
                imageArray = outputStream.ToArray();
            }

            System.Windows.Forms.FolderBrowserDialog fb = new System.Windows.Forms.FolderBrowserDialog();
            fb.ShowDialog();
            if (fb.SelectedPath.Length > 0)
            {
                string path = fb.SelectedPath + "\\Capture.jpg";
                FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                BinaryWriter binaryWriter = new BinaryWriter(fileStream);
                binaryWriter.Write(imageArray);
                binaryWriter.Close();
            }
        }

        public void nextMedia(object obj)
        {
            utils.nextMedia();
        }

        public void volumeMuting(object obj)
        {
            ControlMenuViewModel cvm = mainWindow.controlMenu.DataContext as ControlMenuViewModel;
            cvm.volumeMuted(null);
        }

        public void volumeUnmuting(object obj)
        {
            ControlMenuViewModel cvm = mainWindow.controlMenu.DataContext as ControlMenuViewModel;
            cvm.volumeUnMuted(null);
        }

        public void prevMedia(object obj)
        {
            utils.prevMedia();
        }
        public void mediaPausing(object obj)
        {
            utils.pauseMedia();
        }
        public void mediaPlaying(object obj)
        {
            utils.playMedia(null);
        }

        public void mediaStopping(object obj)
        {
            utils.stopMedia();
        }

        public void fluxOpening(object obj)
        {
            fluxIsOpen = true;
        }

        public void fluxClosing(object obj)
        {
            fluxIsOpen = false;
        }

        public void aboutOpening(object obj)
        {
            aboutIsOpen = true;
        }

        public void aboutClosing(object obj)
        {
            aboutIsOpen = false;
        }

        public void folderOpening(object obj)
        {
            browseIsOpen = true;
        }

        public void fullscreen(object obj)
        {
            utils.fullscreen();
        }

        public void closeApp(object obj)
        {
            Application.Current.Shutdown();
        }

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }




    }
}
