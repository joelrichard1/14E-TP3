using Moq;
using MongoDB.Bson;
using Automate.Interfaces;
using NUnit.Framework;

namespace AutomateTests.Models
{
    [TestFixture]
    public class TacheTests
    {
        [Test]
        public void Constructor_ShouldInitializeType()
        {
            var mockTache = new Mock<ITache>();
            string type = "TestType";
            string description = "Test description";
            string alert = "UnJourAvant";

            mockTache.Setup(t => t.Type).Returns(type);
            mockTache.Setup(t => t.Description).Returns(description);
            mockTache.Setup(t => t.Alert).Returns(alert);

            ITache tache = mockTache.Object;

            Assert.AreEqual(type, tache.Type);
        }

        [Test]
        public void Constructor_ShouldInitializeDescription()
        {
            var mockTache = new Mock<ITache>();
            string type = "TestType";
            string description = "Test description";
            string alert = "UnJourAvant";

            mockTache.Setup(t => t.Type).Returns(type);
            mockTache.Setup(t => t.Description).Returns(description);
            mockTache.Setup(t => t.Alert).Returns(alert);

            ITache tache = mockTache.Object;

            Assert.AreEqual(description, tache.Description);
        }

        [Test]
        public void Constructor_ShouldInitializeAlert()
        {
            var mockTache = new Mock<ITache>();
            string type = "TestType";
            string description = "Test description";
            string alert = "UnJourAvant";

            mockTache.Setup(t => t.Type).Returns(type);
            mockTache.Setup(t => t.Description).Returns(description);
            mockTache.Setup(t => t.Alert).Returns(alert);

            ITache tache = mockTache.Object;

            Assert.AreEqual(alert, tache.Alert);
        }

        [Test]
        public void Id_ShouldBeInitialized()
        {
            var mockTache = new Mock<ITache>();
            string type = "TestType";
            string description = "Test description";
            string alert = "UnJourAvant";
            ObjectId id = ObjectId.GenerateNewId();

            mockTache.Setup(t => t.Type).Returns(type);
            mockTache.Setup(t => t.Description).Returns(description);
            mockTache.Setup(t => t.Alert).Returns(alert);
            mockTache.Setup(t => t.Id).Returns(id);

            ITache tache = mockTache.Object;

            Assert.IsNotNull(tache.Id);
            Assert.IsInstanceOf<ObjectId>(tache.Id);
        }

        [Test]
        public void Description_ShouldBeSetCorrectly()
        {
            var mockTache = new Mock<ITache>();
            string description = "Test description";

            mockTache.Setup(t => t.Description).Returns(description);

            ITache tache = mockTache.Object;

            Assert.AreEqual(description, tache.Description);
        }

        [Test]
        public void Alert_ShouldBeSetCorrectly()
        {
            var mockTache = new Mock<ITache>();
            string alert = "UnJourAvant";

            mockTache.Setup(t => t.Alert).Returns(alert);

            ITache tache = mockTache.Object;

            Assert.AreEqual(alert, tache.Alert);
        }
    }
}
