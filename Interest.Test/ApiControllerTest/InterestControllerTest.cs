using Interest.Application.Contract;
using Interest.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Interest.Test.ApiControllerTest
{
    [TestClass]
    public class InterestControllerTest
    {
        private Mock<ISimpleInterest> _mocksimpleInterestService = null!;
        private Mock<ICompoundInterest> _mockcompoundInterestService = null!;
        private InterestController _controller = null!;

        [TestInitialize]
        public void Setup()
        {
            _mocksimpleInterestService = new Mock<ISimpleInterest>();
            _mockcompoundInterestService = new Mock<ICompoundInterest>();
            _controller = new InterestController(_mockcompoundInterestService.Object, _mocksimpleInterestService.Object);
        }

        [TestMethod]
        public void CalculateSimpleInterest_ValidInput_ReturnCorrectResult()
        {
            // Arrange
            int principal = 1000;
            int rate = 5;
            int time = 2;
            double expectedInterest = (double)(principal * rate / 100 * time);

            _mocksimpleInterestService
                .Setup(f => f.CalculateSimpleInterest(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(expectedInterest);

            // Act
            var result = _controller.CalculateSimpleInterest(principal, rate, time) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);

           

            Assert.AreEqual(expectedInterest, (double)result.Value!, 0.001);

            _mocksimpleInterestService.Verify(f => f.CalculateSimpleInterest(principal, rate, time), Times.Once);
        }

        [TestMethod]
        [DataRow(0, 5, 2)]
        [DataRow(1000, 5, 0)]
        public void CalculateSimpleInterest_InvalidInput_RequestBadRequest(int principal, int rate, int time)
        {
            _mocksimpleInterestService
                .Setup(f => f.CalculateSimpleInterest(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new ArgumentException());

            var result = _controller.CalculateSimpleInterest(principal, rate, time) as BadRequestObjectResult;

            Assert.IsNotNull(result);
            _mocksimpleInterestService.Verify(f => f.CalculateSimpleInterest(principal, rate, time), Times.Once);
        }

        [TestMethod]
        public void CalculateCompoundInterest_ValidInput_ReturnCorrectResult()
        {
            // Arrange
            int principal = 1000;
            int rate = 5;
            int time = 2;
            int frequency = 4;

            double rateDecimal = (double)rate / 100;
            double expectedInterest = (double)principal *
                                      Math.Pow((1 + rateDecimal / frequency), frequency * time) -
                                      (double)principal;

            _mockcompoundInterestService
                .Setup(f => f.CalculateCompoundInterest(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(expectedInterest);

            // Act
            var result = _controller.CalculateCompoundInterest(principal, rate, time, frequency) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);

           

            Assert.AreEqual(expectedInterest, (double)result.Value!, 0.0001);

            _mockcompoundInterestService.Verify(f => f.CalculateCompoundInterest(principal, rate, time, frequency), Times.Once);
        }

        [TestMethod]
        [DataRow(0, 5, 2, 4)]
        [DataRow(1000, -5, 2, 4)]
        [DataRow(1000, 5, 0, 4)]
        [DataRow(1000, 5, 2, 0)]
        public void CalculateCompoundInterest_InvalidInput_RequestBadRequest(int principal, int rate, int time, int frequency)
        {
            _mockcompoundInterestService
                .Setup(f => f.CalculateCompoundInterest(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Throws(new ArgumentException());

            var result = _controller.CalculateCompoundInterest(principal, rate, time, frequency) as BadRequestObjectResult;

            Assert.IsNotNull(result);
            _mockcompoundInterestService.Verify(f => f.CalculateCompoundInterest(principal, rate, time, frequency), Times.Once);
        }
    }
}
