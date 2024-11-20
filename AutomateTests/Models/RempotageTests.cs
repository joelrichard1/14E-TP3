using Automate.Models;
using NUnit.Framework;

namespace AutomateTests.Models
{
    [TestFixture]
    public class RempotageTests
    {
        [Test]
        public void Constructor_ShouldInitializeType()
        {
            string description = "Description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Rempotage rempotage = new(description, alert, date);

            Assert.AreEqual("Rempotage", rempotage.Type);
        }

        [Test]
        public void Constructor_ShouldInitializeDescription()
        {
            string description = "Description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Rempotage rempotage = new(description, alert, date);

            Assert.AreEqual(description, rempotage.Description);
        }

        [Test]
        public void Constructor_ShouldInitializeAlert()
        {
            string description = "Description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Rempotage rempotage = new(description, alert, date);

            Assert.AreEqual(alert, rempotage.Alert);
        }

        [Test]
        public void Constructor_ShouldInitializeColour()
        {
            string description = "Description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Rempotage rempotage = new(description, alert, date);

            Assert.AreEqual("Green", rempotage.Colour);
        }

        [Test]
        public void Colour_ShouldBeGreenByDefault()
        {
            DateTime date = DateTime.UtcNow;

            Rempotage rempotage = new(null, null, date);

            Assert.AreEqual("Green", rempotage.Colour);
        }

        [Test]
        public void Description_ShouldBeSetCorrectly()
        {
            string description = "Description";
            DateTime date = DateTime.UtcNow;

            Rempotage rempotage = new(description, null, date);

            Assert.AreEqual(description, rempotage.Description);
        }

        [Test]
        public void Alert_ShouldBeSetCorrectly()
        {
            string alert = "UneSemaineAvant";
            DateTime date = DateTime.UtcNow;

            Rempotage rempotage = new(null, alert, date);

            Assert.AreEqual(alert, rempotage.Alert);
        }
    }
}
