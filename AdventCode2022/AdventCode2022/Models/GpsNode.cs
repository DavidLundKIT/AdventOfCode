using Xunit.Sdk;

namespace AdventCode2022.Models
{
    public class GpsNode
    {
        public GpsNode? Prev { get; set; }
        public GpsNode? Next { get; set; }
        public int Index { get; set; }
        public int Value { get; set; }

        public GpsNode(int index, int value)
        {
            Prev = null;
            Next = null;
            Index = index;
            Value = value;
        }

        public static GpsNode FileToNodes(List<int> nodes)
        {
            GpsNode root = null;
            GpsNode last = null;
            for (int index = 0; index < nodes.Count; index++)
            {
                if (index == 0)
                {
                    root = new GpsNode(index, nodes[index]);
                    last = root;
                }
                else
                {
                    GpsNode node = new GpsNode(index, nodes[index]);
                    last = GpsNode.AddAfter(last, node);
                }
            }
            return root;
        }

        public static void MixNodes(int count, GpsNode root)
        {
            for (int index = 0; index < count; index++)
            {

            }
        }

        /// <summary>
        /// Return last node - in this case new Node
        /// </summary>
        /// <param name="node"></param>
        /// <param name="newNode"></param>
        public static GpsNode AddAfter(GpsNode node, GpsNode newNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            GpsNode temp = node.Next;
            node.Next = newNode;
            newNode.Prev = node;
            newNode.Next = temp;
            if (temp?.Next != null)
            {
                temp.Next.Prev = newNode;
            }
            return newNode;
        }

        /// <summary>
        /// Return last node - in this case Node
        /// </summary>
        /// <param name="node"></param>
        /// <param name="newNode"></param>
        /// <returns></returns>
        public static GpsNode AddBefore(GpsNode node, GpsNode newNode)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }
            GpsNode temp = node.Prev;
            node.Prev = newNode;
            newNode.Prev = temp;
            newNode.Next = node;
            if (temp?.Prev != null)
            {
                temp.Prev.Next = newNode;
            }
            return node;
        }

        /// <summary>
        /// Return number by going down the next side from node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static int Count(GpsNode node)
        {
            int count = 1;
            GpsNode temp = node;
            while (temp.Next != null)
            {
                count++;
                temp = temp.Next;
            }
            return count;
        }

        public static GpsNode FindNodeByIndex(int index, GpsNode root)
        {
            GpsNode temp = root;
            while (temp != null)
            {
                if (temp.Index == index)
                {
                    return temp;
                }
                temp = temp.Next;
            }
            // didn't find it on Next, look up previous
            temp = root;
            while (temp != null)
            {
                if (temp.Index == index)
                {
                    return temp;
                }
                temp = temp.Prev;
            }
            return null;
        }

        public static GpsNode FindNodeByValue(int value, GpsNode root)
        {
            GpsNode temp = root;
            while (temp != null)
            {
                if (temp.Value == value)
                {
                    return temp;
                }
                temp = temp.Next;
            }
            // didn't find it on Next, look up previous
            temp = root;
            while (temp != null)
            {
                if (temp.Value == value)
                {
                    return temp;
                }
                temp = temp.Prev;
            }
            return null;
        }
    }
}
