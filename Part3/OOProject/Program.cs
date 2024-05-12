using OOProject.Utilities;
using System;

namespace OOProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TestLL();

            Console.ReadKey();
        }

        private static void TestLL()
        {
            LinkedList ll = new LinkedList();

            ll.Append(5);
            ll.Append(9);
            ll.Append(3);
            Console.WriteLine(ll);

            ll.Prepend(2);
            ll.Prepend(-5);


            Console.WriteLine("Linked List Representation:\n" +
                ll);
            Console.WriteLine("\n");

            System.Collections.Generic.IEnumerable<int> ll_list = ll.ToList();
            Console.WriteLine("LinkedList Converted to List:\n" +
                ll_list.ToFormattedString());
            Console.WriteLine("\n");


            ll.Pop();
            ll.Pop();

            Console.WriteLine("Linked List Representation (after pop):\n" +
                ll);
            Console.WriteLine("\n");


            ll.Sort();

            Console.WriteLine("Linked List Representation (after sort):\n" +
                ll);
            Console.WriteLine("\n");


            Console.WriteLine($"Linked List - Max Node Value: {ll.GetMaxNode().Value}");
            Console.WriteLine($"Linked List - Min Node Value: {ll.GetMinNode().Value}");
        }
    }
}
