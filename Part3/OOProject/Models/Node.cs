namespace OOProject
{
    internal class Node
    {
        internal int Value { get; set; }
        internal Node Next { get; set; }

        internal Node(int value, Node next)
        {
            Value = value;
            Next = next;
        }

        internal Node(int value) : this(value, null) { }
    }
}
