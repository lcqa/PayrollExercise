using PayrollExercise.Models.Constants;
using PayrollExercise.Models.Messages.Request.Payroll;
using PayrollExercise.Services.Payroll.Specification.GetEmployeePayrollSpecification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollExercise.Services.Payroll.Tests.Specification.GetEmployeePayrollSpecification
{
    [TestClass]
    public class SuperRateWithinValidRangeTests
    {
        SuperRateWithinValidRange target;

        [TestInitialize]
        public void Setup()
        {
            target = new SuperRateWithinValidRange();
        }

        [TestCleanup]
        public void TearDown()
        {
            target = null;
        }

        [TestMethod]
        public void IsSatisfied_SuperRateIsGreaterThanRateFloorValue_ShouldReturnTrue()
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
        public void IsSatisfied_AnnualSalaryIsLessOrEqualThanFloorValue_ShouldReturnTrue()
        {
            var request = new GetEmployeePayrollRequest()
            {
                FirstName = "John",
                LastName = "Doe",
                AnnualSalary = 60050,
                PayPeriod = 3,
                SuperRate = RateConstants.SuperRateFloorValue - 1
            };
            var errorList = new List<string>();

            var result = target.IsSatisfied(request, errorList);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsSatisfied_SuperRateIsGreaterThanRateCeilingValue_ShouldReturnTrue()
        {
            var request = new GetEmployeePayrollRequest()
            {
                FirstName = "John",
                LastName = "Doe",
                AnnualSalary = 60050,
                PayPeriod = 3,
                SuperRate = RateConstants.SuperRateCeilingValue + 1
            };
            var errorList = new List<string>();

            var result = target.IsSatisfied(request, errorList);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsSatisfied_AnnualSalaryIsLessOrEqualThanCeilingValue_ShouldReturnTrue()
        {
            var request = new GetEmployeePayrollRequest()
            {
                FirstName = "John",
                LastName = "Doe",
                AnnualSalary = 60050,
                PayPeriod = 3,
                SuperRate = RateConstants.SuperRateCeilingValue - 1
            };
            var errorList = new List<string>();

            var result = target.IsSatisfied(request, errorList);

            Assert.IsTrue(result);
        }
    }
}
