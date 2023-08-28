using PayrollExercise.Services.Messages.Request.Payroll;
using PayrollExercise.Services.Specification.GetEmployeePayrollSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollExercise.Services.Payroll.Tests.Specification.GetEmployeePayrollSpecification
{
    [TestClass]
    public class AnnualSalaryIsPositiveSpecificationTests
    {
        AnnualSalaryIsPositiveSpecification target;

        [TestInitialize]
        public void Setup()
        {
            target = new AnnualSalaryIsPositiveSpecification();
        }

        [TestCleanup]
        public void TearDown() 
        {
            target = null;
        }

        [TestMethod]
        public void IsSatisfied_AnnualSalaryIsGreaterThanZero_ShouldReturnTrue()
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

            var result = target.IsSatisfied(request, errorList);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsSatisfied_AnnualSalaryIsLessOrEqualThanZero_ShouldReturnFalse()
        {
            var request = new GetEmployeePayrollRequest()
            {
                FirstName = "John",
                LastName = "Doe",
                AnnualSalary = -1,
                PayPeriod = 3,
                SuperRate = 9
            };
            var errorList = new List<string>();

            var result = target.IsSatisfied(request, errorList);

            Assert.IsFalse(result);
        }
    }
}
