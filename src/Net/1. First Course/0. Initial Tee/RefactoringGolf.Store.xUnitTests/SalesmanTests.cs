using Xunit;

namespace RefactoringGolf.Store.Tests
{
    public class SalesmanTests
    {
        [Fact]
        public void CalculateTheNetSalaryWhenFixedSalaryIsUnderTheMinimumTax()
        {
            int fixedSalary = 3000;
            Salesman salesman = CreateSalesman(fixedSalary);

            Assert.Equal(2700, salesman.NetSalary());
        }

        [Fact]
        public void CalculateTheNetSalaryWhenFixedSalaryIsOverTheMinimumTax()
        {
            int fixedSalary = 5000;
            Salesman salesman = CreateSalesman(fixedSalary);

            Assert.Equal(4250, salesman.NetSalary());
        }

        [Fact]
        public void CalculateTheNetSalaryWhenHaveMonthQuota()
        {
            int fixedSalary = 3000;
            Salesman salesman = CreateSalesman(fixedSalary);
            salesman.UpdateMonthQuota(1000);

            Assert.Equal(2800, salesman.NetSalary());
        }

        private Salesman CreateSalesman(int fixedSalary)
        {
            return new Salesman("Carlos", "Rodriguez", fixedSalary, 10);
        }
    }
}