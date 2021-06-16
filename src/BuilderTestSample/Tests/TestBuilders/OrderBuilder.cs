using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
    /// <summary>
    /// Reference: https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
    /// </summary>
    public class OrderBuilder
    {
        private readonly Order _order = new();

        public OrderBuilder WithTestValues()
        {
            _order.Id = 0;
            _order.IsExpedited = false;
            _order.TotalAmount = 100.8m;
            _order.Customer = new Customer(1)
            {
                FirstName = "test first name",
                LastName = "test last name",
                HomeAddress = new Address()
                {
                    Street1 = "test street1",
                    Street2 = "test street2",
                    Street3 = "test street3",
                    City = "test city",
                    State = "test state",
                    PostalCode = "test postal code",
                    Country = "test country"
                },
                CreditRating = 1234,
                TotalPurchases = 10.5m
            };

            return this;
        }

        public OrderBuilder WithId(int id)
        {
            _order.Id = id;
            return this;
        }

        public OrderBuilder WithIsExpedited(bool isExpedited)
        {
            _order.IsExpedited = isExpedited;
            return this;
        }

        public OrderBuilder WithTotalAmount(decimal totalAmount)
        {
            _order.TotalAmount = totalAmount;
            return this;
        }

        public OrderBuilder WithCustomer(Customer customer)
        {
            _order.Customer = customer;
            return this;
        }

        public Order Build()
        {
            return _order;
        }
    }
}
