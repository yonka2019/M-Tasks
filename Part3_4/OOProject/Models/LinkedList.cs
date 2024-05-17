using OOProject.Utilities;
using System.Collections.Generic;

namespace OOProject
{
    internal class LinkedList
    {
        private Node head, tail;
        private Node MaxNode, MinNode;

        public override string ToString()
        {
            string values = "";
            Node ptr = head;

            while (ptr != null)
            {
                if (ptr == head)
                    values += "(H) ";

                values += $"{ptr.Value} ";
                if (ptr == tail)
                    values += "(T) ";

                values += "-> ";

                ptr = ptr.Next;
            }
            values += $"NULL";

            return values;
        }

        internal void Append(int value)
        {
            Node newNode = new Node(value);

            if (head == null)
            {
                MaxNode = newNode; MinNode = newNode;

                head = newNode;
                tail = head;
            }
            else
            {
                tail.Next = newNode;
                tail = tail.Next;
            }
        }

        internal void Prepend(int value)
        {
            Node newNode = new Node(value, head);  // if head is null ?. will stop the function here and return null (to prevent 'Null Exception')

            if (head == null)
            {
                MaxNode = newNode; MinNode = newNode;
                head = newNode;
            }
            else
            {
                MaxNode = MaxNode.FindMaxNode(newNode); MinNode = MinNode.FindMinNode(newNode);
                head = newNode;
            }
        }

        internal int? Pop()
        {
            if (head == null)
                return null;


            int value;
            Node ptr = head;

            if (ptr == null)  // blank LL
                return null;

            while (ptr.Next.Next != null)
                ptr = ptr.Next;

            value = ptr.Next.Value;

            ptr.Next = null;
            tail = ptr;


            MaxNode = head.FindMaxNode();
            MinNode = head.FindMinNode();

            return value;
        }

        internal int? Unqueue()
        {
            if (head == null)
                return null;


            int value;

            value = head.Value;
            head = head.Next;


            MaxNode = head.FindMaxNode();
            MinNode = head.FindMinNode();

            return value;
        }

        internal IEnumerable<int> ToList()
        {
            List<int> values = new List<int>();
            Node ptr = head;

            while (ptr != null)
            {
                values.Add(ptr.Value);
                ptr = ptr.Next;
            }

            return values;
        }

        internal bool IsCircular()
        {
            return head == tail;
        }

        internal void Sort()
        {
            head = head.MergeSort();
        }

        internal Node GetMaxNode()
        {
            return MaxNode;
        }

        internal Node GetMinNode()
        {
            return MinNode;
        }
    }
}
