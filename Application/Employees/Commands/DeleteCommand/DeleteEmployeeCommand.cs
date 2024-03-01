using Application.Support.Exceptions;
using Application.Support.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employees.Commands.DeleteCommand
{
    public class DeleteEmployeeCommand : IRequest
    {
        public int Id { get; set; }
        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
        {
            private readonly IUserManager _userManager;
            private readonly IWatchBackEndDBContext _context;
            private readonly ICurrentUserService _currentUser;

            public DeleteEmployeeCommandHandler(IUserManager userManager, IWatchBackEndDBContext context, ICurrentUserService currentUser)
            {
                _userManager = userManager;
                _context = context;
                _currentUser = currentUser; 
            }

            public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Employees.FindAsync(request.Id);
                if (entity == null)
                    throw new NotFoundException(nameof(Employee), request.Id);
                if (entity.UserId == _currentUser.UserId)
                    throw new BadRequestException("Employees cannot delete their own account.");
                if (entity.UserId != null)
                    await _userManager.DeleteUserAsync(entity.UserId);

                _context.Employees.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;

            }
        }

    }

}
