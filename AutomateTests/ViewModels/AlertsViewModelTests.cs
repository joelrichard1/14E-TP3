using Moq;
using NUnit.Framework;
using Automate.Interfaces;
using Automate.Models;
using Automate.ViewModels;

namespace AutomateTests.ViewModels
{
    [TestFixture]
    public class AlertsViewModelTests
    {
        private Mock<IMongoDBService>? mockMongoService;
        private AlertsViewModel? viewModel;

        [SetUp]
        public void Setup()
        {
            mockMongoService = new Mock<IMongoDBService>();
            mockMongoService.Setup(service => service.GetAllAlerts())
                .Returns(new List<Alert>
                {
                    new("Tâche 1", TypeAlertInt.UnJourAvant, DateTime.Today.AddDays(1)),
                    new("Tâche 2", TypeAlertInt.UneSemaineAvant, DateTime.Today.AddDays(4)),
                    new("Tâche 3", TypeAlertInt.DeuxJoursAvant, DateTime.Today.AddDays(-7))
                });

            viewModel = new AlertsViewModel(mockMongoService.Object);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Constructor_ShouldInitializeAlerts()
        {
            int initialAlertsCount = 2;
            int alertsCount = viewModel.Alerts.Count;
            Assert.AreEqual(initialAlertsCount, alertsCount);
        }
    }
}
