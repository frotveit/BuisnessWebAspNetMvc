using BuisnessWeb.Controllers;
using Xunit;

namespace BuisnessWebXUnitTest.ControllerTests
{
    public class NameofUnitTest
    {
        [Fact]
        public void NameofShouldReturnNameOfAction()
        {
            Assert.Equal("Index", nameof(HomeController.Index));
        }

        [Fact]
        public void NameofShouldReturnNameOfController()
        {
            Assert.Equal("HomeController", nameof(HomeController));
        }
    }
}
