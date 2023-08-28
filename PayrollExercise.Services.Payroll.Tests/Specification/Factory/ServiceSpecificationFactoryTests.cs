using PayrollExercise.Services.Messages.Request.Payroll;
using PayrollExercise.Services.Specification.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollExercise.Services.Payroll.Tests.Specification.Factory
{
    [TestClass]
    public class ServiceSpecificationFactoryTests
    {
        ServiceSpecificationFactory target;

        [TestInitialize]
        public void Setup()
        {
            target = new ServiceSpecificationFactory();
        }

        [TestCleanup]
        public void TearDown()
        {
            target = null;
        }

        [TestMethod]
        public void GetEmployeePayrollRequestSpecification_RequestIsValid_ReturnsObject()
        {
            var request = new GetEmployeePayrollRequest()
            {
                FirstName = "John",
                LastName = "Doe",
                AnnualSalary = 60050,
                PayPeriod = 3,
                SuperRate = 9
            };

            var result = target.GetEmployeePayrollRequestSpecification(request);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetEmployeePayrollRequestSpecification_IsSatisfied_RequestIsValid_ReturnsTrue()
        {
            var request = new GetEmployeePayrollRequest()
            {
                FirstName = "John",
                LastName = "Doe",
                AnnualSalary = 60050,
                PayPeriod = 3,
                SuperRate = 9
            };
            var errorList = new List<string>();

            var specification = target.GetEmployeePayrollRequestSpecification(request);
            var result = specification.IsSatisfied(request, errorList);


            Assert.IsTrue(result);
        }
    }
}
