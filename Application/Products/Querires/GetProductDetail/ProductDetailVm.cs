using Application.Support.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Products.Querires.GetProductDetail
{
    public class ProductDetailVm : IMapFrom<Product>
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? CategoryId { get; set; }

        public string CategoryName { get; set; }

        public bool Discontinued { get; set; }

        public bool EditEnabled { get; set; }

        public bool DeleteEnabled { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDetailVm>()
                .ForMember(d => d.EditEnabled, opt => opt.Ignore())
                .ForMember(d => d.DeleteEnabled, opt => opt.Ignore())
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category != null ? s.Category.CategoryName : string.Empty));
        }
    }
}

