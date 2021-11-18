using Basket.API.Controllers;
using Basket.API.Entities;
using Basket.API.Infrastructure;
using Basket.API.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Basket.UnitTests.Application
{
    public class BasketControllerTest
    {
        private readonly Mock<IBasketRepository> _basketRepositoryMock;
        private readonly Mock<ILogger<BasketController>> _loggerMock;
        private readonly Mock<IDiscountgRPCService> _discountMock; 
        public BasketControllerTest()
        {
            _basketRepositoryMock = new Mock<IBasketRepository>();
            _loggerMock = new Mock<ILogger<BasketController>>();
            _discountMock = new Mock<IDiscountgRPCService>();
        }

        [Fact]
        public async Task get_basket_by_username_success()
        {
            //arrange
            var customerBasket = fakeCustomerBasket;

            _basketRepositoryMock.Setup(x => x.GetBasketAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(customerBasket));
            //act
            var controller = new BasketController(_basketRepositoryMock.Object, _loggerMock.Object, _discountMock.Object);

            var actionResult = await controller.GetBasketAsync(customerBasket.Username);

            var sut = actionResult.Result as OkObjectResult;
            //assert
            sut.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task get_basket_by_username_bad_request()
        {
            //arange
            var customerBasket = fakeCustomerBasket;
            customerBasket.Username = null;
            _basketRepositoryMock.Setup(x => x.GetBasketAsync(customerBasket.Username))
                .Returns(Task.FromResult(customerBasket));
            //act
            var controller = new BasketController(_basketRepositoryMock.Object, _loggerMock.Object, _discountMock.Object);

            var actionResult = await controller.GetBasketAsync(customerBasket.Username);

            var sut = actionResult.Result as BadRequestResult;
            //assert
            sut.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);

        }

        [Fact]
        public async Task update_basket_success()
        {
            //arange
            var customerBasket = fakeCustomerBasket;
            _discountMock.Setup(x => x.GetDiscount(It.IsAny<string>()))
                .Returns(Task.FromResult(fakeCouponModel));
            //act
            var controller = new BasketController(_basketRepositoryMock.Object, _loggerMock.Object, _discountMock.Object);

            var actionResult = await controller.UpdateBasketAsync(customerBasket);

            var sut = actionResult as OkObjectResult;
            //assert
            sut.StatusCode.Should().Be((int)HttpStatusCode.OK);

        }

        [Fact]
        public async Task delete_basket_success()
        {
            //arange
            var customerBasket = fakeCustomerBasket;

            //act
            var controller = new BasketController(_basketRepositoryMock.Object, _loggerMock.Object, _discountMock.Object);

            var actionResult = await controller.DeleteBasketAsync(customerBasket.Username);

            var sut = actionResult as OkResult;
            //assert
            sut.StatusCode.Should().Be((int)HttpStatusCode.OK);

        }

        [Fact]
        public async Task delete_basket_bad_request()
        {
            //arange
            var customerBasket = fakeCustomerBasket;
            customerBasket.Username = null;
            //act
            var controller = new BasketController(_basketRepositoryMock.Object, _loggerMock.Object, _discountMock.Object);

            var actionResult = await controller.DeleteBasketAsync(customerBasket.Username);

            var sut = actionResult as BadRequestResult;
            //assert
            sut.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);

        }
        private string fakeUser => "fakeUser";

        private BasketItem fakeBasketItem => new() { ProductId = "2wq3-xz", ProductName = "fakePhone", Color = "Red", Price = 899.99M, Quantity = 1 };
        private CustomerBasket fakeCustomerBasket => new(fakeUser)
        {
            Items = new() { fakeBasketItem },
            Username = fakeUser
        };

        private Discount.gRPC.Protos.CouponModel fakeCouponModel => new() { Id = 99, Amount = 100, Description = "fake discount", ProductName = "fakePhone" };
    }
}
