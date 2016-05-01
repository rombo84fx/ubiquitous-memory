using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Security.AccessControl;
using System.Net;
using System.Net.Http;
using System.Diagnostics;

namespace PerformIOOperations
{
    class Program
    {
        #region Example 4-1 Listing drive information

        //static void Main(string[] args)
        //{
        //    DriveInfo[] drivesInfo = DriveInfo.GetDrives();

        //    foreach (DriveInfo driveInfo in drivesInfo)
        //    {
        //        Console.WriteLine($"Drive {driveInfo.Name}");
        //        Console.WriteLine($"    File type: {driveInfo.DriveType}");

        //        if (driveInfo.IsReady == true)
        //        {
        //            Console.WriteLine($"    Volume label: {driveInfo.VolumeLabel}");
        //            Console.WriteLine($"    File system: {driveInfo.DriveFormat}");
        //            Console.WriteLine(
        //                $"  Available space to current user: {driveInfo.AvailableFreeSpace, 15} bytes");
        //            Console.WriteLine(
        //                $"  Total available space: {driveInfo.TotalFreeSpace, 15} bytes");
        //            Console.WriteLine(
        //                $"  Total size of drive: {driveInfo.TotalSize, 15} bytes");
        //        }
        //    }
        //}

        #endregion Example 4-1 Listing drive information    

        #region Example 4-2 Creating a new directory

        //static void Main(string[] args)
        //{
        //    string path = @"C:\Temp\ProgrammingInCSharp\";
        //    var directory = Directory.CreateDirectory($"{path}Directory");

        //    var directoryInfo = new DirectoryInfo($"{path}DirectoryInfo");
        //    directoryInfo.Create();
        //}

        #endregion Example 4-2 Creating a new directory

        #region Example 4-3 Deleting an existing directory

        //static void Main(string[] args)
        //{
        //    string path = @"C:\Temp\ProgrammingInCSharp\";

        //    if (Directory.Exists($"{path}Directory"))
        //    {
        //        Directory.Delete($"{path}Directory");
        //    }

        //    var directoryInfo = new DirectoryInfo($"{path}DirectoryInfo");
        //    if (directoryInfo.Exists)
        //    {
        //        directoryInfo.Delete();
        //    }
        //}

        #endregion Example 4-3 Deleting an existing directory

        #region Example 4-4 Setting access control for a directory

        //static void Main(string[] args)
        //{
        //    DirectoryInfo directoryInfo = new DirectoryInfo("TestDirectory");
        //    directoryInfo.Create();
        //    DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
        //    directorySecurity.AddAccessRule(
        //        new FileSystemAccessRule("everyone",
        //        FileSystemRights.ReadAndExecute,
        //        AccessControlType.Allow));
        //    directoryInfo.SetAccessControl(directorySecurity);
        //}

        #endregion Example 4-4 Setting access control for a directory

        #region Example 4-5 Building a directory tree

        //static void Main(string[] args)
        //{
        //    DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Program Files");
        //    ListDirectories(directoryInfo, "*a*", 5, 0);
        //}

        //private static void ListDirectories(DirectoryInfo directoryInfo,
        //    string searchPattern, int maxLevel, int currentLevel)
        //{
        //    if (currentLevel >= maxLevel)
        //    {
        //        return;
        //    }

        //    string indent = new string('-', currentLevel);

        //    try
        //    {
        //        DirectoryInfo[] subDirectories = directoryInfo.GetDirectories(searchPattern);

        //        foreach (DirectoryInfo subDirectory in subDirectories)
        //        {
        //            Console.WriteLine($"{indent}{subDirectory.Name}");
        //            ListDirectories(subDirectory, searchPattern, maxLevel, currentLevel + 1);
        //        }
        //    }
        //    catch (UnauthorizedAccessException)
        //    {
        //        // You don't have access to this folder
        //        Console.WriteLine($"{indent}Can't access: {directoryInfo.Name}");
        //        return;
        //    }
        //    catch (DirectoryNotFoundException)
        //    {
        //        // The folder is removed while iterating
        //        Console.WriteLine($"{indent}Can't find: {directoryInfo.Name}");
        //        return;
        //    }
        //}

