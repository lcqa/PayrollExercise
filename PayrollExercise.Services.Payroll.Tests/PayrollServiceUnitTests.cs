using Moq;
using PayrollExercise.Infrastructure.Exceptions;
using PayrollExercise.Models.Messages.Request.Payroll;
using PayrollExercise.Services.Payroll.Specification.Base;
using PayrollExercise.Services.Payroll.Specification.Factory;
using System.Net;

namespace PayrollExercise.Services.Payroll.Tests
{
    [TestClass]
    public class PayrollServiceUnitTests
    {
        PayrollService target;
        Mock<IServiceSpecificationFactory> serviceSpecificationFactory;
        Mock<ISpecification<GetEmployeePayrollRequest>> getEmployeePayrollSpecification;
        ICollection<string> errorList;

        [TestInitialize]
        public void Setup()
        {
            errorList = new List<string>();
            getEmployeePayrollSpecification = new Mock<ISpecification<GetEmployeePayrollRequest>>();
            serviceSpecificationFactory = new Mock<IServiceSpecificationFactory>();
            target = new PayrollService(serviceSpecificationFactory.Object);

        }

        [TestCleanup]
        public void TearDown()
        {
            target = null;
            getEmployeePayrollSpecification = null;
            serviceSpecificationFactory = null;
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
            getEmployeePayrollSpecification.Setup(x => x.IsSatisfied(It.IsAny<GetEmployeePayrollRequest>(), It.IsAny<List<string>>())).Returns(true);
            serviceSpecificationFactory.Setup(x => x.GetEmployeePayrollRequestSpecification(It.IsAny<GetEmployeePayrollRequest>())).Returns(getEmployeePayrollSpecification.Object);

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

            var errorList = new List<string>() as ICollection<string>;
            getEmployeePayrollSpecification.Setup(x => x.IsSatisfied(It.IsAny<GetEmployeePayrollRequest>(), It.IsAny<List<string>>())).Returns(true);
            serviceSpecificationFactory.Setup(x => x.GetEmployeePayrollRequestSpecification(It.IsAny<GetEmployeePayrollRequest>())).Returns(getEmployeePayrollSpecification.Object);

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