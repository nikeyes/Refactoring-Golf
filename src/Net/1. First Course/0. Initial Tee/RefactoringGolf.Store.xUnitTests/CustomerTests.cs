using Xunit;
using RefactoringGolf.Store;

namespace RefactoringGolf.Store.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void FormatThePhoneNumber()
        {
            Customer customer = new Customer("Alberto", "Paez", "54115678654");

            string formattedPhone = customer.FormatPhone();

            Assert.Equal("CountryCode:54 - Citycode:11 - LocalNumber:5678654", formattedPhone);
        }
    }
}