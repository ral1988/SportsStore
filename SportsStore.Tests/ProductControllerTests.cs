using System.Collections.Generic;
using System.Linq;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using Xunit;

namespace SportsStore.Tests {

    public class ProductControllerTests 
    {
        [Fact]
        public void Can_Send_Pagination_View_Model() {
// Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            }).AsQueryable<Product>());
// Arrange
            ProductController controller =
                new ProductController(mock.Object) { PageSize = 3 };
// Act
            ProductsListViewModel result =
                controller.List(2).ViewData.Model as ProductsListViewModel;
// Assert
            PagingInfo pageInfo = result.PagingInfo;

        }
    }
}