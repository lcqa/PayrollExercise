using PayrollExercise.Models.Models.Payroll;

namespace PayrollExercise.Models.UnitTests.Models.Payroll
{
    [TestClass]
    public class EmployeePayrollTests
    {
        PayrollDetails target;

        [TestInitialize]
        public void Setup()
        {
        }

        [TestCleanup]
        public void TearDown() 
        {
            this.target = null;
        }

        [TestMethod()]
        [DataRow(60050,9, 3, 5004.17)]
        [DataRow(120000, 10, 3, 10000.00)]
        public void EmployeePayroll_InitializeObject_GrossIncomeIsCorrect(double annualSalary, int super, int month, double expected)
        {
            this.target = new PayrollDetails( annualSalary, super, month);

            Assert.AreEqual(expected, this.target.GrossIncome);
        }

        [TestMethod]
        [DataRow(60050, 9, 3, 919.58)]
        [DataRow(120000, 10, 3, 2543.33)]
        public void EmployeePayroll_InitializeObject_IncomeTaxIsCorrect(double annualSalary, int super, int month, double expected)
        {
            this.target = new PayrollDetails(annualSalary, super, month);

            Assert.AreEqual(expected, this.target.IncomeTax);
        }

        [TestMethod]
        [DataRow(60050, 9, 3, 4084.59)]
        [DataRow(120000, 10, 3, 7456.67)]
        public void EmployeePayroll_InitializeObject_NetIncomeIsCorrect(double annualSalary, int super, int month, double expected)
        {
            this.target = new PayrollDetails(annualSalary, super, month);

            Assert.AreEqual(expected, this.target.NetIncome);
        }

        [TestMethod]
        [DataRow(60050, 9, 3, 450.38)]
        [DataRow(120000, 10, 3, 1000.00)]
        public void EmployeePayroll_InitializeObject_SuperIsCorrect(double annualSalary, int super, int month, double expected)
        {
            this.target = new PayrollDetails(annualSalary, super, month);

            Assert.AreEqual(expected, this.target.Super);
        }

        [TestMethod]
        [DataRow(60050, 9, 3, "01 March - 31 March")]
        public void EmployeePayroll_InitializeObject_PayPeriodIsCorrect(double annualSalary, int super, int month, string expected)
        {
            this.target = new PayrollDetails(annualSalary, super, month);

            Assert.AreEqual(expected, this.target.PayPeriod);
        }
    }
}
