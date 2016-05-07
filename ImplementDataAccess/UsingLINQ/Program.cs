using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using UsingLINQ.Models;

namespace UsingLINQ
{
    #region Example 4-59 A sample Order class for LINQ queries

    //public class Product
    //{
    //    public string Description { get; set; }
    //    public decimal Price { get; set; }
    //}

    //public class OrderLine
    //{
    //    public int Amount { get; set; }
    //    public Product Product { get; set; }
    //}

    //public class Order
    //{
    //    public List<OrderLine> OrderLines { get; set; }
    //}

    #endregion Example 4-59 A sample Order class for LINQ queries

    #region Example 4-63 Implementing Where

    //public static class LinqExtensions
    //{
    //    public static IEnumerable<TSource> Where<TSource>(
    //        this IEnumerable<TSource> source,
    //        Func<TSource, bool> predicate)
    //    {
    //        foreach (TSource item in source)
    //        {
    //            if (predicate(item))
    //            {
    //                yield return item;
    //            }
    //        }
    //    }
    //}

    #endregion Example 4-63 Implementing Where

    class Program
    {
        static void Main(string[] args)
        {
            #region Example 4-54 A LINQ select query

            //int[] data = { 1, 2, 5, 8, 11 };

            //var result = from d in data
            //             where d % 2 == 0
            //             select d;

            //foreach (int i in result)
            //{
            //    Console.WriteLine(i);
            //}

            #endregion Example 4-54 A LINQ select query

            #region Example 4-55 LINQ Select operator

            //var result = from d in data
            //             select d;

            //Console.WriteLine(string.Join(", ", result));

            #endregion Example 4-55 LINQ Select operator

            #region Example 4-56 LINQ where operator

            //var result = from d in data
            //             where d > 5
            //             select d;

            //Console.WriteLine(string.Join(", ", result));

            #endregion Example 4-56 LINQ where operator

            #region Example 4-57 LINQ orderby operator

            //var result = from d in data
            //             where d > 5
            //             orderby d descending
            //             select d;

            //Console.WriteLine(string.Join(", ", result));

            #endregion Example 4-57 LINQ orderby operator

            #region Example 4-58 LINQ multiple from statements

            //int[] data1 = { 1, 2, 5 };
            //int[] data2 = { 2, 4, 6 };

            //var result = from d1 in data1
            //             from d2 in data2
            //             select d1 * d2;

            //Console.WriteLine(string.Join(", ", result));

            #endregion Example 4-58 LINQ multiple from statements

            #region Example 4-60 Using group by and projection

            //AdventureWorksEntities db = new AdventureWorksEntities("3jNVz27d");

            //var result = from soh in db.SalesOrderHeaders
            //             from sod in db.SalesOrderDetails
            //             group sod by sod.ProductID into p
            //             join prod in db.Products on p.Key equals prod.ProductID
            //             select new
            //             {
            //                 ProductName = prod.Name,
            //                 OrderQty = p.Sum(x => x.OrderQty)
            //             };

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Product: {item.ProductName} Quantity: {item.OrderQty}");
            //}

            #endregion Example 4-60 Using group by and projection

            #region Example 4-61 Using join

            //var products = from p in db.Products
            //               join sod in db.SalesOrderDetails on p.ProductID equals sod.ProductID
            //               select p;

            //foreach (var item in products)
            //{
            //    Console.WriteLine(item.Name);
            //}

            #endregion Example 4-61 Using join

            #region Example 4-62 Using Skip and Take to implement paging

            //var pagedResult = result.Skip(1).Take(1);

            #endregion Example 4-62 Using Skip and Take to implement paging

            #region Example 4-65 Querying some XML by using LINQ to XML

            StringWriter stream = new StringWriter();

            using (XmlWriter writer = XmlWriter.Create(
                stream, new XmlWriterSettings()
                {
                    Indent = true,
                }))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("people");
                writer.WriteStartElement("person");
                writer.WriteAttributeString("firstname", "john");
                writer.WriteAttributeString("lastname", "doe");
                writer.WriteStartElement("contactdetails");
                writer.WriteElementString("emailaddress", "john@unknown.com");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteStartElement("person");
                writer.WriteAttributeString("firstname", "jane");
                writer.WriteAttributeString("lastname", "doe");
                writer.WriteStartElement("contactdetails");
                writer.WriteElementString("emailaddress", "jane@unknown.com");
                writer.WriteElementString("phonenumber", "001122334455");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
            }

            string xml = stream.ToString();

            //XDocument doc = XDocument.Parse(xml);
            //var personNames = from p in doc.Descendants("person")
            //                  select $"{(string)p.Attribute("firstname")} {(string)p.Attribute("lastname")}";

            //foreach (var item in personNames)
            //{
            //    Console.WriteLine(item);
            //}

            //string path = @"C:\Users\rombo84fx\Downloads\Sandy Geraldine Barón Miranda.xml";

            //XElement xml = XElement.Load(path);

            //XNamespace my = xml.GetNamespaceOfPrefix("my");

            //var informacionGeneral = from el in xml.Elements(my + "InformacionGeneral")
            //                         select el;

            //foreach (var item in informacionGeneral)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion Example 4-65 Querying some XML by using LINQ to XML

            #region Example 4-66 Using Where and OrderBy in a LINQ to XML query

            //XDocument doc = XDocument.Parse(xml);
            //var personNames = from p in doc.Descendants("person")
            //                  where p.Descendants("phonenumber").Any()
            //                  let name = $"{(string)p.Attribute("firstname")} {(string)p.Attribute("lastname")}"
            //                  orderby name
            //                  select name;

            //foreach (var item in personNames)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion Example 4-66 Using Where and OrderBy in a LINQ to XML query

            #region Example 4-67 Creating XML with the XElement class

            //XElement root = new XElement("Root",
            //    new List<XElement>
            //    {
            //        new XElement("Child1"),
            //        new XElement("Child2"),
            //        new XElement("Child3")
            //    },
            //    new XAttribute("MyAttribute", 42));
            //root.Save("test.xml");

            #endregion Example 4-67 Creating XML with the XElement class

            #region Example 4-68 Updating XML in a procedural way

            //XElement root = XElement.Parse(xml);

            //foreach (XElement p in root.Descendants("person"))
            //{
            //    string name = $"{(string)p.Attribute("firstname")} {(string)p.Attribute("lastname")}";
            //    p.Add(new XAttribute("IsMale", name.Contains("john")));
            //    XElement contactDetails = p.Element("contactdetails");
            //    if (!contactDetails.Descendants("phonenumber").Any())
            //    {
            //        contactDetails.Add(new XElement("phonenumber", "001122334455"));
            //    }
            //}

            //Console.WriteLine(root.ToString());

            #endregion Example 4-68 Updating XML in a procedural way

            #region Example 4-69 Transforming XML with functional creation

            //XElement root = XElement.Parse(xml);

            //XElement newTree = new XElement("people",
            //    from p in root.Descendants("person")
            //    let name = $"{(string)p.Attribute("firstname")} {(string)p.Attribute("lastname")}"
            //    let contactDetails = p.Element("contactdetails")
            //    select new XElement("person",
            //        new XAttribute("IsMale", name.Contains("john")),
            //        p.Attributes(),
            //        new XElement("contactdetails",
            //            contactDetails.Element("emailaddress"),
            //            contactDetails.Element("phonenumber")
            //            ?? new XElement("phonenumber", "1122334455")
            //            )));

            //Console.WriteLine(newTree.ToString());

            #endregion Example 4-69 Transforming XML with functional creation
        }
    }
}
