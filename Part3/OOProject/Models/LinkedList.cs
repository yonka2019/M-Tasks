using System.Collections.Generic;

namespace OOProject
{
    internal class LinkedList
    {
        private Node head;
        private Node tail;

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
            if (head == null)
            {
                head = new Node(value);
                tail = head;
            }
            else
            {
                tail.Next = new Node(value);
                tail = tail.Next;
            }
        }

        internal void Prepend(int value)
        {
            if (head == null)
                head = new Node(value);
            else
                head = new Node(value, head.Next);
        }

        internal int? Pop()
        {
            int value;
            Node ptr = head;

            if (ptr == null)  // blank LL
                return null;

            while (ptr.Next.Next != null)
                ptr = ptr.Next;

            value = ptr.Next.Value;

            ptr.Next = null;
            tail = ptr;

            return value;
        }

        internal int? Unqueue()
        {
            int value;

            if (head != null)
            {
                value = head.Value;
                head = head.Next;
            }
            else
                return null;

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
            head = MergeSort(head);
        }

        private Node MergeSort(Node head)
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


            Node InnerSort(Node a, Node b)
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

            Node GetMiddle(Node _head)
            {
                if (_head == null)
                    return _head;

                Node fastptr = _head.Next
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
        }
    }
}
