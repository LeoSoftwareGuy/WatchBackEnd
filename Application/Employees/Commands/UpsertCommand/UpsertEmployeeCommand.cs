using Application.Support.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employees.Commands.UpsertCommand
{
    public class UpsertEmployeeCommand : IRequest<int>
    {
        public int? Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string HomePhone { get; set; }

        public string Position { get; set; }

        public string Extension { get; set; }

        public byte[] Photo { get; set; }

        public int? ManagerId { get; set; }

        public class UpsertEmployeeCommandHandler : IRequestHandler<UpsertEmployeeCommand, int>
        {
            private readonly IWatchBackEndDBContext _context;

            public UpsertEmployeeCommandHandler(IWatchBackEndDBContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpsertEmployeeCommand request, CancellationToken cancellationToken)
            {
                Employee entity;

                if (request.Id.HasValue)
                {
                    entity = await _context.Employees.FindAsync(request.Id.Value);
                }
                else
                {
                    entity = new Employee();

                    _context.Employees.Add(entity);
                }
                entity.FirstName = request.FirstName;
                entity.LastName = request.LastName;
                entity.BirthDate = request.BirthDate;
                entity.Address = request.Address;
                entity.City = request.City;
                entity.Region = request.Region;
                entity.PostalCode = request.PostalCode;
                entity.Country = request.Country;
                entity.HomePhone = request.HomePhone;
                entity.Title = request.Position;
                entity.Extension = request.Extension;
                entity.Photo = request.Photo;
                entity.ReportsTo = request.ManagerId;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.EmployeeId;
            }
        }
    }
}
