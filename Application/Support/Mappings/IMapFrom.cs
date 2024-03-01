using AutoMapper;

namespace Application.Support.Mappings
{
    public interface IMapFrom<T>
    {
        // What allows us to do, is by using new C#8.0 features (default interface implementation)
        // It allows us to do this  .ProjectTo<ProductDetailVm>(_mapper.ConfigurationProvider)
        // So dto will be created on the fly
        // Or we can do nested mapping
        //   public class ProductDetailVm : IMapFrom<Product>
        //  public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<Product, ProductRecordDto>()
        //        .ForMember(d => d.Name, opt => opt.MapFrom(s => s.ProductName))
        //        .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category != null ? s.Category.CategoryName : string.Empty));
        //}
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
