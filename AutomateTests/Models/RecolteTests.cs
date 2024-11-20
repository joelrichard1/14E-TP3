using Automate.Models;
using NUnit.Framework;

namespace AutomateTests.Models
{
    [TestFixture]
    public class RecolteTests
    {
        [Test]
        public void Constructor_ShouldInitializeType()
        {
            string description = "description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Recolte recolte = new(description, alert, date);

            Assert.AreEqual("Recolte", recolte.Type);
        }

        [Test]
        public void Constructor_ShouldInitializeDescription()
        {
            string description = "description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Recolte recolte = new(description, alert, date);

            Assert.AreEqual(description, recolte.Description);
        }

        [Test]
        public void Constructor_ShouldInitializeAlert()
        {
            string description = "description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Recolte recolte = new(description, alert, date);

            Assert.AreEqual(alert, recolte.Alert);
        }

        [Test]
        public void Constructor_ShouldInitializeColour()
        {
            string description = "description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Recolte recolte = new(description, alert, date);

            Assert.AreEqual("Yellow", recolte.Colour);
        }

        [Test]
        public void Colour_ShouldBeYellowByDefault()
        {
            DateTime date = DateTime.UtcNow;

            Recolte recolte = new(null, null, date);

            Assert.AreEqual("Yellow", recolte.Colour);
        }

        [Test]
        public void Description_ShouldBeSetCorrectly()
        {
            string description = "description";
            DateTime date = DateTime.UtcNow;

            Recolte recolte = new(description, null, date);

            Assert.AreEqual(description, recolte.Description);
        }

        [Test]
        public void Alert_ShouldBeSetCorrectly()
        {
            string alert = "UneSemaineAvant";
            DateTime date = DateTime.UtcNow;

            Recolte recolte = new(null, alert, date);

            Assert.AreEqual(alert, recolte.Alert);
        }
    }
}
