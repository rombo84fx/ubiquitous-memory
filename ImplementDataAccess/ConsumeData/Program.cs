using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Transactions;
using System.Data.Entity;
using System.ServiceModel;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace ConsumeData
{
    #region Example 4-37 A simple Person class

    //public class Person
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    #endregion Example 4-37 A simple Person class

    #region Example 4-39 A simple WCF web service

    [ServiceContract]
    public class MyService
    {
        [OperationContract]
        public string DoWork(string left, string right)
        {
            return left + right;
        }
    }

    #endregion Example 4-39 A simple WCF web service

    class Program
    {
        #region Example 4-27 A SqlConnection with a using statement to automatically close it

        //static void Main(string[] args)
        //{
        //    string connectionString = "Server=tcp:rombo84fx.database.windows.net,1433;Database=AdventureWorks;User ID=rombo84fx@rombo84fx;Password=3jNVz27d;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        // Execute operations against the database
        //    } // Connection is automatically closed.
        //}

        #endregion Example 4-27 A SqlConnection with a using statement to automatically close it    

        #region Example 4-28 Creating a connection string with SqlConnectionStringBuilder

        //static void Main(string[] args)
        //{
        //    var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();

        //    sqlConnectionStringBuilder.DataSource = "tcp:rombo84fx.database.windows.net,1433";
        //    sqlConnectionStringBuilder.InitialCatalog = "AdventureWorks";

        //    string connectionString = sqlConnectionStringBuilder.ToString();

        //    Console.WriteLine(connectionString);
        //}

        #endregion Example 4-28 Creating a connection string with SqlConnectionStringBuilder

        #region Example 4-30 Using a connection string from an external configuration file

        //static void Main(string[] args)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorksConnection"].ConnectionString;

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //    }
        //}

        #endregion Example 4-30 Using a connection string from an external configuration file

        #region Example 4-32 Executing a SQL select command

        //public static async Task SelectDataFromTable()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorksConnection"].ConnectionString;

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlCommand command = new SqlCommand("SELECT CustomerID, FirstName, MiddleName, LastName FROM SalesLT.Customer", connection);
        //        await connection.OpenAsync();

        //        SqlDataReader dataReader = await command.ExecuteReaderAsync();

        //        while (await dataReader.ReadAsync())
        //        {
        //            if ((dataReader["MiddleName"] == null))
        //            {
        //                Console.WriteLine($"Person {dataReader["CustomerID"]} is named {dataReader["FirstName"]} {dataReader["LastName"]}");
        //            }
        //            else
        //            {
        //                Console.WriteLine($"Person {dataReader["CustomerID"]} is named {dataReader["FirstName"]} {dataReader["MiddleName"]} {dataReader["LastName"]}");
        //            }
        //        }
        //        dataReader.Close();
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    SelectDataFromTable().Wait();
        //}

        #endregion Example 4-32 Executing a SQL select command

        #region Example 4-33 Executing a SQL query with multiple result sets

        //public static async Task SelectMultipleResultSets()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorksConnection"].ConnectionString;

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlCommand command = new SqlCommand("SELECT * FROM SalesLT.Customer; SELECT TOP 1 * FROM SalesLT.Customer ORDER BY LastName", connection);

        //        await connection.OpenAsync();
        //        SqlDataReader dataReader = await command.ExecuteReaderAsync();
        //        await ReadQueryResults(dataReader);
        //        await dataReader.NextResultAsync();
        //        await ReadQueryResults(dataReader);
        //        dataReader.Close();
        //    }
        //}

        //private static async Task ReadQueryResults(SqlDataReader dataReader)
        //{
        //    while (await dataReader.ReadAsync())
        //    {
        //        if ((dataReader["MiddleName"] == null))
        //        {
        //            Console.WriteLine($"Person {dataReader["CustomerID"]} is named {dataReader["FirstName"]} {dataReader["LastName"]}");
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Person {dataReader["CustomerID"]} is named {dataReader["FirstName"]} {dataReader["MiddleName"]} {dataReader["LastName"]}");
        //        }
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    SelectMultipleResultSets().Wait();
        //}

        #endregion Example 4-33 Executing a SQL query with multiple result sets

        #region Example 4-34 Updating rows with ExecuteNonQuery

        //public static async Task UpdateRows()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorksConnection"].ConnectionString;

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(
        //            "UPDATE SalesLT.Customer SET FirstName = 'Orlando' WHERE CustomerID = 1",
        //            connection);

        //        await connection.OpenAsync();
        //        int numberOfUpdatedRows = await command.ExecuteNonQueryAsync();
        //        Console.WriteLine($"Updated {numberOfUpdatedRows} rows");
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    UpdateRows().Wait();
        //}

        #endregion Example 4-34 Updating rows with ExecuteNonQuery

        #region Example 4-35 Inserting values with a parameterized query

        //public static async Task InsertRowWithParameterizedQuery()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorksConnection"].ConnectionString;

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        SqlCommand command = new SqlCommand(
        //            "INSERT INTO People([FirstName], [LastName], [MiddleName]) VALUES (@firstName, @lastName, @middleName)",
        //            connection);
        //        await connection.OpenAsync();

        //        command.Parameters.AddWithValue("@firstName", "John");
        //        command.Parameters.AddWithValue("@lastName", "Doe");
        //        command.Parameters.AddWithValue("@middleName", "Little");

        //        int numberOfInsertedRows = await command.ExecuteNonQueryAsync();
        //        Console.WriteLine($"Inserted {numberOfInsertedRows} rows");
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    InsertRowWithParameterizedQuery().Wait();
        //}

        #endregion Example 4-35 Inserting values with a parameterized query

        #region Example 4-36 Using a TransactionScope

        //static void Main(string[] args)
        //{
        //    string connectionString = ConfigurationManager.
        //        ConnectionStrings["AdventureWorksConnection"].ConnectionString;

        //    using (TransactionScope transactionScope = new TransactionScope())
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();

        //            SqlCommand command1 = new SqlCommand(
        //                "INSERT INTO People ([FirstName], [LastName], [MiddleName]) VALUES('John', 'Doe', 'Little')",
        //                connection);
        //            SqlCommand command2 = new SqlCommand(
        //                "INSERT INTO People ([FirstName], [LastName], [MiddleName]) VALUES('Jane', 'Doe', 'Little')",
        //                connection);

        //            command1.ExecuteNonQuery();
        //            command2.ExecuteNonQuery();
        //        }
        //        transactionScope.Complete();
        //    }
        //}

        #endregion Example 4-36 Using a TransactionScope

        #region Example 4-38 Using Code First to map a class to the database

        //public class PeopleContext : DbContext
        //{
        //    public IDbSet<Person> People { get; set; }
        //}

        //static void Main(string[] args)
        //{
        //    using (PeopleContext ctx = new PeopleContext())
        //    {
        //        ctx.People.Add(new Person() { Id = 1, Name = "John Doe" });
        //        ctx.SaveChanges();
        //    }

        //    using (PeopleContext ctx = new PeopleContext())
        //    {
        //        Person person = ctx.People.SingleOrDefault(p => p.Id == 1);
        //        Console.WriteLine(person.Name);
        //    }
        //}

        #endregion Example 4-38 Using Code First to map a class to the database

        #region Example 4-43 Parsing an XML file with an XMLReader

        //static void Main(string[] args)
        //{
        //    string xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
        //                <people>
        //                    <person firstname=""john"" lastname=""doe"">
        //                    <contactdetails>
        //                        <emailaddress>john@unknown.com</emailaddress>
        //                    </contactdetails>
        //                    </person>
        //                    <person firstname=""jane"" lastname=""doe"">
        //                    <contactdetails>
        //                        <emailaddress>jane@unknown.com</emailaddress>
        //                        <phonenumber>001122334455</phonenumber>
        //                    </contactdetails>
        //                    </person>
        //                </people>";

        //    using (StringReader stringReader = new StringReader(xml))
        //    {
        //        using (XmlReader xmlReader = XmlReader.Create(stringReader,
        //            new XmlReaderSettings() { IgnoreWhitespace = true }))
        //        {
        //            xmlReader.MoveToContent();
        //            xmlReader.ReadStartElement("people");

        //            string firstName = xmlReader.GetAttribute("firstname");
        //            string lastName = xmlReader.GetAttribute("lastname");

        //            Console.WriteLine($"Person: {firstName} {lastName}");
        //            xmlReader.ReadStartElement("person");

        //            Console.WriteLine("ContactDetails");

        //            xmlReader.ReadStartElement("contactdetails");
        //            string emailAddress = xmlReader.ReadElementContentAsString();

        //            Console.WriteLine($"Email address: {emailAddress}");
        //        }
        //    }
        //}

        //static void Main(string[] args)
        //{
        //    string path = @"C:\Users\rombo84fx\Downloads\Sandy Geraldine Barón Miranda.xml";

        //    using (FileStream fs = File.OpenRead(path))
        //    {
        //        using (XmlReader xmlReader = XmlReader.Create(fs,
        //            new XmlReaderSettings() { IgnoreWhitespace = true }))
        //        {
        //            xmlReader.MoveToContent();
        //            xmlReader.ReadStartElement("my:misCampos");
        //            xmlReader.ReadStartElement("my:InformacionGeneral");
        //            string nombre = xmlReader.ReadElementContentAsString();
        //            string apellidoPaterno = xmlReader.ReadElementContentAsString();
        //            string apellidoMaterno = xmlReader.ReadElementContentAsString();
        //            Console.WriteLine($"{nombre} {apellidoPaterno} {apellidoMaterno}");
        //        }
        //    }
        //}

        #endregion Example 4-43 Parsing an XML file with an XMLReader

        #region Example 4-44 Creating an XML file with XmlWriter

        //static void Main(string[] args)
        //{
        //    StringWriter stream = new StringWriter();

        //    using (XmlWriter writer = XmlWriter.Create(stream,
        //        new XmlWriterSettings() { Indent = true }))
        //    {
        //        writer.WriteStartDocument();
        //        writer.WriteStartElement("People");
        //        writer.WriteStartElement("Person");
        //        writer.WriteAttributeString("firstName", "John");
        //        writer.WriteAttributeString("lastName", "Doe");
        //        writer.WriteStartElement("ContactDetails");
        //        writer.WriteElementString("EmailAddress", "john@unknown.com");
        //        writer.WriteEndElement();
        //        writer.WriteEndElement();
        //        writer.Flush();
        //    }

        //    Console.WriteLine(stream.ToString());
        //}

        #endregion Example 4-44 Creating an XML file with XmlWriter

        #region Example 4-45 Using XmlDocument

        //static void Main(string[] args)
        //{
        //    string xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
        //                <people>
        //                    <person firstname=""john"" lastname=""doe"">
        //                    <contactdetails>
        //                        <emailaddress>john@unknown.com</emailaddress>
        //                    </contactdetails>
        //                    </person>
        //                    <person firstname=""jane"" lastname=""doe"">
        //                    <contactdetails>
        //                        <emailaddress>jane@unknown.com</emailaddress>
        //                        <phonenumber>001122334455</phonenumber>
        //                    </contactdetails>
        //                    </person>
        //                </people>";

        //    XmlDocument doc = new XmlDocument();

        //    doc.LoadXml(xml);
        //    XmlNodeList nodes = doc.GetElementsByTagName("person");

        //    // Output the names of the people in the document
        //    foreach (XmlNode node in nodes)
        //    {
        //        string firstname = node.Attributes["firstname"].Value;
        //        string lastname = node.Attributes["lastname"].Value;
        //        Console.WriteLine($"Name: {firstname} {lastname}");
        //    }

        //    // Start creating a new node
        //    XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "person", "");

        //    XmlAttribute firstNameAttribute = doc.CreateAttribute("firstname");
        //    firstNameAttribute.Value = "Foo";

        //    XmlAttribute lastNameAttribute = doc.CreateAttribute("lastname");
        //    lastNameAttribute.Value = "Bar";

        //    newNode.Attributes.Append(firstNameAttribute);
        //    newNode.Attributes.Append(lastNameAttribute);

        //    doc.DocumentElement.AppendChild(newNode);
        //    Console.WriteLine("Modified xml...");
        //    doc.Save(Console.Out);
        //}

        //static void Main(string[] args)
        //{
        //    string path = @"C:\Users\rombo84fx\Downloads\Sandy Geraldine Barón Miranda.xml";

        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(path);

        //    XmlNodeList nodes = doc.GetElementsByTagName("my:InformacionGeneral");

        //    foreach (XmlNode node in nodes[0].ChildNodes)
        //    {
        //        Console.WriteLine($"{node.Name}: {node.InnerXml}");
        //    }
        //}

        #endregion Example 4-45 Using XmlDocument

        #region Example 4-46 Using an XPath query

        //static void Main(string[] args)
        //{
        //    string xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
        //                <people>
        //                    <person firstname=""john"" lastname=""doe"">
        //                    <contactdetails>
        //                        <emailaddress>john@unknown.com</emailaddress>
        //                    </contactdetails>
        //                    </person>
        //                    <person firstname=""jane"" lastname=""doe"">
        //                    <contactdetails>
        //                        <emailaddress>jane@unknown.com</emailaddress>
        //                        <phonenumber>001122334455</phonenumber>
        //                    </contactdetails>
        //                    </person>
        //                </people>";

        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(xml);

        //    XPathNavigator nav = doc.CreateNavigator();
        //    string query = "//people/person[@firstname='jane']";
        //    XPathNodeIterator iterator = nav.Select(query);

        //    Console.WriteLine(iterator.Count);

        //    while (iterator.MoveNext())
        //    {
        //        string firstName = iterator.Current.GetAttribute("firstname", "");
        //        string lastName = iterator.Current.GetAttribute("lastname", "");
        //        Console.WriteLine($"Name {firstName} {lastName}");
        //    }
        //}

        #endregion Example 4-46 Using an XPath query
    }
}
