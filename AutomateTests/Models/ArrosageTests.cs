using Automate.Models;
using NUnit.Framework;

namespace AutomateTests.Models
{
    [TestFixture]
    public class ArrosageTests
    {
        [Test]
        public void Constructor_ShouldInitializeType()
        {
            string description = "Description";
            string alert = "DeuxJoursAvant";
            DateTime date = DateTime.UtcNow;

            Arrosage arrosage = new(description, alert, date);

            Assert.AreEqual("Arrosage", arrosage.Type);
        }

        [Test]
        public void Constructor_ShouldInitializeDescription()
        {
            string description = "Description";
            string alert = "DeuxJoursAvant";
            DateTime date = DateTime.UtcNow;

            Arrosage arrosage = new(description, alert, date);

            Assert.AreEqual(description, arrosage.Description);
        }

        [Test]
        public void Constructor_ShouldInitializeAlert()
        {
            string description = "Description";
            string alert = "DeuxJoursAvant";
            DateTime date = DateTime.UtcNow;

            Arrosage arrosage = new(description, alert, date);

            Assert.AreEqual(alert, arrosage.Alert);
        }

        [Test]
        public void Constructor_ShouldInitializeColour()
        {
            string description = "Description";
            string alert = "DeuxJoursAvant";
            DateTime date = DateTime.UtcNow;

            Arrosage arrosage = new(description, alert, date);

            Assert.AreEqual("Blue", arrosage.Colour);
        }

        [Test]
        public void Colour_ShouldBeBlueByDefault()
        {
            DateTime date = DateTime.UtcNow;

            Arrosage arrosage = new(null, null, date);

            Assert.AreEqual("Blue", arrosage.Colour);
        }

        [Test]
        public void Description_ShouldBeSetCorrectly()
        {
            string description = "Description";
            DateTime date = DateTime.UtcNow;

            Arrosage arrosage = new(description, null, date);

            Assert.AreEqual(description, arrosage.Description);
        }

        [Test]
        public void Alert_ShouldBeSetCorrectly()
        {
            string alert = "UneSemaineAvant";
            DateTime date = DateTime.UtcNow;

            Arrosage arrosage = new(null, alert, date);

            Assert.AreEqual(alert, arrosage.Alert);
        }
    }
}
