using System.Diagnostics;

namespace AdventCode2022.Models
{
    public class GrovePositioningSystem
    {
        public List<int> OriginalOrder { get; set; }
        public LinkedList<Tuple<int, int>> OrderList { get; set; }
        public List<KeyValuePair<int, int>> Duplicates { get; set; }
        public Dictionary<int, int> UniqueNumbers { get; set; }

        public GrovePositioningSystem(List<int> originalOrder)
        {
            OriginalOrder = originalOrder;
            OrderList = new LinkedList<Tuple<int, int>>();

            for (int i = 0; i < originalOrder.Count; i++)
            {
                OrderList.AddLast(new Tuple<int, int>(i, originalOrder[i]));
            }
            // The numbers are not unique
            UniqueNumbers = new Dictionary<int, int>();
            foreach (var item in originalOrder)
            {
                if (UniqueNumbers.ContainsKey(item))
                    UniqueNumbers[item]++;
                else
                    UniqueNumbers.Add(item, 1);
            }
        }

        public void DoMove(int step)
        {
            // step 1 is at index 0 and remember to wrap

            var tNow = new Tuple<int, int>(step, OriginalOrder[step]);
            if (UniqueNumbers[OriginalOrder[step]] > 1)
            {
                Debug.WriteLine(UniqueNumbers[OriginalOrder[step]]);
                Debug.WriteLine(tNow.Item1);
                Debug.WriteLine(tNow.Item2);
                Debug.WriteLine(step);
            }
            var nodeNow = OrderList.Find(tNow);
            var nodeLast = OrderList.FindLast(tNow);
            if (nodeNow != nodeLast)
            {
                Debug.WriteLine("Huh?");
            }
            if (nodeNow.Value.Item2 < 0)
            {
                LinkedListNode<Tuple<int, int>> nodeNew = nodeNow.Previous ?? nodeNow.List.Last;
                for (int i = 0; i > nodeNow.Value.Item2; i--)
                {
                    nodeNew = nodeNew.Previous ?? nodeNew.List.Last;
                }
                OrderList.Remove(nodeNow);

                OrderList.AddAfter(nodeNew, nodeNow);
            }
            else if (nodeNow.Value.Item2 > 0)
            {
                LinkedListNode<Tuple<int, int>> nodeNew = nodeNow.Next ?? nodeNow.List.First;
                for (int i = 0; i < nodeNow.Value.Item2; i++)
                {
                    nodeNew = nodeNew.Next ?? nodeNew.List.First;
                }
                OrderList.Remove(nodeNow);
                OrderList.AddBefore(nodeNew, nodeNow);
            }
            else
            {
                Debug.WriteLine($"Node value is {nodeNow.Value.Item1}, {nodeNow.Value.Item2}");
            }
        }

        public int FindNthValueAfterZero(int nth)
        {
            // zero is unique
            var index = OriginalOrder.IndexOf(0);

            var tZero = new Tuple<int, int>(index, OriginalOrder[index]);
            var nodeNew = OrderList.Find(tZero);
            for (int i = 0; i < nth; i++)
            {
                nodeNew = nodeNew.Next ?? nodeNew.List.First;
            }
            return nodeNew.Value.Item2;
        }
    }
}
