using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    #region Example 4-90 Inheriting from List<T> to form a custom collection

    public class PeopleCollection : List<Person>
    {
        public void RemoveByAge(int age)
        {
            for (int index = this.Count - 1; index >= 0; index--)
            {
                if (this[index].Age == age)
                {
                    this.RemoveAt(index);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Person p in this)
            {
                sb.Append($"{p.Name} is {p.Age}");
            }
            return sb.ToString();
        }
    }

    #endregion Example 4-90 Inheriting from List<T> to form a custom collection

    class Program
    {
        #region Example 4-87 Using HashSet<T>

        //public static void UseHashSet()
        //{
        //    HashSet<int> oddSet = new HashSet<int>();
        //    HashSet<int> evenSet = new HashSet<int>();

        //    for (int x = 0; x <= 10; x++)
        //    {
        //        if (x % 2 == 0)
        //        {
        //            evenSet.Add(x);
        //        }
        //        else
        //        {
        //            oddSet.Add(x);
        //        }
        //    }

        //    DisplaySet(oddSet);
        //    DisplaySet(evenSet);

        //    oddSet.UnionWith(evenSet);
        //    DisplaySet(oddSet);
        //}

        //private static void DisplaySet(HashSet<int> set)
        //{
        //    Console.WriteLine("{");
        //    foreach (int i in set)
        //    {
        //        Console.WriteLine($"    {i}");
        //    }
        //    Console.WriteLine("}");
        //}

        #endregion Example 4-87 Using HashSet<T>

        static void Main(string[] args)
        {
            #region Example 4-80 Using an array

            //int[] arrayOfInt = new int[10];

            //for (int x = 0; x < arrayOfInt.Length; x++)
            //{
            //    arrayOfInt[x] = x;
            //}

            //foreach (int i in arrayOfInt)
            //{
            //    Console.WriteLine(i);
            //}

            #endregion Example 4-80 Using an array

            #region Example 4-81 Using a two-dimensional array

            //string[,] array2D = new string[3, 2] { { "one", "two" }, { "three", "four" }, { "five", "six" } };

            //Console.WriteLine(array2D[0,0]);
            //Console.WriteLine(array2D[0,1]);
            //Console.WriteLine(array2D[1,0]);
            //Console.WriteLine(array2D[1,1]);
            //Console.WriteLine(array2D[2,0]);
            //Console.WriteLine(array2D[2,1]);

            #endregion Example 4-81 Using a two-dimensional array

            #region Example 4-82 Creating a jagged array

            //int[][] jaggedArray =
            //{
            //    new int[] {1,3,5,7,9},
            //    new int[] {0,2,4,6},
            //    new int[] {42,21}
            //};

            #endregion Example 4-82 Creating a jagged array

            #region Example 4-84 Using List<T>

            //List<string> listOfStrings =
            //    new List<string> { "A", "B", "C", "D", "E" };

            //for (int x = 0; x < listOfStrings.Count; x++)
            //{
            //    Console.WriteLine(listOfStrings[x]);
            //}

            //listOfStrings.Remove("A");

            //Console.WriteLine(listOfStrings[0]);

            //listOfStrings.Add("F");

            //Console.WriteLine(listOfStrings.Count);

            //bool hasC = listOfStrings.Contains("C");

            //Console.WriteLine(hasC);

            #endregion Example 4-84 Using List<T>

            #region Example 4-85 Using Dictionary<TKey, TValue>

            //Person p1 = new Person { Id = 1, Name = "Name1" };
            //Person p2 = new Person { Id = 2, Name = "Name2" };
            //Person p3 = new Person { Id = 3, Name = "Name3" };

            //var dict = new Dictionary<int, Person>();
            //dict.Add(p1.Id, p1);
            //dict.Add(p2.Id, p2);
            //dict.Add(p3.Id, p3);

            //foreach (var v in dict)
            //{
            //    Console.WriteLine($"{v.Key}: {v.Value.Name}");
            //}

            //dict[0] = new Person { Id = 4, Name = "Name4" };

            //Person result;
            //if (!dict.TryGetValue(5, out result))
            //{
            //    Console.WriteLine("No person with a key of 5 can be found");
            //}

            #endregion Example 4-85 Using Dictionary<TKey, TValue>

            #region Example 4-88 Using Queue<T>

            //Queue<string> myQueue = new Queue<string>();
            //myQueue.Enqueue("Hello");
            //myQueue.Enqueue("World");
            //myQueue.Enqueue("From");
            //myQueue.Enqueue("A");
            //myQueue.Enqueue("Queue");

            //foreach (string s in myQueue)
            //{
            //    Console.Write($"{s} ");
            //}

            #endregion Example 4-88 Using Queue<T>

            #region Example 4-89 Using Stack<T>

            //Stack<string> myStack = new Stack<string>();
            //myStack.Push("Hello");
            //myStack.Push("World");
            //myStack.Push("From");
            //myStack.Push("A");
            //myStack.Push("Queue");

            //foreach (string s in myStack)
            //{
            //    Console.Write($"{s} ");
            //}

            #endregion Example 4-89 Using Stack<T>

            Person p1 = new Person
            {
                Name = "John Doe",
                Age = 42
            };

            Person p2 = new Person
            {
                Name = "Jane Doe",
                Age = 21
            };

            PeopleCollection people = new PeopleCollection { p1, p2 };
            people.RemoveByAge(42);
            Console.WriteLine(people.Count);
        }
    }
}