        #endregion Example 4-5 Building a directory tree

        #region Example 4-6 Moving a directory

        //static void Main(string[] args)
        //{
        //    string sourceDirectory = @"C:\SourceDirectory";
        //    string destinationDirectory = @"C:\DestinationDirectory";
        //    Directory.CreateDirectory(sourceDirectory);
        //    Directory.Move(sourceDirectory, destinationDirectory);

        //    string sourceDirectoryInfo = @"C:\SourceDirectoryInfo";
        //    string destinationDirectoryInfo = @"C:\DestinationDirectoryInfo";

        //    var directoryInfoSource = new DirectoryInfo(sourceDirectoryInfo);
        //    directoryInfoSource.Create();
        //    directoryInfoSource.MoveTo(destinationDirectoryInfo);
        //}

        #endregion Example 4-6 Moving a directory

        #region Example 4-7 Listing all the files in a directory

        //static void Main(string[] args)
        //{
        //    foreach (string file in Directory.GetFiles(@"C:\Windows"))
        //    {
        //        Console.WriteLine(file);
        //    }

        //    DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Windows");
        //    foreach (FileInfo fileInfo in directoryInfo.GetFiles())
        //    {
        //        Console.WriteLine(fileInfo.FullName);
        //    }
        //}

        #endregion Example 4-7 Listing all the files in a directory

        #region Example 4-8 Deleting a file

        //static void Main(string[] args)
        //{
        //    string path = @"C:\temp\test.txt";

        //    if (File.Exists(path))
        //    {
        //        File.Delete(path);
        //    }

        //    FileInfo fileInfo = new FileInfo(path);

        //    if (fileInfo.Exists)
        //    {
        //        fileInfo.Delete();
        //    }
        //}

        #endregion Example 4-8 Deleting a file

        #region Example 4-9 Moving a file

        //static void Main(string[] args)
        //{
        //    string path = @"C:\temp\test.txt";
        //    string destPath = @"C:\temp\destTest.txt";

        //    File.CreateText(path).Close();
        //    File.Move(path, destPath);

        //    FileInfo fileInfo = new FileInfo(path);
        //    fileInfo.MoveTo(destPath);
        //}

        #endregion Example 4-9 Moving a file

        #region Example 4-10 Copying a file

        //static void Main(string[] args)
        //{
        //    string path = @"C:\temp\test.txt";
        //    string destPath = @"C:\temp\destTest.txt";

        //    File.CreateText(path).Close();
        //    File.Copy(path, destPath);

        //    FileInfo fileInfo = new FileInfo(path);
        //    fileInfo.CopyTo(destPath);
        //}

        #endregion Example 4-10 Copying a file

        #region Example 4-11 Don't manually concatenate strings to form a file path

        //static void Main(string[] args)
        //{
        //    string folder = @"C:\temp";
        //    string fileName = "test.dat";

        //    string fullPath = folder + fileName;
        //    Console.WriteLine(fullPath);
        //}

        #endregion Example 4-11 Don't manually concatenate strings to form a file path

        #region Example 4-12 Using Path.Combine

        //static void Main(string[] args)
        //{
        //    string folder = @"C:\temp";
        //    string fileName = "test.dat";

        //    string fullPath = Path.Combine(folder, fileName);
        //    Console.WriteLine(fullPath);
        //}

        #endregion Example 4-12 Using Path.Combine

        #region Example 4-13 Using other Path methods to parse a path

        //static void Main(string[] args)
        //{
        //    string path = @"C:\temp\subdir\file.txt";

