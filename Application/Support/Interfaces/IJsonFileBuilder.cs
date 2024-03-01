using Application.Products.Querires.GetProductsFile;
using System.Collections.Generic;

namespace Application.Support.Interfaces
{
    public interface IJsonFileBuilder
    {
       string BuildProductsFile(IEnumerable<ProductRecordDto> records);
    }
}
