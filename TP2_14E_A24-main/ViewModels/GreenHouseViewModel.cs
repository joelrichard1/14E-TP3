using Automate.Models;
using Automate.Utils;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Automate.ViewModels
{
    public class GreenHouseViewModel : INotifyPropertyChanged
    {
        private List<GreenhouseCondition> _conditions;
        private Dictionary<string, string> status;
        private Dictionary<string, Brush> color;
        private string temperature;
        private string humidity;
        private string luminosity;
        private string buttonText;
        private int currentIndex = 0;
        private bool isReading;
        private DispatcherTimer _timer;
        public ICommand ToggleWindowCommand => new RelayCommand(() => ToggleStatus("Window"));
        public ICommand ToggleFanCommand => new RelayCommand(() => ToggleStatus("Fan"));
        public ICommand ToggleIrrigationCommand => new RelayCommand(() => ToggleStatus("Irrigation"));
        public ICommand ToggleHeatingCommand => new RelayCommand(() => ToggleStatus("Heating"));
        public ICommand ToggleLightsCommand => new RelayCommand(() => ToggleStatus("Lights"));
        public ICommand ToggleReadingCommand => new RelayCommand(ToggleReading);

        public event PropertyChangedEventHandler PropertyChanged;

        public GreenHouseViewModel()
        {
            status = new Dictionary<string, string>
            {
                { "Window", "Fermé" },
                { "Fan", "Fermé" },
                { "Irrigation", "Fermé" },
                { "Heating", "Fermé" },
                { "Lights", "Fermé" }
            };

            color = new Dictionary<string, Brush>
            {
                { "Window", Brushes.Red },
                { "Fan", Brushes.Red },
                { "Irrigation", Brushes.Red },
                { "Heating", Brushes.Red },
                { "Lights", Brushes.Red }
            };
            _conditions = LoadConditionsFromCsv();
            currentIndex = 0; 
            isReading = false; 
            ButtonText = "Démarrer";
            UpdateCurrentConditions();

        }

        public string WindowStatus
        {
            get => status["Window"];
            set { status["Window"] = value; OnPropertyChanged(); }
        }

        public Brush WindowColor
        {
            get => color["Window"];
            set { color["Window"] = value; OnPropertyChanged(); }
        }

        public string FanStatus
        {
            get => status["Fan"];
            set { status["Fan"] = value; OnPropertyChanged(); }
        }

        public Brush FanColor
        {
            get => color["Fan"];
            set { color["Fan"] = value; OnPropertyChanged(); }
        }

        public string IrrigationStatus
        {
            get => status["Irrigation"];
            set { status["Irrigation"] = value; OnPropertyChanged(); }
        }

        public Brush IrrigationColor
        {
            get => color["Irrigation"];
            set { color["Irrigation"] = value; OnPropertyChanged(); }
        }

        public string HeatingStatus
        {
            get => status["Heating"];
            set { status["Heating"] = value; OnPropertyChanged(); }
        }

        public Brush HeatingColor
        {
            get => color["Heating"];
            set { color["Heating"] = value; OnPropertyChanged(); }
        }

        public string LightsStatus
        {
            get => status["Lights"];
            set { status["Lights"] = value; OnPropertyChanged(); }
        }

        public Brush LightsColor
        {
            get => color["Lights"];
            set { color["Lights"] = value; OnPropertyChanged(); }
        }

        
        public string Temperature 
        {
            get => temperature;
            set { temperature = value; OnPropertyChanged(); } 
        }

        public string Humidity 
        { 
            get => humidity; 
            set { humidity = value; OnPropertyChanged(); } 
        }
         
        public string Luminosity 
        { 
            get => luminosity; 
            set { luminosity = value; OnPropertyChanged(); 
            } 
        }

        public string ButtonText 
        { 
            get => buttonText;
            set { buttonText = value; OnPropertyChanged(); } 
        }

        private void ToggleStatus(string key)
        {
            if (status[key] == "Ouvert")
            {
                status[key] = "Fermé";
                color[key] = Brushes.Red;
            }
            else
            {
                status[key] = "Ouvert";
                color[key] = Brushes.Green;
            }
            OnPropertyChanged($"{key}Status");
            OnPropertyChanged($"{key}Color");
        }

        private void ToggleReading() 
        { 
            if (isReading) 
            {
                StopReadingConditions(); 
            } 
            else 
            { 
                StartReadingConditions(); 
            } 
        }

        private List<GreenhouseCondition> LoadConditionsFromCsv()
        {
            using (var reader = new StreamReader("TempData.csv")) 
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read(); 
                csv.ReadHeader(); 
                return csv.GetRecords<GreenhouseCondition>().ToList(); 
            } 
        }

        private void StartReadingConditions() 
        {
            _timer = new DispatcherTimer 
            { 
                Interval = TimeSpan.FromSeconds(10) 
            }; 
            _timer.Tick += (sender, args) => UpdateCurrentConditions(); 
            _timer.Start(); 
            isReading = true; 
            ButtonText = "Arrêter";
        }

        private void StopReadingConditions() 
        { 
            _timer.Stop(); 
            isReading = false; 
            ButtonText = "Démarrer"; 
        }

        private void UpdateCurrentConditions()
        {
            if (_conditions == null || _conditions.Count == 0) return; 

            var condition = _conditions[currentIndex]; 
            Temperature = $"{condition.Température} °C"; 
            Humidity = $"{condition.Humidité} %"; 
            Luminosity = $"{condition.Luminosité} LUX"; 
            currentIndex = (currentIndex + 1) % _conditions.Count; 
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
