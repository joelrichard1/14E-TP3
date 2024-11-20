using Automate.Models;
using NUnit.Framework;

namespace AutomateTests.Models
{
    [TestFixture]
    public class CommandeTests
    {
        [Test]
        public void Constructor_ShouldInitializeType()
        {
            string description = "Description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Commande commande = new(description, alert, date);

            Assert.AreEqual("Commande", commande.Type);
        }

        [Test]
        public void Constructor_ShouldInitializeDescription()
        {
            string description = "Description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Commande commande = new(description, alert, date);

            Assert.AreEqual(description, commande.Description);
        }

        [Test]
        public void Constructor_ShouldInitializeAlert()
        {
            string description = "Description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Commande commande = new(description, alert, date);

            Assert.AreEqual(alert, commande.Alert);
        }

        [Test]
        public void Constructor_ShouldInitializeColour()
        {
            string description = "Description";
            string alert = "UnMoisAvant";
            DateTime date = DateTime.UtcNow;

            Commande commande = new(description, alert, date);

            Assert.AreEqual("Purple", commande.Colour);
        }

        [Test]
        public void Colour_ShouldBePurpleByDefault()
        {
            DateTime date = DateTime.UtcNow;

            Commande commande = new(null, null, date);

            Assert.AreEqual("Purple", commande.Colour);
        }

        [Test]
        public void Description_ShouldBeSetCorrectly()
        {
            string description = "Description";
            DateTime date = DateTime.UtcNow;

            Commande commande = new(description, null, date);

            Assert.AreEqual(description, commande.Description);
        }

        [Test]
        public void Alert_ShouldBeSetCorrectly()
        {
            string alert = "UneSemaineAvant";
            DateTime date = DateTime.UtcNow;

            Commande commande = new(null, alert, date);

            Assert.AreEqual(alert, commande.Alert);
        }
    }
}
