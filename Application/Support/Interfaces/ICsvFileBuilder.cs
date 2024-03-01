using Application.Products.Querires.GetProductsFile;
using System.Collections.Generic;

namespace Application.Support.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildProductsFile(IEnumerable<ProductRecordDto> records);
    }
}
