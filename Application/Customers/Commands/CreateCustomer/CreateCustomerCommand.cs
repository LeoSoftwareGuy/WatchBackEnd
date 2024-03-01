using Application.Support.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest
    {
        public string Id { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string PostalCode { get; set; }

        public string Region { get; set; }

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
        {
            private readonly IWatchBackEndDBContext _context;
            private readonly IMediator _mediator;

            public CreateCustomerCommandHandler(IWatchBackEndDBContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var entity = new Customer
                {
                    CustomerId = request.Id,
                    Address = request.Address,
                    City = request.City,
                    ContactName = request.ContactName,
                    ContactTitle = request.ContactTitle,
                    Country = request.Country,
                    Email = request.Email,
                    Phone = request.Phone,
                    PostalCode = request.PostalCode
                };

                _context.Customers.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new CustomerCreated { CustomerId = entity.CustomerId }, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
