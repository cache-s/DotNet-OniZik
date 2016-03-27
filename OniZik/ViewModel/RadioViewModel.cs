using System;
using System.ComponentModel;
using System.Windows.Input;
using WpfApplication1.Util;
using WpfApplication1.ViewModel;
using WpfApplication1.View;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Win32;
using System.Windows;
using System.Collections.ObjectModel;
using WpfApplication1.Model;
using System.Windows.Media.Imaging;

namespace WpfApplication1
{
    class RadioViewModel : INotifyPropertyChanged
    {
        private MainWindow window;
        public event PropertyChangedEventHandler PropertyChanged;
        private MediaFunctions utils;

        private string _radioName = "";
        private string _radioFlow = "";
        private string _radioImage = "pack://application:,,,/WpfApplication1;component/Resources/Radios/RadioDefault.png";

        public bool inRadio;
        
        public RelayCommand AddImage { get; set; }
        public RelayCommand CreateRadio { get; set; }
        public RelayCommand PlayRadio { get; set; }
        public RelayCommand DeleteRadio { get; set; }
        private ObservableCollection<RadioItem> _radioList;
        public ObservableCollection<RadioItem> RadiosList
        {
            get { return _radioList; }
            set
            {
                _radioList = value;
                FirePropertyChanged("RadiosList");
            }
        }

        public RadioViewModel(MainWindow window)
        {
            this.window = window;
            inRadio = false;
            utils = new MediaFunctions(window);
            AddImage = new RelayCommand(addImage);
            CreateRadio = new RelayCommand(createRadio);
            PlayRadio = new RelayCommand(playRadio);
            DeleteRadio = new RelayCommand(deleteRadio);
            RadiosList = new ObservableCollection<RadioItem> { };
            printRadios();
        }

        public string RadioName
        {
            get { return _radioName; }
            set
            {
                _radioName = value;
                FirePropertyChanged("RadioName");
            }
        }

        public string RadioFlow
        {
            get { return _radioFlow; }
            set
            {
                _radioFlow = value;
                FirePropertyChanged("RadioFlow");
            }
        }

        public string RadioImage
        {
            get { return _radioImage; }
            set
            {
                _radioImage = value;
                FirePropertyChanged("RadioImage");
            }
        }

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void addImage(object sender)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image files|*.jpg;*.jpeg;*.jpe;*.jfif;*.png";
            dlg.ShowDialog();
            _radioImage = dlg.FileName;
            if (_radioImage == null)
                _radioImage = "pack://application:,,,/WpfApplication1;component/Resources/Radios/RadioDefault.png";
        }

        private void createRadio(object sender)
        {
            if (_radioName == null || _radioFlow == null)
            {

            }

            Radios radios = null;

            if (File.Exists("Radios.xml"))
            {
                XmlSerializer ds = new XmlSerializer(typeof(Radios));
                using (StreamReader rd = new StreamReader("Radios.xml"))
                {
                    radios = ds.Deserialize(rd) as Radios;
                }
            }
            else
                radios = new Radios();

            int id = 1;
            if (radios.Stations.Count != 0)
                id = radios.Stations[radios.Stations.Count - 1].Id + 1;
            Station station = new Station
            {
                Id = id,
                Name = _radioName,
                Flow = _radioFlow,
                Image = _radioImage
            };
            radios.Stations.Add(station);
            RadioName = RadioFlow = RadioImage = "";
            _radioImage = "pack://application:,,,/WpfApplication1;component/Resources/Radios/RadioDefault.png";
            RadiosList.Add(new RadioItem(station.Name, station.Id, station.Image, PlayRadio, DeleteRadio));

            XmlSerializer xs = new XmlSerializer(typeof(Radios));
            using (StreamWriter wr = new StreamWriter("Radios.xml"))
            {
                xs.Serialize(wr, radios);
            }
        }

