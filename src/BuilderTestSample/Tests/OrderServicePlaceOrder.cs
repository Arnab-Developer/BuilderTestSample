# nullable disable

using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;
using BuilderTestSample.Services;
using BuilderTestSample.Tests.TestBuilders;
using Xunit;

namespace BuilderTestSample.Tests
{
    public class OrderServicePlaceOrder
    {
        private readonly OrderService _orderService = new();
        private readonly OrderBuilder _orderBuilder = new();
        private readonly CustomerBuilder _customerBuilder = new();
        private readonly AddressBuilder _addressBuilder = new();

        [Fact]
        public void ThrowsExceptionGivenOrderWithExistingId()
        {
            Order order = _orderBuilder
                .WithId(123)
                .Build();

            InvalidOrderException exception
                = Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("Order ID must be 0.", exception.Message);
        }

        [Fact]
        public void OrderAmountMustBeGreaterThanZero()
        {
            Order order = _orderBuilder
                .WithTotalAmount(99)
                .Build();

            InvalidOrderException exception
                = Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("order amount must be greater than zero.", exception.Message);
        }

        [Fact]
        public void OrderMustHaveACustomer()
        {
            Order order = _orderBuilder
                .WithCustomer(null)
                .Build();

            InvalidOrderException exception
                = Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("order must have a customer.", exception.Message);
        }

        [Fact]
        public void CustomerMustHaveAnIdGreaterThanZero1()
        {
            Customer customer = _customerBuilder
                .WithId(0)
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InvalidCustomerException exception
                = Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("customer must have an ID > 0.", exception.Message);
        }

        [Fact]
        public void CustomerMustHaveAnIdGreaterThanZero2()
        {
            Customer customer = _customerBuilder
                .WithId(-5)
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InvalidCustomerException exception
                = Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("customer must have an ID > 0.", exception.Message);
        }

        [Fact]
        public void CustomerMustHaveAnAddress()
        {
            Customer customer = _customerBuilder
                .WithHomeAddress(null)
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InvalidCustomerException exception
                = Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("customer must have an address.", exception.Message);
        }

        [Fact]
        public void CustomerMustHaveFirstName1()
        {
            Customer customer = _customerBuilder
                .WithFirstName(string.Empty)
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InvalidCustomerException exception
                = Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("customer must have a first name.", exception.Message);
        }

        [Fact]
        public void CustomerMustHaveFirstName2()
        {
            Customer customer = _customerBuilder
                .WithFirstName(" ")
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InvalidCustomerException exception
                = Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("customer must have a first name.", exception.Message);
        }

        [Fact]
        public void CustomerMustHaveLastName1()
        {
            Customer customer = _customerBuilder
                .WithLastName(string.Empty)
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InvalidCustomerException exception
                = Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("customer must have a last name.", exception.Message);
        }

        [Fact]
        public void CustomerMustHaveLastName2()
        {
            Customer customer = _customerBuilder
                .WithLastName(" ")
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InvalidCustomerException exception
                = Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("customer must have a last name.", exception.Message);
        }

        [Fact]
        public void CustomerMustHaveCreditRatingGreaterThan200()
        {
            Customer customer = _customerBuilder
                .WithCreditRating(200)
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InsufficientCreditException exception
                = Assert.Throws<InsufficientCreditException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("customer must have credit rating > 200.", exception.Message);
        }

        [Fact]
        public void CustomerMustHaveTotalPurchasesGreaterThanZero()
        {
            Customer customer = _customerBuilder
                .WithTotalPurchases(-1)
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InvalidCustomerException exception
                = Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("customer must have total purchases >= 0.", exception.Message);
        }

        [Fact]
        public void Street1IsRequired1()
        {
            Address address = _addressBuilder
                .WithStreet1(null)
                .Build();

            Customer customer = _customerBuilder
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InvalidAddressException exception
                = Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("street1 is required.", exception.Message);
        }

        [Fact]
        public void Street1IsRequired2()
        {
            Address address = _addressBuilder
                .WithStreet1(" ")
                .Build();

            Customer customer = _customerBuilder
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InvalidAddressException exception
                = Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("street1 is required.", exception.Message);
        }

        [Fact]
        public void CityIsRequired1()
        {
            Address address = _addressBuilder
                .WithCity(null)
                .Build();

            Customer customer = _customerBuilder
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InvalidAddressException exception
                = Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("city is required.", exception.Message);
        }

        [Fact]
        public void CityIsRequired2()
        {
            Address address = _addressBuilder
                .WithCity(" ")
                .Build();

            Customer customer = _customerBuilder
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InvalidAddressException exception
                = Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("city is required.", exception.Message);
        }

        [Fact]
        public void StateIsRequired1()
        {
            Address address = _addressBuilder
                .WithState(null)
                .Build();

            Customer customer = _customerBuilder
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InvalidAddressException exception
                = Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("state is required.", exception.Message);
        }

        [Fact]
        public void StateIsRequired2()
        {
            Address address = _addressBuilder
                .WithState(" ")
                .Build();

            Customer customer = _customerBuilder
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InvalidAddressException exception
                = Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("state is required.", exception.Message);
        }

        [Fact]
        public void PostalCodeIsRequired1()
        {
            Address address = _addressBuilder
                .WithPostalCode(null)
                .Build();

            Customer customer = _customerBuilder
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InvalidAddressException exception
                = Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("postal code is required.", exception.Message);
        }

        [Fact]
        public void PostalCodeIsRequired2()
        {
            Address address = _addressBuilder
                .WithPostalCode(" ")
                .Build();

            Customer customer = _customerBuilder
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InvalidAddressException exception
                = Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("postal code is required.", exception.Message);
        }

        [Fact]
        public void CountryIsRequired1()
        {
            Address address = _addressBuilder
                .WithCountry(null)
                .Build();

            Customer customer = _customerBuilder
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InvalidAddressException exception
                = Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("country is required.", exception.Message);
        }

        [Fact]
        public void CountryIsRequired2()
        {
            Address address = _addressBuilder
                .WithCountry(" ")
                .Build();

            Customer customer = _customerBuilder
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            InvalidAddressException exception
                = Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));

            Assert.Equal("country is required.", exception.Message);
        }

        [Fact]
        public void SetIsExpeditedToTrue()
        {
            Customer customer = _customerBuilder
                .WithTotalPurchases(5001)
                .WithCreditRating(501)
                .Build();

            Order order = _orderBuilder
                .WithCustomer(customer)
                .Build();

            _orderService.PlaceOrder(order);

            Assert.True(order.IsExpedited);
        }

        [Fact]
        public void CanAddOrderToCustomerHistorySetOrderHistory()
        {
            Customer customer = _customerBuilder
                .Build();

            Order order = _orderBuilder
                .WithTotalAmount(144.8m)
                .WithCustomer(customer)
                .Build();

            _orderService.PlaceOrder(order);

            Assert.Single(order.Customer!.OrderHistory);
            Assert.Equal(144.8m, order.Customer!.OrderHistory[0].TotalAmount);
        }
    }
}
