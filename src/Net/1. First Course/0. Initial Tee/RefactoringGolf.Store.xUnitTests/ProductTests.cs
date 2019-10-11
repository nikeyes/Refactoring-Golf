using Xunit;

namespace RefactoringGolf.Store.Tests
{
    public class ProductTests
    {
        [Fact]
        public void ProductImageReturnTheType()
        {
            ImageInfo imageInfo = new ImageInfo("Bike01.jpg");

            string type = imageInfo.ImageType;

            Assert.Equal("jpg", type);
        }

        [Fact]
        public void SerializeToXml()
        {
            Product product = CreateProduct();

            string xml = product.ToXml();

            Assert.Equal("<product><name>Black Bike</name><category>Bikes</category></product>", xml);
        }

        private Product CreateProduct()
        {
            return new Product("Black Bike", 250, ProductCategory.Bikes, new ImageInfo("Bike01.jpg"));
        }
    }
}