using Application.Products.Querires.GetProductsFile;
using Application.Support.Interfaces;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Infrastructurer.Files
{
    public class XmlFileBuilder : IXmlFileBuilder
    {
        public XDocument BuildProductsFile(IEnumerable<ProductRecordDto> records)
        {
            var ns = (XNamespace)"WatchBackEndService";  // to create name sapce in the xml file 
            var ex = (XNamespace)"WatchBackEndService/ex";  // to create another namespace 

            var document = new XDocument();  // create xml document
            var products = new XElement(ns + "Products");  // in document create parent node 


            foreach (var record in records) // foreach watch in watch files put its name, brand and price info as property
            {
                var watch = new XElement(ex + "Watch",      // so that all attributes will have ex at the begining of their name
                    new XAttribute("Name", record.Name),
                    new XAttribute("Brand", record.Category),
                    new XAttribute("Price", record.UnitPrice));

                products.Add(watch);
            }
            products.Add(new XAttribute(XNamespace.Xmlns + "ex", ex));   // adds name at the beging of Car attribute

            document.Add(products);
            document.Save("Watches.xml");
            return document;
        }
    }
}