        //    Console.WriteLine(Path.GetDirectoryName(path));
        //    Console.WriteLine(Path.GetExtension(path));
        //    Console.WriteLine(Path.GetFileName(path));
        //    Console.WriteLine(Path.GetPathRoot(path));
        //}

        #endregion Example 4-13 Using other Path methods to parse a path

        #region Example 4-14 Create and use a FileStream

        //static void Main(string[] args)
        //{
        //    string path = @"C:\temp\test.dat";
        //    Directory.CreateDirectory(Path.GetDirectoryName(path));

        //    using (FileStream fileStream = File.Create(path))
        //    {
        //        string myValue = "MyValue";
        //        byte[] data = Encoding.UTF8.GetBytes(myValue);
        //        fileStream.Write(data, 0, data.Length);
        //    }
        //}

        #endregion Example 4-14 Create and use a FileStream

        #region Example 4-15 Using File.CreateText with a StreamWriter

        //static void Main(string[] args)
        //{
        //    string path = @"C:\temp\test.dat";
        //    Directory.CreateDirectory(Path.GetDirectoryName(path));

        //    using (StreamWriter streamWriter = File.CreateText(path))
        //    {
        //        string myValue = "MyValue";
        //        streamWriter.Write(myValue);
        //    }
        //}

        #endregion Example 4-15 Using File.CreateText with a StreamWriter

        #region Example 4-16 Opening a FileStream and decode the bytes to a string

        //static void Main(string[] args)
        //{
        //    string path = @"C:\temp\test.dat";

        //    using (FileStream fileStream = File.OpenRead(path))
        //    {
        //        byte[] data = new byte[fileStream.Length];

        //        for (int index = 0; index < fileStream.Length; index++)
        //        {
        //            data[index] = (byte)fileStream.ReadByte();
        //        }
        //        Console.WriteLine(Encoding.UTF8.GetString(data));
        //    }
        //}

        #endregion Example 4-16 Opening a FileStream and decode the bytes to a string

        #region Example 4-17 Opening a TextFile and reading the content

        //static void Main(string[] args)
        //{
        //    string path = @"C:\temp\test.dat";

        //    using (StreamReader streamReader = File.OpenText(path))
        //    {
        //        Console.WriteLine(streamReader.ReadLine());
        //    }
        //}

        #endregion Example 4-17 Opening a TextFile and reading the content

        #region Example 4-18 Compressing data with a GZipStream

        //static void Main(string[] args)
        //{
        //    string folder = @"C:\temp";
        //    string uncompressedFilePath = Path.Combine(folder, "uncompressed.dat");
        //    string compressedFilePath = Path.Combine(folder, "compressed.gz");
        //    byte[] dataToCompress = Enumerable.Repeat((byte)'a', 1024 * 1024).ToArray();

        //    using (FileStream uncompressedFileStream = File.Create(uncompressedFilePath))
        //    {
        //        uncompressedFileStream.Write(dataToCompress, 0, dataToCompress.Length);
        //    }

        //    using (FileStream compressedFileStream = File.Create(compressedFilePath))
        //    {
        //        using (GZipStream compressionStream = new GZipStream(
        //            compressedFileStream, CompressionMode.Compress))
        //        {
        //            compressionStream.Write(dataToCompress, 0, dataToCompress.Length);
        //        }
        //    }

        //    FileInfo uncompressedFile = new FileInfo(uncompressedFilePath);
        //    FileInfo compressedFile = new FileInfo(compressedFilePath);

        //    Console.WriteLine(uncompressedFile.Length);
        //    Console.WriteLine(compressedFile.Length);
        //}

        #endregion Example 4-18 Compressing data with a GZipStream

        #region Example 4-19 Using a BufferedStream

        //static void Main(string[] args)
        //{
        //    string path = @"C:\temp\bufferedStream.txt";

        //    using (FileStream fileStream = File.Create(path))
        //    {
        //        using (BufferedStream bufferedStream = new BufferedStream(fileStream))
        //        {
        //            using (StreamWriter streamWriter = new StreamWriter(bufferedStream))
        //            {
        //                streamWriter.Write("A line of text.");
        //            }
        //        }
        //    }
        //}

