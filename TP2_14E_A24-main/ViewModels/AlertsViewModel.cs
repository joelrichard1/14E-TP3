using System.Collections.Generic;
using System.Collections.ObjectModel;
using Automate.Models;
using Automate.Utils;
using System.Linq;
using System;
using System.ComponentModel;
using Automate.Interfaces;

namespace Automate.ViewModels
{
    public class AlertsViewModel
    {
        private readonly IMongoDBService _mongoService;
        private ObservableCollection<Alert>? _alerts;
        public ObservableCollection<Alert> Alerts
        {
            get => _alerts;
            set
            {
                _alerts = value;
                OnPropertyChanged(nameof(Alerts));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public AlertsViewModel(IMongoDBService mongoService)
        {
            _mongoService = mongoService;
            Alerts = new ObservableCollection<Alert>();
            LoadDueAlerts();
        }

        private void LoadDueAlerts()
        {
            if (_mongoService != null)
            {
                List<Alert> alerts = _mongoService.GetAllAlerts();

                List<Alert> dueAlerts = new();
                DateTime today = DateTime.Today;

                foreach (Alert alert in alerts)
                {
                    {
                        if (alert.AlertData == 0)
                        {
                            continue;
                        }

                        DateTime alertDueDate = alert.Date.AddDays(-alert.AlertData);
                        if (today >= alertDueDate && today <= alert.Date)
                        {
                            dueAlerts.Add(alert);
                        }
                    }

                    List<Alert> sortedDueAlerts = dueAlerts.OrderBy(a => a.DaysRemaining).ToList();
                    Alerts = new ObservableCollection<Alert>(sortedDueAlerts);
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
