using System.Collections.Generic;

namespace Application.Customers.Queries.GetCustomersList
{
    public class CustomerListVm
    {
        public IList<CustomerLookupDto> Customers { get; set; }
    }
}
