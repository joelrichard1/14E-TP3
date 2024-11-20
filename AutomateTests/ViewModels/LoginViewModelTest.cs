using Automate.Utils;
using Automate.ViewModels;
using Moq;
using NUnit.Framework;
using System.Windows;
using Automate.Models;
using Automate;
using Automate.Interfaces;

namespace AutomateTests.ViewModels
{
    [TestFixture]
    public class LoginViewModelTests
    {
        private Mock<Window>? mockWindow;
        private Mock<IMongoDBService>? mockMongoService;
        private LoginViewModel? viewModel;

        [SetUp]
        public void Setup()
        {
            mockWindow = new Mock<Window>();
            mockMongoService = new Mock<IMongoDBService>();

            viewModel = new LoginViewModel(mockWindow.Object, mockMongoService.Object);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Constructor_ShouldInitializeAuthenticateCommand()
        {
            Assert.NotNull(viewModel!.AuthenticateCommand);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Constructor_ShouldInitializeHasErrors()
        {
            Assert.False(viewModel!.HasErrors);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Constructor_ShouldInitializeUsername()
        {
            Assert.Null(viewModel!.Username);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Constructor_ShouldInitializePassword()
        {
            Assert.Null(viewModel!.Password);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void ShouldValidateUsernameAndPassword_ShouldHaveErrors()
        {
            viewModel!.Username = "";
            viewModel.Password = "";

            viewModel.Authenticate();

            Assert.True(viewModel.HasErrors);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void ShouldValidateUsername_ShouldContainError()
        {
            viewModel!.Username = "";

            viewModel.Authenticate();

            Assert.Contains("Le nom d'utilisateur ne peut pas être vide.", (System.Collections.ICollection?)viewModel.GetErrors(nameof(viewModel.Username)));
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void ShouldValidatePassword_ShouldContainError()
        {
            viewModel!.Password = "";

            viewModel.Authenticate();

            Assert.Contains("Le mot de passe ne peut pas être vide.", (System.Collections.ICollection?)viewModel.GetErrors(nameof(viewModel.Password)));
        }

    }
}
