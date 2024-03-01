using MediatR;

namespace Application.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IRequest<CategoriesListVm>
    {
    }
}
