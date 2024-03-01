using Application.Support.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Customers.Queries.GetCustomerDetail
{
    public class CustomerDetailVm : IMapFrom<Customer>
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerDetailVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CustomerId));
        }
    }
}