        private void printRadios()
        {
            if (!File.Exists("Radios.xml"))
                InitRadios();
            try
            {
                RadiosList.Clear();
                Radios radios = null;

                if (File.Exists("Radios.xml"))
                {
                    XmlSerializer ds = new XmlSerializer(typeof(Radios));
                    try
                    {
                        using (StreamReader rd = new StreamReader("Radios.xml"))
                        {
                            radios = ds.Deserialize(rd) as Radios;
                        }
                    }
                    catch (Exception ex)
                    {
                        File.Delete("Radios.xml");
                        MessageBox.Show("Fichier radios corrompu, création d'un nouveau fichier", "OniZik", MessageBoxButton.OK, MessageBoxImage.Error);
                        radios = new Radios();
                        Console.Error.WriteLine(ex.ToString());
                    }
                }

                foreach (var station in radios.Stations)
                {
                    RadiosList.Add(new RadioItem(station.Name, station.Id, station.Image, PlayRadio, DeleteRadio));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }

        private void InitRadios()
        {
            Radios radios = null;

            if (File.Exists("Radios.xml"))
            {
                XmlSerializer ds = new XmlSerializer(typeof(Radios));
                using (StreamReader rd = new StreamReader("Radios.xml"))
                {
                    radios = ds.Deserialize(rd) as Radios;
                }
            }
            else
                radios = new Radios();

            Station stationNRJ = new Station
            {
                Id = 1,
                Name = "NRJ",
                Flow = "http://mp3lg4.scdn.arkena.com/8432/nrj_205243.mp3",
                Image = "pack://application:,,,/WpfApplication1;component/Resources/Radios/RadioNRJ.png"
            };
            radios.Stations.Add(stationNRJ);
            RadioName = RadioFlow = RadioImage = "";
            RadiosList.Add(new RadioItem(stationNRJ.Name, stationNRJ.Id, stationNRJ.Image, PlayRadio, DeleteRadio));

            Station stationLeMouv = new Station
            {
                Id = 2,
                Name = "LeMouv",
                Flow = "http://www.listenlive.eu/lemouv128.m3u",
                Image = "pack://application:,,,/WpfApplication1;component/Resources/Radios/RadioLeMouv.jpg"
            };
            radios.Stations.Add(stationLeMouv);
            RadioName = RadioFlow = RadioImage = "";
            RadiosList.Add(new RadioItem(stationLeMouv.Name, stationLeMouv.Id, stationLeMouv.Image, PlayRadio, DeleteRadio));

            _radioImage = "pack://application:,,,/WpfApplication1;component/Resources/Radios/RadioDefault.png";
            XmlSerializer xs = new XmlSerializer(typeof(Radios));
            using (StreamWriter wr = new StreamWriter("Radios.xml"))
            {
                xs.Serialize(wr, radios);
            }
        }

        private void playRadio(object sender)
        {
            int id = (int)sender;

            try
            {
                Radios radios = null;

                if (File.Exists("Radios.xml"))
                {
                    XmlSerializer ds = new XmlSerializer(typeof(Radios));
                    try
                    {
                        using (StreamReader rd = new StreamReader("Radios.xml"))
                        {
                            radios = ds.Deserialize(rd) as Radios;
                        }
                    }
                    catch (Exception ex)
                    {
                        File.Delete("Radios.xml");
                        MessageBox.Show("Fichier radios corrompu, création d'un nouveau fichier", "OniZik", MessageBoxButton.OK, MessageBoxImage.Error);
                        radios = new Radios();
                        Console.Error.WriteLine(ex.ToString());
                    }
                    foreach (var station in radios.Stations)
                    {
                        if (station.Id == id)
                        {
                            inRadio = true;
                            if (!station.Flow.Equals(""))
                            {
                                window.mainDisplay.mediaElement.Source = new Uri(station.Flow, UriKind.Absolute);
                                utils.playMusic("StreamFile");
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : Impossible de lancer la radio, " + ex.Message);
            }
        }

        private void deleteRadio(object sender)
        {
            int id = (int)sender;
            Radios radios;
            if (File.Exists("Radios.xml"))
            {
                XmlSerializer ds = new XmlSerializer(typeof(Radios));
                using (StreamReader rd = new StreamReader("Radios.xml"))
                {
                    radios = ds.Deserialize(rd) as Radios;
                }
                int position = radios.Stations.Count - id;
                int index = -1;
                foreach (var Station in radios.Stations)
                {
                    ++index;
                    if (Station.Id == id)
                    {
                        radios.Stations.Remove(Station);
                        RadiosList.RemoveAt(index);
                        break;
                    }
                }
                XmlSerializer xs = new XmlSerializer(typeof(Radios));
                using (StreamWriter wr = new StreamWriter("Radios.xml"))
                {
                    xs.Serialize(wr, radios);
                }
            }
        }
    }
}