        #endregion Example 4-19 Using a BufferedStream

        #region Example 4-20 Depending on File.Exists when reading file content

        //private static string ReadAllText()
        //{
        //    string path = @"C:\temp\test.txt";

        //    if (File.Exists(path))
        //    {
        //        return File.ReadAllText(path);
        //    }

        //    return string.Empty;
        //}

        #endregion Example 4-20 Depending on File.Exists when reading file content

        #region Example 4-21 Using exception handling when opening a file

        //private static string ReadAllText()
        //{
        //    string path = @"C:\temp\test.txt";

        //    try
        //    {
        //        return File.ReadAllText(path);
        //    }
        //    catch (DirectoryNotFoundException) { }
        //    catch (FileNotFoundException) { }

        //    return string.Empty;
        //}

        #endregion Example 4-21 Using exception handling when opening a file

        #region Example 4-22 Executing a web request

        //static void Main(string[] args)
        //{
        //    WebRequest request = WebRequest.Create("http://www.microsoft.com");
        //    WebResponse response = request.GetResponse();

        //    StreamReader responseStream = new StreamReader(response.GetResponseStream());
        //    string responseText = responseStream.ReadToEnd();

        //    Console.WriteLine(responseText);

        //    response.Close();
        //}

        #endregion Example 4-22 Executing a web request

        #region Example 4-23 Writing asynchronously to a file

        //public async Task CreateAndWriteAsyncToFile()
        //{
        //    using (FileStream stream = new FileStream("test.dat", FileMode.Create,
        //        FileAccess.Write, FileShare.None, 4096, true))
        //    {
        //        byte[] data = new byte[100000];
        //        new Random().NextBytes(data);

        //        await stream.WriteAsync(data, 0, data.Length);
        //    }
        //}

        #endregion Example 4-23 Writing asynchronously to a file

        #region Example 4-24 Executing an asynchronous HTTP request

        //public static async Task<string> ReadAsyncHttpRequest()
        //{
        //    HttpClient client = new HttpClient();
        //    return await client.GetStringAsync("http://www.microsoft.com");
        //}

        //static void Main(string[] args)
        //{
        //    Console.WriteLine(ReadAsyncHttpRequest().Result);
        //}

        #endregion Example 4-24 Executing an asynchronous HTTP request

        #region Example 4-25 Executing multiple awaits

        //public static async Task ExecuteMultipleRequests()
        //{
        //    HttpClient client = new HttpClient();

        //    string microsoft = await client.GetStringAsync("http://www.microsoft.com");
        //    string msdn = await client.GetStringAsync("http://msdn.microsoft.com");
        //    string blogs = await client.GetStringAsync("http://blogs.msdn.com");
        //}

        #endregion Example 4-25 Executing multiple awaits

        #region Example 4-26 Executing multiple request in parallel

        //public static async Task ExecuteMultipleRequestsInParallel()
        //{
        //    HttpClient client = new HttpClient();

        //    Task microsoft = client.GetStringAsync("http://www.microsoft.com");
        //    Task msdn = client.GetStringAsync("http://msdn.microsoft.com");
        //    Task blogs = client.GetStringAsync("http://blogs.msdn.com");

        //    await Task.WhenAll(microsoft, msdn, blogs);

        //}

        //static void Main(string[] args)
        //{
        //    Stopwatch sw = new Stopwatch();
        //    sw.Start();
        //    ExecuteMultipleRequests();
        //    sw.Stop();

        //    Console.WriteLine(sw.Elapsed);

        //    sw.Reset();
        //    sw.Start();
        //    ExecuteMultipleRequestsInParallel();
        //    sw.Stop();

        //    Console.WriteLine(sw.Elapsed);
        //}

        #endregion Example 4-26 Executing multiple request in parallel
    }
}
