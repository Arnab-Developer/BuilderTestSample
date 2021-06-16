using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
    public class AddressBuilder
    {
        private readonly Address _address = new();

        public AddressBuilder WithTestValues()
        {
            _address.Street1 = "test street1";
            _address.Street2 = "test street2";
            _address.Street3 = "test street3";
            _address.City = "test city";
            _address.State = "test state";
            _address.PostalCode = "test postal code";
            _address.Country = "test country";

            return this;
        }

        public AddressBuilder WithStreet1(string street1)
        {
            _address.Street1 = street1;
            return this;
        }

        public AddressBuilder WithStreet2(string street2)
        {
            _address.Street2 = street2;
            return this;
        }

        public AddressBuilder WithStreet3(string street3)
        {
            _address.Street3 = street3;
            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            _address.City = city;
            return this;
        }

        public AddressBuilder WithState(string state)
        {
            _address.State = state;
            return this;
        }

        public AddressBuilder WithPostalCode(string postalCode)
        {
            _address.PostalCode = postalCode;
            return this;
        }

        public AddressBuilder WithCountry(string country)
        {
            _address.Country = country;
            return this;
        }

        public Address Build()
        {
            return _address;
        }
    }
}
