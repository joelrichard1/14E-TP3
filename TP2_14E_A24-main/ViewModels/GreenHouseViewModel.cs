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
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Automate.ViewModels
{
    public class GreenHouseViewModel : INotifyPropertyChanged
    {
        private const string StatusOpen = "Ouvert";
        private const string StatusClosed = "Fermé";
        private const int SimulationInterval = 10;

        private GreenhouseCondition _initialCondition;
        private GreenhouseCondition _currentCondition;
        private List<GreenhouseCondition> _conditions;
        private string temperature;
        private string humidity;
        private string luminosity;
        private string buttonText;
        private int currentIndex = 0;
        private bool isReading;
        private DispatcherTimer _timer;
        private List<string> _advices;
        private ICropConditions TomatoConditions = new TomatoConditions();
        public SystemStatus systemStatus;
        public ICommand ToggleWindowCommand => new RelayCommand(() => ToggleStatus("Window"));
        public ICommand ToggleFanCommand => new RelayCommand(() => ToggleStatus("Fan"));
        public ICommand ToggleIrrigationCommand => new RelayCommand(() => ToggleStatus("Irrigation"));
        public ICommand ToggleHeatingCommand => new RelayCommand(() => ToggleStatus("Heating"));
        public ICommand ToggleLightsCommand => new RelayCommand(() => ToggleStatus("Lights"));
        public ICommand ToggleReadingCommand => new RelayCommand(ToggleReading);

        public event PropertyChangedEventHandler PropertyChanged;

        public GreenHouseViewModel()
        {
            _conditions = LoadConditionsFromCsv();

            _initialCondition = new GreenhouseCondition();

            _initialCondition.Temperature = 20;
            _initialCondition.Humidity = 50;
            _initialCondition.Luminosity = 600;

            _currentCondition = _initialCondition;

            Temperature = _currentCondition.Temperature.ToString();
            Humidity = _currentCondition.Humidity.ToString();
            Luminosity = _currentCondition.Luminosity.ToString();
            currentIndex = 0;
            isReading = false;
            ButtonText = "Démarrer Simulation";
            Advices = new List<string>();
            systemStatus = new SystemStatus();
            systemStatus.IsVentilationActive = false;
            systemStatus.AreLightsActive = false;
            systemStatus.AreSprinklersActive = false;
            systemStatus.AreWindowsActive = false;
            systemStatus.IsHeatingActive = false;

            UpdateConditionLabels();
            UpdateAdvices();
        }

        private string GetStatusText(bool isActive)
        {
            return isActive ? StatusOpen : StatusClosed;
        }

        public string WindowStatus
        {
            get => GetStatusText(systemStatus.AreWindowsActive);
        }

        public string FanStatus
        {
            get => GetStatusText(systemStatus.IsVentilationActive);
        }

        public string IrrigationStatus
        {
            get => GetStatusText(systemStatus.AreSprinklersActive);
        }

        public string HeatingStatus
        {
            get => GetStatusText(systemStatus.IsHeatingActive);
        }

        public string LightsStatus
        {
            get => GetStatusText(systemStatus.AreLightsActive);
        }

        private Brush GetStatusColor(bool isActive)
        {
            return isActive ? Brushes.Green : Brushes.Red;
        }

        public Brush WindowColor
        {
            get => GetStatusColor(systemStatus.AreWindowsActive);
        }

        public Brush FanColor
        {
            get => GetStatusColor(systemStatus.IsVentilationActive);
        }

        public Brush IrrigationColor
        {
            get => GetStatusColor(systemStatus.AreSprinklersActive);
        }

        public Brush HeatingColor
        {
            get => GetStatusColor(systemStatus.IsHeatingActive);
        }

        public Brush LightsColor
        {
            get => GetStatusColor(systemStatus.AreLightsActive);
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
            set
            {
                luminosity = value; OnPropertyChanged();
            }
        }

        public List<string> Advices
        {
            get => _advices;
            set { _advices = value; OnPropertyChanged(); OnPropertyChanged(nameof(AdvicesText)); }
        }

        public string AdvicesText => string.Join("\n", Advices);

        public string ButtonText
        {
            get => buttonText;
            set { buttonText = value; OnPropertyChanged(); }
        }

        private void ToggleStatus(string systemControl)
        {
            switch (systemControl)
            {
                case "Window":
                    systemStatus.AreWindowsActive = !systemStatus.AreWindowsActive;
                    OnPropertyChanged(nameof(WindowStatus));
                    OnPropertyChanged(nameof(WindowColor));
                    break;
                case "Fan":
                    systemStatus.IsVentilationActive = !systemStatus.IsVentilationActive;
                    OnPropertyChanged(nameof(FanStatus));
                    OnPropertyChanged(nameof(FanColor));
                    break;
                case "Irrigation":
                    systemStatus.AreSprinklersActive = !systemStatus.AreSprinklersActive;
                    OnPropertyChanged(nameof(IrrigationStatus));
                    OnPropertyChanged(nameof(IrrigationColor));
                    break;
                case "Heating":
                    systemStatus.IsHeatingActive = !systemStatus.IsHeatingActive;
                    OnPropertyChanged(nameof(HeatingStatus));
                    OnPropertyChanged(nameof(HeatingColor));
                    break;
                case "Lights":
                    systemStatus.AreLightsActive = !systemStatus.AreLightsActive;
                    OnPropertyChanged(nameof(LightsStatus));
                    OnPropertyChanged(nameof(LightsColor));
                    break;
            }
            UpdateAdvices();
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
                Interval = TimeSpan.FromSeconds(SimulationInterval)
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
            ButtonText = "Démarrer Simulation";
            _currentCondition = _initialCondition;
            UpdateConditionLabels();
            UpdateAdvices();

            MessageBox.Show("La simulation est terminée. Les mesures originales ont été restaurées.",
                            "Fin de la simulation", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void UpdateCurrentConditions()
        {
            if (_conditions == null || _conditions.Count == 0) return;

            _currentCondition = _conditions[currentIndex];
            UpdateConditionLabels();
            UpdateAdvices();
            currentIndex = (currentIndex + 1) % _conditions.Count;
        }

        private void UpdateConditionLabels()
        {
            Temperature = $"{_currentCondition.Temperature} °C";
            Humidity = $"{_currentCondition.Humidity} %";
            Luminosity = $"{_currentCondition.Luminosity} LUX";
        }

        public void UpdateAdvices()
        {
            Advices = AdviceUtils.EvaluateConditions(TomatoConditions, systemStatus, _currentCondition);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
