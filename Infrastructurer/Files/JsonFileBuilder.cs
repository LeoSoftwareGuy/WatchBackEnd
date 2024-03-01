using Application.Products.Querires.GetProductsFile;
using Application.Support.Interfaces;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Infrastructurer.Files
{
    public class JsonFileBuilder : IJsonFileBuilder
    {
        public string BuildProductsFile(IEnumerable<ProductRecordDto> records)
        {
            string data = JsonConvert.SerializeObject(records);
            return data;
        }
    }
}
