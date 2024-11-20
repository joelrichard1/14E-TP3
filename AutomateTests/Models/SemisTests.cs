using Automate.Models;
using NUnit.Framework;

namespace AutomateTests.Models
{
    [TestFixture]
    public class SemisTests
    {
        [Test]
        public void Constructor_ShouldInitializeType()
        {
            string description = "Description";
            string alert = "UnJourAvant";
            DateTime date = DateTime.UtcNow;

            Semis semis = new(description, alert, date);

            Assert.AreEqual("Semis", semis.Type);
        }

        [Test]
        public void Constructor_ShouldInitializeDescription()
        {
            string description = "Description";
            string alert = "UnJourAvant";
            DateTime date = DateTime.UtcNow;

            Semis semis = new(description, alert, date);

            Assert.AreEqual(description, semis.Description);
        }

        [Test]
        public void Constructor_ShouldInitializeAlert()
        {
            string description = "Description";
            string alert = "UnJourAvant";
            DateTime date = DateTime.UtcNow;

            Semis semis = new(description, alert, date);

            Assert.AreEqual(alert, semis.Alert);
        }

        [Test]
        public void Constructor_ShouldInitializeColour()
        {
            string description = "Description";
            string alert = "UnJourAvant";
            DateTime date = DateTime.UtcNow;

            Semis semis = new(description, alert, date);

            Assert.AreEqual("Red", semis.Colour);
        }

        [Test]
        public void Colour_ShouldBeRedByDefault()
        {
            DateTime date = DateTime.UtcNow;

            Semis semis = new(null, null, date);

            Assert.AreEqual("Red", semis.Colour);
        }

        [Test]
        public void Description_ShouldBeSetCorrectly()
        {
            string description = "Description";
            DateTime date = DateTime.UtcNow;

            Semis semis = new(description, null, date);

            Assert.AreEqual(description, semis.Description);
        }

        [Test]
        public void Alert_ShouldBeSetCorrectly()
        {
            string alert = "UnJourAvant";
            DateTime date = DateTime.UtcNow;

            Semis semis = new(null, alert, date);

            Assert.AreEqual(alert, semis.Alert);
        }
    }
}
