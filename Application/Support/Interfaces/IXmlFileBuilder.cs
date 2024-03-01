using Application.Products.Querires.GetProductsFile;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Application.Support.Interfaces
{
    public interface IXmlFileBuilder
    {
        XDocument BuildProductsFile(IEnumerable<ProductRecordDto> records);
    }
}
