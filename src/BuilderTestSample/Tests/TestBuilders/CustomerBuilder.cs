using BuilderTestSample.Model;
using System.Collections.Generic;

namespace BuilderTestSample.Tests.TestBuilders
{
    public class CustomerBuilder
    {
        public int _id;
        public string _firstName;
        public string _lastName;
        public Address _homeAddress;
        public int _creditRating;
        public decimal _totalPurchases;
        public List<Order>? _orderHistory;

        public CustomerBuilder()
        {
            _id = 1;
            _firstName = "test first name";
            _lastName = "test last name";
            _creditRating = 1234;
            _totalPurchases = 10.5m;
            _homeAddress = new Address()
            {
                Street1 = "test street1",
                Street2 = "test street2",
                Street3 = "test street3",
                City = "test city",
                State = "test state",
                PostalCode = "test postal code",
                Country = "test country"
            };
        }

        public CustomerBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public CustomerBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public CustomerBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public CustomerBuilder WithCreditRating(int creditRating)
        {
            _creditRating = creditRating;
            return this;
        }

        public CustomerBuilder WithTotalPurchases(decimal totalPurchases)
        {
            _totalPurchases = totalPurchases;
            return this;
        }

        public CustomerBuilder WithHomeAddress(Address homeAddress)
        {
            _homeAddress = homeAddress;
            return this;
        }

        public Customer Build()
        {
            Customer customer = new(_id)
            {
                FirstName = _firstName,
                LastName = _lastName,
                HomeAddress = _homeAddress,
                CreditRating = _creditRating,
                TotalPurchases = _totalPurchases
            };
            return customer;
        }
    }
}
