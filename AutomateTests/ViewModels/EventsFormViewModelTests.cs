using Automate.Interfaces;
using Automate.Models;
using Automate.ViewModels;
using MongoDB.Bson;
using Moq;
using NUnit.Framework;
using System.Windows;

namespace AutomateTests.ViewModels
{
    [TestFixture]
    public class EventsFormViewModelTests
    {
        private Mock<Window>? mockWindow;
        private Mock<IMongoDBService>? mockMongoService;
        private Mock<Tache>? mockTache;
        private EventsFormViewModel? viewModel;

        [SetUp]
        public void Setup()
        {
            mockWindow = new Mock<Window>();
            mockMongoService = new Mock<IMongoDBService>();
            mockTache = new Mock<Tache>();

            mockTache.SetupAllProperties();
            mockTache.Object.Id = ObjectId.GenerateNewId();

            viewModel = new EventsFormViewModel(mockWindow.Object, mockMongoService.Object);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Constructor_ShouldInitializeSubmitCommand()
        {
            Assert.NotNull(viewModel!.SubmitCommand);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Constructor_ShouldInitializeTypesTache()
        {
            Assert.NotNull(viewModel!.TypesTache);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void TypesTache_ShouldNotBeEmpty()
        {
            Assert.IsNotEmpty(viewModel!.TypesTache);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Constructor_ShouldInitializeTypesAlert()
        {
            Assert.NotNull(viewModel!.TypesAlert);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void TypesAlert_ShouldNotBeEmpty()
        {
            Assert.IsNotEmpty(viewModel!.TypesAlert);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void ShouldSetAndGetType()
        {
            string expectedType = "Semis";

            viewModel!.Type = expectedType;

            Assert.AreEqual(expectedType, viewModel.Type);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void ShouldSetAndGetDescription()
        {
            string expectedDescription = "Description";

            viewModel!.Description = expectedDescription;

            Assert.AreEqual(expectedDescription, viewModel.Description);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void ShouldSetAndGetAlert()
        {
            string expectedAlert = "Alert";

            viewModel!.Alert = expectedAlert;

            Assert.AreEqual(expectedAlert, viewModel.Alert);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void ShouldSetAndGetSelectedDate()
        {
            DateTime expectedDate = new(2024, 5, 1);

            viewModel!.SelectedDate = expectedDate;

            Assert.AreEqual(expectedDate, viewModel.SelectedDate);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Submit_ShouldNotCallAjouterTache_WhenFieldsAreNull()
        {
            viewModel!.Type = null;
            viewModel.Description = null;
            viewModel.Alert = null;

            viewModel.Submit();

            mockMongoService!.Verify(service => service.AjouterTache(It.IsAny<Tache>()), Times.Never);
        }
    }
}
