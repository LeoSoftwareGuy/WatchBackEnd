using MediatR;

namespace Application.Products.Querires.GetProductsList
{
    public class GetProductsListQuery : IRequest<ProductsListVm>
    {
    }
}
