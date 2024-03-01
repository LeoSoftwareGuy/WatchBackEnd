using Application.Support.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Categories.Queries.GetCategoryList
{
    public class GetCategoyListQueryHandler : IRequestHandler<GetCategoryListQuery,CategoriesListVm>
    {
        private readonly IWatchBackEndDBContext _context;
        private readonly IMapper _mapper;

        public GetCategoyListQueryHandler(IWatchBackEndDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoriesListVm> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new CategoriesListVm
            {
                Categories = categories,
                Count = categories.Count
            };

            return vm;
        }
    }
}
