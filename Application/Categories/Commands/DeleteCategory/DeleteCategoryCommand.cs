using Application.Support.Exceptions;
using Application.Support.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
        {
            private readonly IWatchBackEndDBContext _context;

            public DeleteCategoryCommandHandler(IWatchBackEndDBContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Categories.FindAsync(request.Id);

                if(entity == null)
                {
                    throw new NotFoundException(nameof(Category), request.Id);
                }

                _context.Categories.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;

            }
        }

    }
}
