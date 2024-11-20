using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Automate.Interfaces;
using Automate.Models;
using Automate.ViewModels;
using System.Windows;

namespace AutomateTests.ViewModels
{
    [TestFixture]
    public class CalendarViewModelTests
    {
        private Mock<IMongoDBService>? mockMongoService;
        private Mock<Window>? mockWindow;
        private Mock<ICurrentDateProvider>? mockCurrentDateProvider;
        private CalendarViewModel? viewModel;

        [SetUp]
        public void Setup()
        {
            mockMongoService = new Mock<IMongoDBService>();
            mockMongoService.Setup(service => service.GetTachesForMonth(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new List<Tache>
                {
                    new Rempotage("Tâche 1", "UnJourAvant", new DateTime(2024, 5, 10)),
                    new Semis("Tâche 2", "UnJourAvant", new DateTime(2024, 5, 15)),
                });

            mockWindow = new Mock<Window>();
            mockCurrentDateProvider = new Mock<ICurrentDateProvider>();
            mockCurrentDateProvider.SetupProperty(provider => provider.CurrentDate, new DateTime(2024, 5, 1));

            viewModel = new CalendarViewModel(mockWindow.Object, mockMongoService.Object, mockCurrentDateProvider.Object, false);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Constructor_ShouldInitializeSelectedYearToCurrentYear()
        {
            var currentYear = viewModel!.SelectedYear;
            Assert.AreEqual(2024, currentYear);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Constructor_ShouldInitializeAvailableYears()
        {
            var availableYearsCount = viewModel!.AvailableYears.Count;
            Assert.Greater(availableYearsCount, 0);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Constructor_ShouldInitializeDaysInMonth()
        {
            Assert.NotNull(viewModel!.DaysInMonth);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Constructor_ShouldPopulateDaysInMonth()
        {
            Assert.Greater(viewModel!.DaysInMonth!.Count, 0);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Constructor_ShouldInitializeNextCommand()
        {
            Assert.NotNull(viewModel!.NextCommand);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void Constructor_ShouldInitializePreviousCommand()
        {
            Assert.NotNull(viewModel!.PreviousCommand);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void NextMonth_ShouldIncrementMonth()
        {
            var initialDate = mockCurrentDateProvider!.Object.CurrentDate;
            var expectedDate = initialDate.AddMonths(1);

            viewModel!.NextMonth();

            Assert.AreEqual(expectedDate.Month, mockCurrentDateProvider.Object.CurrentDate.Month);
        }

        [Test]
        [Apartment(ApartmentState.STA)]
        public void PreviousMonth_ShouldDecrementMonth()
        {
            var initialDate = mockCurrentDateProvider!.Object.CurrentDate;
            var expectedDate = initialDate.AddMonths(-1);

            viewModel!.PreviousMonth();

            Assert.AreEqual(expectedDate.Month, mockCurrentDateProvider.Object.CurrentDate.Month);
        }
    }
}
