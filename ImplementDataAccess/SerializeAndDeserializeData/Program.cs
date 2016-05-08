using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SerializeAndDeserializeData
{
    #region Example 4-71 Using the XML attributes to configure serialization

    //[Serializable]
    //public class Person
    //{
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public int Age { get; set; }
    //}

    //[Serializable]
    //public class Order
    //{
    //    [XmlAttribute]
    //    public int ID { get; set; }

    //    [XmlIgnore]
    //    public bool IsDirty { get; set; }

    //    [XmlArray("Lines")]
    //    [XmlArrayItem("OrderLine")]
    //    public List<OrderLine> OrderLines { get; set; }
    //}

    //[Serializable]
    //public class VIPOrder : Order
    //{
    //    public string Description { get; set; }
    //}

    //[Serializable]
    //public class OrderLine
    //{
    //    [XmlAttribute]
    //    public int ID { get; set; }

    //    [XmlAttribute]
    //    public int Amount { get; set; }

    //    [XmlElement("OrderedProduct")]
    //    public Product Product { get; set; }
    //}

    //[Serializable]
    //public class Product
    //{
    //    [XmlAttribute]
    //    public int ID { get; set; }
    //    public decimal Price { get; set; }
    //    public string Description { get; set; }
    //}

    #endregion Example 4-71 Using the XML attributes to configure serialization

    #region Example 4-70 Serializing an object with the XmlSerializer

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Person));
    //        string xml;
    //        using (StringWriter stringWriter = new StringWriter())
    //        {
    //            Person p = new Person()
    //            {
    //                FirstName = "John",
    //                LastName = "Doe",
    //                Age = 42
    //            };
    //            serializer.Serialize(stringWriter, p);
    //            xml = stringWriter.ToString();
    //        }

    //        Console.WriteLine(xml);

    //        using (StringReader stringReader = new StringReader(xml))
    //        {
    //            Person p = (Person)serializer.Deserialize(stringReader);
    //            Console.WriteLine($"{p.FirstName} {p.LastName} is {p.Age} years old");
    //        }
    //    }
    //}

    #endregion Example 4-70 Serializing an object with the XmlSerializer

    #region Example 4-72 Serializing a derived, complex class to XML

    //class Program
    //{
    //    private static Order CreateOrder()
    //    {
    //        Product p1 = new Product { ID = 1, Description = "p2", Price = 9 };
    //        Product p2 = new Product { ID = 6, Description = "p3", Price = 6 };

    //        Order order = new VIPOrder
    //        {
    //            ID = 4,
    //            Description = "Order for John Doe. Use the nice giftwrap",
    //            OrderLines = new List<OrderLine>
    //            {
    //                new OrderLine { ID = 5, Amount = 1, Product = p1 },
    //                new OrderLine { ID = 6, Amount = 10, Product = p2 }
    //            }
    //        };
    //        return order;
    //    }

    //    static void Main(string[] args)
    //    {
    //        XmlSerializer serializer = new XmlSerializer(typeof(Order),
    //        new Type[] { typeof(VIPOrder) });
    //        string xml;

    //        using (StringWriter stringWriter = new StringWriter())
    //        {
    //            Order order = CreateOrder();
    //            serializer.Serialize(stringWriter, order);
    //            xml = stringWriter.ToString();
    //            Console.WriteLine(xml);
    //        }

    //        using (StringReader stringReader = new StringReader(xml))
    //        {
    //            Order o = (Order)serializer.Deserialize(stringReader);
    //            // User the order
    //        }
    //    }
    //}

    #endregion Example 4-72 Serializing a derived, complex class to XML

    #region Example 4-73 Using binary serialization

    //[Serializable]
    //public class Person
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }

    //    #region Example 4-74 Using attributes to control serialization

    //    [NonSerialized]
    //    private bool isDirty = false;

    //    #endregion Example 4-74 Using attributes to control serialization

    //    #region Example 4-75 Influencing serialization and deserialization

    //    [OnSerializing()]
    //    internal void OnSerializingMethod(StreamingContext context)
    //    {
    //        Console.WriteLine("OnSerializing");
    //    }

    //    [OnSerialized()]
    //    internal void OnSerializedMethod(StreamingContext context)
    //    {
    //        Console.WriteLine("OnSerialized");
    //    }

    //    [OnDeserializing()]
    //    internal void OnDeserializingMethod(StreamingContext context)
    //    {
    //        Console.WriteLine("OnDeserializing.");
    //    }

    //    [OnDeserialized()]
    //    internal void OnDeserializedMethod(StreamingContext context)
    //    {
    //        Console.WriteLine("OnSerialized.");
    //    }

    //    #endregion Example 4-75 Influencing serialization and deserialization
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Person p = new Person
    //        {
    //            Id = 1,
    //            Name = "John Doe"
    //        };

    //        IFormatter formatter = new BinaryFormatter();
    //        using (Stream stream = new FileStream("data.bin", FileMode.Create))
    //        {
    //            formatter.Serialize(stream, p);
    //        }

    //        using (Stream stream = new FileStream("data.bin", FileMode.Open))
    //        {
    //            Person dp = (Person)formatter.Deserialize(stream);
    //        }
    //    }
    //}

    #endregion Example 4-73 Using binary serialization

    #region Example 4-76 Implementing ISerializable

    //[Serializable]
    //public class PersonComplex : ISerializable
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    private bool isDirty = false;

    //    public PersonComplex() { }

    //    protected PersonComplex(SerializationInfo info, StreamingContext context)
    //    {
    //        Id = info.GetInt32("Value1");
    //        Name = info.GetString("Value2");
    //        isDirty = info.GetBoolean("Value3");
    //    }

    //    [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, SerializationFormatter = true)]
    //    public void GetObjectData(SerializationInfo info, StreamingContext context)
    //    {
    //        info.AddValue("Value1", Id);
    //        info.AddValue("Value2", Name);
    //        info.AddValue("Value3", isDirty);
    //    }
    //}

    #endregion Example 4-76 Implementing ISerializable}

    #region Example 4-77 Using a DataContract

    //[DataContract]
    //public class PersonDataContract
    //{
    //    [DataMember]
    //    public int Id { get; set; }

    //    [DataMember]
    //    public string Name { get; set; }

    //    private bool isDirty = false;
    //}

    #endregion Example 4-77 Using a DataContract

    #region Example 4-78 Using the DataContractSerializer

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        PersonDataContract p = new PersonDataContract
    //        {
    //            Id = 1,
    //            Name = "John Doe"
    //        };

    //        using (Stream stream = new FileStream("data.xml", FileMode.Create))
    //        {
    //            DataContractSerializer ser = new DataContractSerializer(typeof(PersonDataContract));
    //            ser.WriteObject(stream, p);
    //            Console.WriteLine();
    //        }

    //        XElement xml = XElement.Load("data.xml");
    //        Console.WriteLine(xml.ToString());

    //        using (Stream stream = new FileStream("data.xml", FileMode.Open))
    //        {
    //            DataContractSerializer ser = new DataContractSerializer(typeof(PersonDataContract));
    //            PersonDataContract result = (PersonDataContract)ser.ReadObject(stream);
    //        }
    //    }
    //}

    #endregion Example 4-78 Using the DataContractSerializer

    #region Example 4-79 Using the DataContractJsonSerializer

    //[DataContract]
    //public class Person
    //{
    //    [DataMember]
    //    public int Id { get; set; }
    //    [DataMember]
    //    public string Name { get; set; }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Person p = new Person
    //        {
    //            Id = 1,
    //            Name = "John Doe"
    //        };

    //        using (MemoryStream stream = new MemoryStream())
    //        {
    //            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));
    //            ser.WriteObject(stream, p);

    //            stream.Position = 0;
    //            StreamReader streamReader = new StreamReader(stream);
    //            Console.WriteLine(streamReader.ReadToEnd());

    //            stream.Position = 0;
    //            Person result = (Person)ser.ReadObject(stream);
    //        }
    //    }
    //}

    #endregion Example 4-79 Using the DataContractJsonSerializer
}