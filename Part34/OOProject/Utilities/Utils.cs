using System.Collections.Generic;
using System.Linq;

namespace OOProject.Utilities
{
    internal static class Utils
    {
        internal static Node MergeSort(this Node head)
        {
            if (head == null || head.Next == null)
                return head;

            Node middle = GetMiddle(head);
            Node nextofmiddle = middle.Next;

            middle.Next = null;  // reset next node

            Node left = MergeSort(head);
            Node right = MergeSort(nextofmiddle);

            Node sortedList = InnerSort(left, right);
            return sortedList;
        }

        /// <summary>
        /// Returns the max node between two nodes (if equals - returns the FIRST node ($ThisNode.MaxNode($AnotherNode))
        /// </summary>
        internal static Node FindMaxNode(this Node n1, Node n2)
        {
            if (n1 == null)
                return n2;
            else if (n2 == null)
                return n1;


            if (n1.Value < n2.Value)
                return n2;
            else
                return n1;
        }

        internal static Node FindMaxNode(this Node node)
        {
            Node maxNode = null;
            Node ptr = node;

            while (ptr != null)
            {
                maxNode = maxNode.FindMaxNode(ptr);
                ptr = ptr.Next;
            }
            return maxNode;
        }

        /// <summary>
        /// Returns the min node between two nodes (if equals - returns the FIRST node ($ThisNode.MinNode($AnotherNode))
        /// </summary>
        internal static Node FindMinNode(this Node n1, Node n2)
        {
            if (n1 == null)
                return n2;
            else if (n2 == null)
                return n1;


            if (n1.Value > n2.Value)
                return n2;
            else
                return n1;
        }

        internal static Node FindMinNode(this Node node)
        {
            Node minNode = null;
            Node ptr = node;

            while (ptr != null)
            {
                minNode = minNode.FindMinNode(ptr);
                ptr = ptr.Next;
            }
            return minNode;
        }

        internal static string ToFormattedString<T>(this IEnumerable<T> list)
        {
            string str = "";

            str += "[";

            int listCount = list.Count();
            for (int i = 0; i < listCount; i++)
            {
                str += list.ElementAt(i).ToString();
                if (i + 1 != listCount)
                    str += ", ";

            }

            str += "]";

            return str;
        }

        private static Node GetMiddle(Node _head)
        {
            if (_head == null)
                return _head;

            Node fastptr = _head.Next;
            Node slowptr = _head;

            while (fastptr != null)
            {
                fastptr = fastptr.Next;
                if (fastptr != null)
                {
                    slowptr = slowptr.Next;
                    fastptr = fastptr.Next;
                }
            }
            return slowptr;
        }

        private static Node InnerSort(Node a, Node b)
        {
            Node h;

            if (a == null)
                return b;

            else if (b == null)
                return a;

            if (a.Value <= b.Value)
            {
                h = a;
                h.Next = InnerSort(a.Next, b);
            }
            else
            {
                h = b;
                h.Next = InnerSort(a, b.Next);
            }
            return h;
        }
    }
}
