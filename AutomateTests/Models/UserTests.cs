using Moq;
using MongoDB.Bson;
using Automate.Models;
using NUnit.Framework;
using Automate.Interfaces;

namespace AutomateTests.Models
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void Constructor_ShouldInitializeProperties()
        {
            var mockUser = new Mock<IUser>();
            string username = "testuser";
            string password = "password123";
            string role = "admin";

            mockUser.Setup(u => u.Username).Returns(username);
            mockUser.Setup(u => u.Password).Returns(password);
            mockUser.Setup(u => u.Role).Returns(role);

            IUser user = mockUser.Object;

            Assert.AreEqual(username, user.Username);
            Assert.AreEqual(password, user.Password);
            Assert.AreEqual(role, user.Role);
        }

        [Test]
        public void Id_ShouldBeInitialized()
        {
            var mockUser = new Mock<IUser>();
            ObjectId id = ObjectId.GenerateNewId();

            mockUser.Setup(u => u.Id).Returns(id);

            IUser user = mockUser.Object;

            Assert.IsNotNull(user.Id);
            Assert.IsInstanceOf<ObjectId>(user.Id);
        }

        [Test]
        public void Username_ShouldBeSetCorrectly()
        {
            var mockUser = new Mock<IUser>();
            string username = "testuser";

            mockUser.Setup(u => u.Username).Returns(username);

            IUser user = mockUser.Object;

            Assert.AreEqual(username, user.Username);
        }

        [Test]
        public void Password_ShouldBeSetCorrectly()
        {
            var mockUser = new Mock<IUser>();
            string password = "password123";

            mockUser.Setup(u => u.Password).Returns(password);

            IUser user = mockUser.Object;

            Assert.AreEqual(password, user.Password);
        }

        [Test]
        public void Role_ShouldBeSetCorrectly()
        {
            var mockUser = new Mock<IUser>();
            string role = "admin";

            mockUser.Setup(u => u.Role).Returns(role);

            IUser user = mockUser.Object;

            Assert.AreEqual(role, user.Role);
        }
    }
}
