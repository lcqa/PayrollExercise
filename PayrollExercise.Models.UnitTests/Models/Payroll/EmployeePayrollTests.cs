using PayrollExercise.Models.Models.Payroll;

namespace PayrollExercise.Models.UnitTests.Models.Payroll
{
    [TestClass]
    public class EmployeePayrollTests
    {
        EmployeePayroll target;
        Employee employee;

        [TestInitialize]
        public void Setup()
        {
            this.employee = new Employee("John", "Smith");
        }

        [TestCleanup]
        public void TearDown() 
        {
            this.target = null;
        }

        [TestMethod()]
        [DataRow(60050,9, 5004.17)]
        [DataRow(120000, 10, 10000.00)]
        public void EmployeePayroll_InitializeObject_GrossIncomeIsCorrect(double annualSalary, int super, double expected)
        {
            this.target = new EmployeePayroll(employee, annualSalary, super);

            Assert.AreEqual(expected, this.target.GrossIncome);
        }

        [TestMethod]
        [DataRow(60050, 9, 919.58)]
        [DataRow(120000, 10, 2543.33)]
        public void EmployeePayroll_InitializeObject_IncomeTaxIsCorrect(double annualSalary, int super, double expected)
        {
            this.target = new EmployeePayroll(employee, annualSalary, super);

            Assert.AreEqual(expected, this.target.IncomeTax);
        }

        [TestMethod]
        [DataRow(60050, 9, 4084.59)]
        [DataRow(120000, 10, 7456.67)]
        public void EmployeePayroll_InitializeObject_NetIncomeIsCorrect(double annualSalary, int super, double expected)
        {
            this.target = new EmployeePayroll(employee, annualSalary, super);

            Assert.AreEqual(expected, this.target.NetIncome);
        }

        [TestMethod]
        [DataRow(60050, 9, 450.38)]
        [DataRow(120000, 10, 1000.00)]
        public void EmployeePayroll_InitializeObject_SuperIsCorrect(double annualSalary, int super, double expected)
        {
            this.target = new EmployeePayroll(employee, annualSalary, super);

            Assert.AreEqual(expected, this.target.Super);
        }
    }
}
