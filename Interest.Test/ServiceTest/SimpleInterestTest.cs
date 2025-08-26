using Interest.Application.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Interest.Test.ServiceTest
{
    [TestClass]
    public class SimpleInterestTest
    {
        private SimpleInterest _simpleinterest = null!;

        [TestInitialize]
        public void Setup()
        {
            _simpleinterest = new SimpleInterest(); 
        }

        [TestMethod]
        public void CalculateSimpleInterest_WithValidInput_ReturnCorrectResult()
        {
            int principal = 1000;
            int rate = 5;
            int time = 2;
            double expected = (double)(principal * rate / 100 * time);

            double result = _simpleinterest.CalculateSimpleInterest(principal, rate, time);

            Assert.AreEqual(expected, result, 0.001, "The calculated simple interest is not correct.");
        }

        [TestMethod]
        [DataRow(0, 5, 2)]
        [DataRow(-1000, 5, 2)]
        public void CalculateSimpleInterest_WithZeroPrincipal_ThrowsArgumentException(int principal, int rate, int time)
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                _simpleinterest.CalculateSimpleInterest(principal, rate, time));
        }

        [TestMethod]
        public void CalculateSimpleInterest_WithNegativePrincipal_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                _simpleinterest.CalculateSimpleInterest(-1000, 5, 2));
        }

        

    }
}
