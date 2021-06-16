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
                .WithTestValues()
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
                .WithTestValues()
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
                .WithTestValues()
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
                .WithTestValues()
                .WithId(0)
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithId(-5)
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithHomeAddress(null)
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithFirstName(string.Empty)
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithFirstName(" ")
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithLastName(string.Empty)
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithLastName(" ")
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithCreditRating(200)
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithTotalPurchases(-1)
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithStreet1(null)
                .Build();

            Customer customer = _customerBuilder
                .WithTestValues()
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithStreet1(" ")
                .Build();

            Customer customer = _customerBuilder
                .WithTestValues()
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithCity(null)
                .Build();

            Customer customer = _customerBuilder
                .WithTestValues()
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithCity(" ")
                .Build();

            Customer customer = _customerBuilder
                .WithTestValues()
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithState(null)
                .Build();

            Customer customer = _customerBuilder
                .WithTestValues()
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithState(" ")
                .Build();

            Customer customer = _customerBuilder
                .WithTestValues()
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithPostalCode(null)
                .Build();

            Customer customer = _customerBuilder
                .WithTestValues()
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithPostalCode(" ")
                .Build();

            Customer customer = _customerBuilder
                .WithTestValues()
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithCountry(null)
                .Build();

            Customer customer = _customerBuilder
                .WithTestValues()
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithCountry(" ")
                .Build();

            Customer customer = _customerBuilder
                .WithTestValues()
                .WithHomeAddress(address)
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
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
                .WithTestValues()
                .WithTotalPurchases(5001)
                .WithCreditRating(501)
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
                .WithCustomer(customer)
                .Build();

            _orderService.PlaceOrder(order);

            Assert.True(order.IsExpedited);
        }

        [Fact]
        public void CanAddOrderToCustomerHistorySetOrderHistory()
        {
            Customer customer = _customerBuilder
                .WithTestValues()
                .Build();

            Order order = _orderBuilder
                .WithTestValues()
                .WithTotalAmount(144.8m)
                .WithCustomer(customer)
                .Build();

            _orderService.PlaceOrder(order);

            Assert.Single(order.Customer!.OrderHistory);
            Assert.Equal(144.8m, order.Customer!.OrderHistory[0].TotalAmount);
        }
    }
}
