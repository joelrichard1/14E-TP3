using Automate.Views;
using System;
using System.Windows.Input;
using System.Windows;
using Wpf.Ui.Controls;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Automate.Models;
using Wpf.Ui.Input;
using System.Linq;
using Automate.Utils;
using Automate.Interfaces;
using System.Diagnostics;
using System.Globalization;

namespace Automate.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {
        private readonly Window _window;
        public ICommand NextCommand { get; }
        public ICommand PreviousCommand { get; }
        public ICommand AjouterTacheCommand { get; }
        public ICommand OpenTaskCommand { get; }
        public ICommand OpenTasksDayCommand { get; }
        public ICurrentDateProvider CurrentDateProvider { get; set; }
        private ObservableCollection<DayModel>? _daysInMonth;
        public ObservableCollection<int> AvailableYears { get; set; }
        public ObservableCollection<Tache> Taches { get; set; } = new();

        private int selectedYear;
        public int SelectedYear
        {
            get => selectedYear;
            set
            {
                if (selectedYear != value)
                {
                    selectedYear = value;
                    OnPropertyChanged(nameof(SelectedYear));
                    UpdateDaysInMonth();
                }
            }
        }
        private bool _isEditMode;
        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                if (_isEditMode != value)
                {
                    _isEditMode = value;
                    OnPropertyChanged(nameof(IsEditMode));
                }
            }
        }
        private readonly IMongoDBService _mongoService;

        private readonly Dictionary<string, string> dictionaryCategories = new()
        {
            { "Semis", "Red" },
            { "Rempotage", "Green" },
            { "Entretien", "Orange" },
            { "Arrosage", "Blue" },
            { "Récolte", "Yellow" },
            { "Commandes", "Purple" },
            { "Événements spéciaux", "Pink" }
        };

        public Dictionary<string, string> DictionaryCategories
        {
            get => dictionaryCategories;
        }

        public ObservableCollection<DayModel>? DaysInMonth
        {
            get => _daysInMonth;
            private set
            {
                _daysInMonth = value;
                OnPropertyChanged();
            }
        }

        public string CurrentMonth =>
            string.Concat(CurrentDateProvider.CurrentDate.ToString("MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("fr-CA")).First().ToString().ToUpper(), CurrentDateProvider.CurrentDate.ToString("MMMM", System.Globalization.CultureInfo.CreateSpecificCulture("fr-CA")).AsSpan(1));

        public CalendarViewModel(Window openedWindow, IMongoDBService mongoService, ICurrentDateProvider currentDateProvider, bool isEditMode = false)
        {
            IsEditMode = isEditMode;
            NextCommand = new RelayCommand(NextMonth);
            PreviousCommand = new RelayCommand(PreviousMonth);
            AjouterTacheCommand = new RelayCommand(AddTask);
            OpenTaskCommand = new RelayCommand<Tache>(OpenTask);
            OpenTasksDayCommand = new RelayCommand<DayModel>(OpenTasksDay!);
            _mongoService = mongoService;
            CurrentDateProvider = currentDateProvider;
            DaysInMonth = new ObservableCollection<DayModel>();
            _window = openedWindow;
            AvailableYears = new ObservableCollection<int>();
            int currentYear = CurrentDateProvider.CurrentDate.Year;
            for (int year = currentYear - 10; year <= currentYear + 10; year++)
            {
                AvailableYears.Add(year);
            }
            SelectedYear = currentYear;

            LoadTachesForMonth();
        }

        public void NextMonth()
        {
            CurrentDateProvider.CurrentDate = CurrentDateProvider.CurrentDate.AddMonths(1);
            SelectedYear = CurrentDateProvider.CurrentDate.Year;
            UpdateCalendar();
        }

        public void PreviousMonth()
        {
            CurrentDateProvider.CurrentDate = CurrentDateProvider.CurrentDate.AddMonths(-1);
            SelectedYear = CurrentDateProvider.CurrentDate.Year;
            UpdateCalendar();
        }

        public void UpdateCalendar()
        {
            UpdateMonthDisplay();
            UpdateDaysInMonth();
            LoadTachesForMonth();
        }

        private void UpdateMonthDisplay()
        {
            var textBlock = (TextBlock)_window.FindName("currentMonthTextBlock");
            if (textBlock != null)
            {
                string capitalMonth = string.Concat(CurrentMonth[0].ToString().ToUpper(), CurrentMonth.AsSpan(1));
                textBlock.Text = capitalMonth;
            }
        }

        private void UpdateDaysInMonth()
        {
            if (DaysInMonth != null)
            {
                DaysInMonth.Clear();

                if (SelectedYear < 1 || SelectedYear > 9999)
                {
                    SelectedYear = DateTime.Now.Year;
                }

                int days = DateTime.DaysInMonth(SelectedYear, CurrentDateProvider.CurrentDate.Month);

                for (int day = 1; day <= days; day++)
                {
                    DaysInMonth.Add(new DayModel { Day = day });
                }
                LoadTachesForMonth();
            }
        }

        public void AddTask()
        {
            EventsFormWindow form = new();
            form.Closed += (sender, args) =>
            {
                UpdateCalendar();
            };

            form.ShowDialog();
        }

        private void LoadTachesForMonth()
        {
            if (_mongoService != null && DaysInMonth != null)
            {
                List<Tache> tasks = _mongoService.GetTachesForMonth(SelectedYear, CurrentDateProvider.CurrentDate.Month);

                var tasksPerDayDic = new Dictionary<int, List<Tache>>();

                foreach (var task in tasks)
                {
                    if (task.Date.HasValue)
                    {
                        int day = task.Date.Value.Day;
                        if (!tasksPerDayDic.TryGetValue(day, out List<Tache>? value))
                        {
                            value = new List<Tache>();
                            tasksPerDayDic[day] = value;
                        }

                        value.Add(task);
                    }
                }

                foreach (var day in DaysInMonth)
                {
                    if (tasksPerDayDic.TryGetValue(day.Day, out List<Tache>? value))
                    {
                        day.Taches = new ObservableCollection<Tache>(value);
                    }
                }

                OnPropertyChanged(nameof(DaysInMonth));
            }
        }

        private void OpenTask(Tache? tache)
        {
            if (tache != null)
            {
                TaskWindow taskWindow = new(tache);
                taskWindow.ShowDialog();
            }
        }

        private void OpenTasksDay(DayModel dayModel)
        {
            var tasksWindow = new TasksWindow(dayModel.Taches);

            tasksWindow.Closed += (sender, args) =>
            {
                UpdateCalendar();
            };

            tasksWindow.ShowDialog();
        }
    }
}
