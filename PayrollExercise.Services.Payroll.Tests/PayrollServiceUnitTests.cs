using PayrollExercise.Infrastructure.Exceptions;
using PayrollExercise.Models.Messages.Request.Payroll;
using System.Net;

namespace PayrollExercise.Services.Payroll.Tests
{
    [TestClass]
    public class PayrollServiceUnitTests
    {
        PayrollService target;

        [TestInitialize]
        public void Setup()
        {
            target = new PayrollService();
        }

        [TestCleanup]
        public void TearDown()
        {
            target = null;
        }

        [TestMethod]
        public async Task GetEmployeePayroll_RequestIsValid_ReturnsEmployeeData()
        {
            var request = new GetEmployeePayrollRequest()
            {
                FirstName = "John",
                LastName = "Doe",
                AnnualSalary = 60050,
                PayPeriod = 3,
                SuperRate = 9
            };

            var result = await target.GetEmployeePayroll(request);

            Assert.AreEqual(request.FirstName, result.Data.FirstName);
        }

        [TestMethod]
        public async Task GetEmployeePayroll_RequestIsValid_ReturnsStatusCode200()
        {
            var request = new GetEmployeePayrollRequest()
            {
                FirstName = "John",
                LastName = "Doe",
                AnnualSalary = 60050,
                PayPeriod = 3,
                SuperRate = 9
            };

            var result = await target.GetEmployeePayroll(request);

            Assert.AreEqual((int)HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        [ExpectedException(typeof(PayrollServiceException))]
        public async Task GetEmployeePayroll_PayPeriodIsInvalid_ThrowsException()
        {
            var request = new GetEmployeePayrollRequest()
            {
                FirstName = "John",
                LastName = "Doe",
                AnnualSalary = 60050,
                PayPeriod = 30,
                SuperRate = 9
            };

            var result = await target.GetEmployeePayroll(request);
        }
    }
}