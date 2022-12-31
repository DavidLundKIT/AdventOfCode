using System.Diagnostics;

namespace AdventCode2022.Models
{
    public class GrovePositioningSystem
    {
        public List<long> OriginalOrder { get; set; }
        public LinkedList<Tuple<long, long>> OrderList { get; set; }
        public long DecryptionKey { get; set; }

        public GrovePositioningSystem(List<long> originalOrder, long decryptionKey = 1)
        {
            OriginalOrder = new List<long>();
            OrderList = new LinkedList<Tuple<long, long>>();
            DecryptionKey = decryptionKey;

            for (int i = 0; i < originalOrder.Count; i++)
            {
                OriginalOrder.Add(originalOrder[i]);
                OrderList.AddLast(new Tuple<long, long>(i, OriginalOrder[i] * DecryptionKey));
            }
        }

        public void DoMove(int step)
        {

            var tNow = new Tuple<long, long>(step, OriginalOrder[step] * DecryptionKey);
            var nodeNow = OrderList.Find(tNow);
            long steps = nodeNow.Value.Item2 % (OrderList.Count - 1);
            if (steps < 0)
            {
                LinkedListNode<Tuple<long, long>> nodeNew = nodeNow.Previous ?? nodeNow.List.Last;
                OrderList.Remove(nodeNow);
                for (long i = 0; i > steps; i--)
                {
                    nodeNew = nodeNew.Previous ?? nodeNew.List.Last;
                }

                OrderList.AddAfter(nodeNew, tNow);
            }
            else if (steps > 0)
            {
                LinkedListNode<Tuple<long, long>> nodeNew = nodeNow.Next ?? nodeNow.List.First;
                OrderList.Remove(nodeNow);
                for (long i = 0; i < steps; i++)
                {
                    nodeNew = nodeNew.Next ?? nodeNew.List.First;
                }
                OrderList.AddBefore(nodeNew, tNow);
            }
            else
            {
                Debug.WriteLine($"Node value is {nodeNow.Value.Item1}, {nodeNow.Value.Item2}");
            }
        }

        public long FindNthValueAfterZero(long nth)
        {
            // zero is unique
            var index = OriginalOrder.IndexOf(0);

            var tZero = new Tuple<long, long>(index, OriginalOrder[index]);
            var nodeNew = OrderList.Find(tZero);
            if (nodeNew.Value.Item2 != 0)
            {
                throw new Exception("Did not find node 0!");
            }
            for (long i = 0; i < nth; i++)
            {
                nodeNew = nodeNew.Next ?? nodeNew.List.First;
            }
            return nodeNew.Value.Item2;
        }
    }
}
