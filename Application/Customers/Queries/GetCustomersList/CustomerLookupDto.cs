using Application.Support.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Customers.Queries.GetCustomersList
{
    public class CustomerLookupDto : IMapFrom<Customer>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerLookupDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CustomerId));
        }
    }
}
