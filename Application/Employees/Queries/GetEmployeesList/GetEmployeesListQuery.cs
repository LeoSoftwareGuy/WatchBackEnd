using Application.Support.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQuery : IRequest<EmployeesListVm>
    {
        public class GetEmployeesListQueryHandler : IRequestHandler<GetEmployeesListQuery,EmployeesListVm>
        {
            private readonly IWatchBackEndDBContext _context;
            private readonly IMapper _mapper;

            public GetEmployeesListQueryHandler(IWatchBackEndDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<EmployeesListVm> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
            {
                var employees = await _context.Employees
                    .ProjectTo<EmployeeLookupDto>(_mapper.ConfigurationProvider)
                    .OrderBy(e => e.Name)
                    .ToListAsync(cancellationToken);

                var vm = new EmployeesListVm
                {
                    Employees = employees
                };

                return vm;
            }
        }
    }
}
