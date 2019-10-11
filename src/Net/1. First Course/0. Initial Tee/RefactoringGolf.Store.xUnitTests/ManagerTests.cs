using Xunit;

namespace RefactoringGolf.Store.Tests
{
    public class ManagerTests
    {
        [Fact]
        public void CalculateTheNetSalaryWhenFixedSalaryIsUnderTheMinimumTax()
        {
            int fixedSalary = 3000;
            Manager manager = CreateManager(fixedSalary);

            Assert.Equal(2700, manager.SalaryAfterAdditionsAndDeductions());
        }

        [Fact]
        public void CalculateTheNetSalaryWhenFixedSalaryIsOverTheMinimumTax()
        {
            int fixedSalary = 5000;
            Manager manager = CreateManager(fixedSalary);

            Assert.Equal(4250, manager.SalaryAfterAdditionsAndDeductions());
        }

        [Fact]
        public void CalculateTheNetSalaryWhenBenefits()
        {
            int fixedSalary = 3000;
            Manager manager = CreateManager(fixedSalary);
            manager.AddSubordinate(CreateSubordinate());

            Assert.Equal(2720, manager.SalaryAfterAdditionsAndDeductions());
        }

        private Manager CreateManager(int fixedSalary)
        {
            return new Manager("Carlos", "Rodriguez", fixedSalary);
        }

        private Salesman CreateSubordinate()
        {
            return new Salesman("Miguel", "Gonzales", 2000, 2);
        }
    }
}