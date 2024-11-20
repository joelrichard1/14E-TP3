using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Automate.Models;
using Automate.Utils;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Automate.Interfaces;
using System.Windows.Controls;
using System.Diagnostics;
using MongoDB.Bson;
using System.Collections;

namespace Automate.ViewModels
{
    public class EventsFormViewModel : INotifyPropertyChanged
    {
        private bool _isEdit;
        private readonly Window _window;
        private ObjectId? _id;
        private string? _type;
        private string? _description;
        private string? _alert;
        private readonly IMongoDBService _mongoService;
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand SubmitCommand { get; }
        public List<TypeTache> TypesTache { get; }
        public List<TypeAlert> TypesAlert { get; }
        private DateTime _selectedDate;
        private readonly Dictionary<string, List<string>> _errors = new();
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
        public bool HasErrors => _errors.Count > 0;


        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }

        public EventsFormViewModel(Window openedWindow, IMongoDBService mongoService)
        {
            _isEdit = false;

            _mongoService = mongoService;
            SubmitCommand = new RelayCommand(Submit);

            _window = openedWindow;
            TypesTache = Enum.GetValues(typeof(TypeTache)).Cast<TypeTache>().ToList();
            TypesAlert = Enum.GetValues(typeof(TypeAlert)).Cast<TypeAlert>().ToList();

            SelectedDate = DateTime.Today;
        }

        public EventsFormViewModel(Window openedWindow, IMongoDBService mongoService, Tache tache)
        {
            _isEdit = true;

            _mongoService = mongoService;
            SubmitCommand = new RelayCommand(Submit);

            _window = openedWindow;
            TypesTache = Enum.GetValues(typeof(TypeTache)).Cast<TypeTache>().ToList();
            TypesAlert = Enum.GetValues(typeof(TypeAlert)).Cast<TypeAlert>().ToList();

            Calendar calendar = (Calendar)_window.FindName("cal_Calendar");
            ComboBox cbType = (ComboBox)_window.FindName("cb_Type");
            TextBox tbDescription = (TextBox)_window.FindName("tb_Description");
            ComboBox cbAlert = (ComboBox)_window.FindName("cb_Alert");

            Id = tache.Id;

            if (cbType != null)
            {
                cbType.SelectedItem = tache.Type;
                cbType.SelectedIndex = GetTypeTacheIndex(tache.Type!);
                Type = tache.Type;
            }

            if (tbDescription != null)
            {
                tbDescription.Text = tache.Description;
                Description = tache.Description;
            }

            if (cbAlert != null)
            {
                cbAlert.SelectedItem = tache.Alert;
                cbAlert.SelectedIndex = GetTypeAlertIndex(tache.Alert!);
                Alert = tache.Alert;
            }

            if (calendar != null)
            {
                calendar.SelectedDate = tache.Date;
                SelectedDate = (DateTime)tache.Date!;
            }
        }

        public string? Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
                ValidateProperty(nameof(Type));
            }
        }

        public string? Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
                ValidateProperty(nameof(Description));
            }
        }

        public string? Alert
        {
            get => _alert;
            set
            {
                _alert = value;
                OnPropertyChanged(nameof(Alert));
                ValidateProperty(nameof(Alert));
            }
        }

        public string? ErrorMessages
        {
            get
            {
                var allErrors = new List<string>();
                foreach (var errorList in _errors.Values)
                {
                    allErrors.AddRange(errorList);
                }
                allErrors.RemoveAll(error => string.IsNullOrWhiteSpace(error));

                return string.Join("\n", allErrors);
            }
        }

        public ObjectId? Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }

        public bool isEdit
        {
            get => _isEdit;
            set
            {
                _isEdit = value;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Submit()
        {
            ValidateProperty(nameof(Type));
            ValidateProperty(nameof(Description));
            ValidateProperty(nameof(Alert));
            if (!HasErrors)
            {
                Tache? tache = CreerTache(Type, description: Description, alert: Alert, date: SelectedDate);
                if (_isEdit)
                {
                    tache.Id = (ObjectId)_id!;
                    _mongoService.UpdateTask(tache);
                    MessageBox.Show("Tâche modifiée avec succès !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    _mongoService.AjouterTache(tache);
                    MessageBox.Show("Tâche créée avec succès !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                NavigationService.Close(_window);
            }
        }

        public static Tache? CreerTache(string type, string description, string alert, DateTime date)
        {
            return type switch
            {
                "Semis" => new Semis(description, alert, date),
                "Arrosage" => new Arrosage(description, alert, date),
                "Commande" => new Commande(description, alert, date),
                "Recolte" => new Recolte(description, alert, date),
                "Evenement" => new Evenement(description, alert, date),
                "Entretien" => new Entretien(description, alert, date),
                "Rempotage" => new Rempotage(description, alert, date),
                _ => null
            };
        }

        private static int GetTypeTacheIndex(string type)
        {
            if (Enum.TryParse(type, out TypeTache typeTache))
                return Array.IndexOf(Enum.GetValues(typeof(TypeTache)), typeTache);
            return -1;
        }

        private static int GetTypeAlertIndex(string alert)
        {
            if (Enum.TryParse(alert, out TypeAlert typeAlert))
                return Array.IndexOf(Enum.GetValues(typeof(TypeAlert)), typeAlert);
            return -1;
        }

        private void ValidateProperty(string? propertyName)
        {
            switch (propertyName)
            {
                case nameof(Type):
                    if (string.IsNullOrEmpty(Type))
                        AddError(nameof(Type), "Le type ne peut pas être vide.");
                    else
                        RemoveError(nameof(Type));
                    break;

                case nameof(Description):
                    if (string.IsNullOrEmpty(Description))
                        AddError(nameof(Description), "La description ne peut pas être vide.");
                    else
                        RemoveError(nameof(Description));
                    break;

                case nameof(Alert):
                    if (string.IsNullOrEmpty(Alert))
                        AddError(nameof(Alert), "L'alerte ne peut pas être vide.");
                    else
                        RemoveError(nameof(Alert));
                    break;

                case nameof(SelectedDate):
                    if (SelectedDate < DateTime.Today)
                        AddError(nameof(SelectedDate), "La date ne peut pas être dans le passé.");
                    else
                        RemoveError(nameof(SelectedDate));
                    break;
            }
        }

        private void AddError(string propertyName, string errorMessage)
        {
            if (!_errors.ContainsKey(propertyName))
            {
                _errors[propertyName] = new List<string>();
            }
            if (!_errors[propertyName].Contains(errorMessage))
            {
                _errors[propertyName].Add(errorMessage);
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
            OnPropertyChanged(nameof(ErrorMessages));
        }

        private void RemoveError(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
            OnPropertyChanged(nameof(ErrorMessages));
        }

        public IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !_errors.ContainsKey(propertyName))
            {
                return Enumerable.Empty<string>();
            }

            return _errors[propertyName];
        }
    }
}
