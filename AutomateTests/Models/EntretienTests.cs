using Automate.Models;
using NUnit.Framework;

namespace AutomateTests.Models
{
    [TestFixture]
    public class EntretienTests
    {
        [Test]
        public void Constructor_ShouldInitializeType()
        {
            string description = "Description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Entretien entretien = new(description, alert, date);

            Assert.AreEqual("Entretien", entretien.Type);
        }

        [Test]
        public void Constructor_ShouldInitializeDescription()
        {
            string description = "Description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Entretien entretien = new(description, alert, date);

            Assert.AreEqual(description, entretien.Description);
        }

        [Test]
        public void Constructor_ShouldInitializeAlert()
        {
            string description = "Description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Entretien entretien = new(description, alert, date);

            Assert.AreEqual(alert, entretien.Alert);
        }

        [Test]
        public void Constructor_ShouldInitializeColour()
        {
            string description = "Description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Entretien entretien = new(description, alert, date);

            Assert.AreEqual("Orange", entretien.Colour);
        }

        [Test]
        public void Colour_ShouldBeOrangeByDefault()
        {
            DateTime date = DateTime.UtcNow;

            Entretien entretien = new(null, null, date);

            Assert.AreEqual("Orange", entretien.Colour);
        }

        [Test]
        public void Description_ShouldBeSetCorrectly()
        {
            string description = "Description";
            DateTime date = DateTime.UtcNow;

            Entretien entretien = new(description, null, date);

            Assert.AreEqual(description, entretien.Description);
        }

        [Test]
        public void Alert_ShouldBeSetCorrectly()
        {
            string alert = "UneSemaineAvant";
            DateTime date = DateTime.UtcNow;

            Entretien entretien = new(null, alert, date);

            Assert.AreEqual(alert, entretien.Alert);
        }
    }
}
