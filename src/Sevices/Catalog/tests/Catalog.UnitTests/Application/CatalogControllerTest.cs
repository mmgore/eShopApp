using Catalog.API.Controllers;
using Catalog.API.Entities;
using Catalog.API.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Catalog.UnitTests.Application
{
    public class CatalogControllerTest
    {
        private readonly Mock<ICatalogRepository> _catalogRepositoryMock;
        private readonly Mock<ILogger<CatalogController>> _loggerMock;

        public CatalogControllerTest()
        {
            _catalogRepositoryMock = new Mock<ICatalogRepository>();
            _loggerMock = new Mock<ILogger<CatalogController>>();
        }
        [Fact]
        public async Task get_calalog_by_id_success()
        {
            //arrange
            var catalogItem = fakeCatalogItem;

            _catalogRepositoryMock.Setup(x => x.GetCatalogById(It.IsAny<string>()))
                .Returns(Task.FromResult(catalogItem));
            //act
            var controller = new CatalogController(_catalogRepositoryMock.Object, _loggerMock.Object);

            var actionResult = await controller.GetProductById(catalogItem.Id);

            var sut = actionResult.Result as OkObjectResult;
            //assert
            sut.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task get_catalog_by_id_bad_request()
        {
            //arange
            var catalogItem = fakeCatalogItem;
            catalogItem.Id = null;
            _catalogRepositoryMock.Setup(x => x.GetCatalogById("123"))
                .Returns(Task.FromResult(catalogItem));
            //act
            var controller = new CatalogController(_catalogRepositoryMock.Object, _loggerMock.Object);

            var actionResult = await controller.GetProductById(catalogItem.Id);

            var sut = actionResult.Result as BadRequestResult;
            //assert
            sut.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);

        }

        [Fact]
        public async Task get_catalog_by_id_not_found()
        {
            //arange
            var catalogItem = fakeCatalogItem;

            _catalogRepositoryMock.Setup(x => x.GetCatalogById("123"))
                .Returns(Task.FromResult(catalogItem));
            //act
            var controller = new CatalogController(_catalogRepositoryMock.Object, _loggerMock.Object);

            var actionResult = await controller.GetProductById(catalogItem.Id);

            var sut = actionResult.Result as NotFoundResult;
            //assert
            sut.StatusCode.Should().Be((int)HttpStatusCode.NotFound);

        }

        [Fact]
        public async Task create_catalog_success()
        {
            //arange
            var catalogItem = fakeCatalogItem;

            //act
            var controller = new CatalogController(_catalogRepositoryMock.Object, _loggerMock.Object);

            var actionResult = await controller.CreateProductAsync(catalogItem);

            var sut = actionResult as CreatedAtRouteResult;
            //assert
            sut.StatusCode.Should().Be((int)HttpStatusCode.Created);

        }

        private CatalogItem fakeCatalogItem => new()
        {
            Category = "Phone",
            Description = "Fake Phone",
            Id = "23Qxy-411",
            ImageFile = "phone.png",
            Name = "FPhone 11",
            Price = 999,
            Summary = "fake summary!!"
        };
    }
}
