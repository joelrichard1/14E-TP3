using Automate.Models;
using NUnit.Framework;

namespace AutomateTests.Models
{
    [TestFixture]
    public class AlertTests
    {
        [Test]
        public void Constructor_ShouldInitializeDescription()
        {
            string description = "description";
            TypeAlertInt alertType = TypeAlertInt.UnJourAvant;
            DateTime date = DateTime.UtcNow;

            Alert alert = new(description, alertType, date);

            Assert.AreEqual(description, alert.Description);
        }

        [Test]
        public void Constructor_ShouldInitializeAlertData()
        {
            string description = "description";
            TypeAlertInt alertType = TypeAlertInt.UnJourAvant;
            DateTime date = DateTime.UtcNow;

            Alert alert = new(description, alertType, date);

            Assert.AreEqual((int)alertType, alert.AlertData);
        }

        [Test]
        public void Constructor_ShouldInitializeDate()
        {
            string description = "description";
            TypeAlertInt alertType = TypeAlertInt.UnJourAvant;
            DateTime date = DateTime.UtcNow;

            Alert alert = new(description, alertType, date);

            Assert.AreEqual(date, alert.Date);
        }

        [Test]
        public void Description_ShouldBeSetCorrectly()
        {
            string description = "description";
            TypeAlertInt alertType = TypeAlertInt.UnJourAvant;
            DateTime date = DateTime.UtcNow;

            Alert alert = new(description, alertType, date);

            Assert.AreEqual(description, alert.Description);
        }

        [Test]
        public void AlertData_ShouldBeSetCorrectly()
        {
            string description = "description";
            TypeAlertInt alertType = TypeAlertInt.DeuxJoursAvant;
            DateTime date = DateTime.UtcNow;

            Alert alert = new(description, alertType, date);

            Assert.AreEqual((int)alertType, alert.AlertData);
        }

        [Test]
        public void Date_ShouldBeSetCorrectly()
        {
            string description = "description";
            TypeAlertInt alertType = TypeAlertInt.UneSemaineAvant;
            DateTime date = DateTime.UtcNow;

            Alert alert = new(description, alertType, date);

            Assert.AreEqual(date, alert.Date);
        }

        [Test]
        public void DaysRemaining_ShouldBeCalculatedCorrectly()
        {
            string description = "description";
            TypeAlertInt alertType = TypeAlertInt.DeuxJoursAvant;
            DateTime date = DateTime.Today.AddDays(10);

            Alert alert = new(description, alertType, date);

            int expectedDaysRemaining = (date - DateTime.Today).Days;
            Assert.AreEqual(expectedDaysRemaining, alert.DaysRemaining);
        }
    }
}
