﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using Payroll.API.Controllers;
using Payroll.API.WebModels;
using Payroll.Infrastructure.Interfaces;
using PayrollExercise.Models.Messages.Request.Payroll;
using PayrollExercise.Models.Messages.Response;
using PayrollExercise.Models.Models.Payroll;
using System.Net;

namespace Payroll.API.Tests.Controllers
{
    [TestClass]
    public class PayrollControllerTests
    {
        PayrollController target;
        Mock<IPayrollService> payrollService;

        [TestInitialize]
        public void Setup()
        {
            payrollService = new Mock<IPayrollService>();
            target = new PayrollController(payrollService.Object);
        }

        [TestCleanup]
        public void TearDown() 
        {
            payrollService = null;
            target = null;
        }

        [TestMethod]
        public async Task GetEmployeePayrollDetails_RequestIsValid_Returns200Response()
        {
            var request = new GetEmployeePayrollWebRequest()
            {
                FirstName = "John",
                LastName = "Doe",
                AnnualSalary = 60050,
                PayPeriod = 3,
                SuperRate = 9
            };

            var expectedResponse = new BaseResponse<Employee>()
            {
                Data = new Employee(request.FirstName, request.LastName),
                StatusCode = (int)HttpStatusCode.OK,
            };

            payrollService.Setup(p => p.GetEmployeePayroll(It.IsAny<GetEmployeePayrollRequest>())).ReturnsAsync(expectedResponse);
            var result = await target.GetPayrollDetails(request) as ObjectResult;

            Assert.AreEqual(expectedResponse.StatusCode, result.StatusCode);
        }

        [TestMethod]
        public async Task GetEmployeePayrollDetails_RequestIsInvalid_Returns400Response()
        {
            var request = new GetEmployeePayrollWebRequest()
            {
                AnnualSalary = 60050,
                PayPeriod = 3,
                SuperRate = 9
            };

            var expectedResponse = new BaseResponse<Employee>()
            {
                Data = new Employee(request.FirstName, request.LastName),
                StatusCode = (int)HttpStatusCode.BadRequest,
            };

            payrollService.Setup(p => p.GetEmployeePayroll(It.IsAny<GetEmployeePayrollRequest>())).ReturnsAsync(expectedResponse);
            var result = await target.GetPayrollDetails(request) as ObjectResult;

            Assert.AreEqual(expectedResponse.StatusCode, result.StatusCode);
        }
    }
}
