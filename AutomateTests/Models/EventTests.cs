using Automate.Models;
using NUnit.Framework;

namespace AutomateTests.Models
{
    [TestFixture]
    public class EventTests
    {
        [Test]
        public void Constructor_ShouldInitializeType()
        {
            string description = "description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Evenement evenement = new(description, alert, date);

            Assert.AreEqual("Evenement", evenement.Type);
        }

        [Test]
        public void Constructor_ShouldInitializeDescription()
        {
            string description = "description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Evenement evenement = new(description, alert, date);

            Assert.AreEqual(description, evenement.Description);
        }

        [Test]
        public void Constructor_ShouldInitializeAlert()
        {
            string description = "description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Evenement evenement = new(description, alert, date);

            Assert.AreEqual(alert, evenement.Alert);
        }

        [Test]
        public void Constructor_ShouldInitializeColour()
        {
            string description = "description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Evenement evenement = new(description, alert, date);

            Assert.AreEqual("Pink", evenement.Colour);
        }

        [Test]
        public void Colour_ShouldBePinkByDefault()
        {
            DateTime date = DateTime.UtcNow;

            Evenement evenement = new(null, null, date);

            Assert.AreEqual("Pink", evenement.Colour);
        }

        [Test]
        public void Description_ShouldBeSetCorrectly()
        {
            string description = "description";
            DateTime date = DateTime.UtcNow;

            Evenement evenement = new(description, null, date);

            Assert.AreEqual(description, evenement.Description);
        }

        [Test]
        public void Alert_ShouldBeSetCorrectly()
        {
            string alert = "UneSemaineAvant";
            DateTime date = DateTime.UtcNow;

            Evenement evenement = new(null, alert, date);

            Assert.AreEqual(alert, evenement.Alert);
        }
    }
}
