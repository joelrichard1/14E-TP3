using NUnit.Framework;
using Automate.Models;

namespace AutomateTests.Models
{
    [TestFixture]
    public class AdviceTests
    {
        [Test]
        public void Advice_InitializesWithEmptyList()
        {
            // Arrange & Act
            var advice = new Advice();

            // Assert
            Assert.IsNotNull(advice.Advices);
            Assert.IsEmpty(advice.Advices);
        }
    }
}