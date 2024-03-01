using Application.Products.Querires.GetProductsFile;
using Application.Support.Interfaces;
using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace Infrastructurer.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildProductsFile(IEnumerable<ProductRecordDto> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
    }
}
