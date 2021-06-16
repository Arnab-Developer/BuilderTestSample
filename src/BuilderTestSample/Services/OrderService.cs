using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;

namespace BuilderTestSample.Services
{
    public class OrderService
    {
        public void PlaceOrder(Order order)
        {
            ValidateOrder(order);

            ExpediteOrder(order);

            AddOrderToCustomerHistory(order);
        }

        private void ValidateOrder(Order order)
        {
            if (order.Id != 0)
            {
                throw new InvalidOrderException("Order ID must be 0.");
            }
            if (order.TotalAmount < 100)
            {
                throw new InvalidOrderException("order amount must be greater than zero.");
            }
            if (order.Customer == null)
            {
                throw new InvalidOrderException("order must have a customer.");
            }
            ValidateCustomer(order.Customer);
        }

        private void ValidateCustomer(Customer customer)
        {
            if (customer.Id <= 0)
            {
                throw new InvalidCustomerException("customer must have an ID > 0.");
            }
            if (customer.HomeAddress == null)
            {
                throw new InvalidCustomerException("customer must have an address.");
            }
            if (string.IsNullOrWhiteSpace(customer.FirstName))
            {
                throw new InvalidCustomerException("customer must have a first name.");
            }
            if (string.IsNullOrWhiteSpace(customer.LastName))
            {
                throw new InvalidCustomerException("customer must have a last name.");
            }
            if (customer.CreditRating <= 200)
            {
                throw new InsufficientCreditException("customer must have credit rating > 200.");
            }
            if (customer.TotalPurchases < 0)
            {
                throw new InvalidCustomerException("customer must have total purchases >= 0.");
            }
            ValidateAddress(customer.HomeAddress);
        }

        private void ValidateAddress(Address homeAddress)
        {
            if (string.IsNullOrWhiteSpace(homeAddress.Street1))
            {
                throw new InvalidAddressException("street1 is required.");
            }
            if (string.IsNullOrWhiteSpace(homeAddress.City))
            {
                throw new InvalidAddressException("city is required.");
            }
            if (string.IsNullOrWhiteSpace(homeAddress.State))
            {
                throw new InvalidAddressException("state is required.");
            }
            if (string.IsNullOrWhiteSpace(homeAddress.PostalCode))
            {
                throw new InvalidAddressException("postal code is required.");
            }
            if (string.IsNullOrWhiteSpace(homeAddress.Country))
            {
                throw new InvalidAddressException("country is required.");
            }
        }

        private void ExpediteOrder(Order order)
        {
            if (order.Customer != null &&
                order.Customer.TotalPurchases > 5000 &&
                order.Customer.CreditRating > 500)
            {
                order.IsExpedited = true;
            }
        }

        private void AddOrderToCustomerHistory(Order order)
        {
            if (order.Customer == null)
            {
                return;
            }
            order.Customer.OrderHistory.Add(order);
        }
    }
}
