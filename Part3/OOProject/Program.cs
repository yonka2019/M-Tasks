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
            ll.Append(3);
            ll.Append(2);
            ll.Append(6);

            ll.Sort();

            Console.WriteLine(ll);
        }
    }
}
