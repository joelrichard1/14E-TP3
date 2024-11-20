using Automate.Utils;
using Moq;
using NUnit.Framework;

namespace AutomateTests.Utils
{
    [TestFixture]
    public class RelayCommandTests
    {
        [Test]
        public void Constructor_WithParameter_ShouldThrowArgumentNullException_WhenExecuteIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new RelayCommand((Action<object>)null!));
        }

        [Test]
        public void Constructor_WithoutParameter_ShouldThrowArgumentNullException_WhenExecuteIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new RelayCommand((Action)null!));
        }

        [Test]
        public void CanExecute_ShouldReturnTrue_WhenNoCanExecuteDelegate()
        {
            var command = new RelayCommand(_ => { });

            var result = command.CanExecute(null);

            Assert.IsTrue(result);
        }

        [Test]
        public void CanExecute_ShouldReturnFalse_WhenCanExecuteWithParameterReturnsFalse()
        {
            var command = new RelayCommand(_ => { }, _ => false);

            var result = command.CanExecute(null);

            Assert.IsFalse(result);
        }

        [Test]
        public void CanExecute_ShouldReturnTrue_WhenCanExecuteWithParameterReturnsTrue()
        {
            var command = new RelayCommand(_ => { }, _ => true);

            var result = command.CanExecute(null);

            Assert.IsTrue(result);
        }

        [Test]
        public void CanExecute_ShouldReturnFalse_WhenCanExecuteWithoutParameterReturnsFalse()
        {
            var command = new RelayCommand(() => { }, () => false);

            var result = command.CanExecute(null);

            Assert.IsFalse(result);
        }

        [Test]
        public void CanExecute_ShouldReturnTrue_WhenCanExecuteWithoutParameterReturnsTrue()
        {
            var command = new RelayCommand(() => { }, () => true);

            var result = command.CanExecute(null);

            Assert.IsTrue(result);
        }

        [Test]
        public void Execute_WithParameter_ShouldCallExecuteWithParameter()
        {
            var mockAction = new Mock<Action<object>>();
            var command = new RelayCommand(mockAction.Object);

            command.Execute("test");

            mockAction.Verify(a => a("test"), Times.Once);
        }

        [Test]
        public void Execute_WithoutParameter_ShouldCallExecuteWithoutParameter()
        {
            var mockAction = new Mock<Action>();
            var command = new RelayCommand(mockAction.Object);

            command.Execute(null);

            mockAction.Verify(a => a(), Times.Once);
        }

        [Test]
        public void RaiseCanExecuteChanged_ShouldInvokeCanExecuteChangedEvent()
        {
            var command = new RelayCommand(_ => { });
            var eventInvoked = false;
            command.CanExecuteChanged += (sender, e) => eventInvoked = true;

            command.RaiseCanExecuteChanged();

            Assert.IsTrue(eventInvoked);
        }
    }
}
