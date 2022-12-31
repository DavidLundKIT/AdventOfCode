using System.Diagnostics;

namespace AdventCode2022.Models
{
    public class GrovePositioningSystem
    {
        public List<int> OriginalOrder { get; set; }
        public LinkedList<Tuple<int, int>> OrderList { get; set; }

        public GrovePositioningSystem(List<int> originalOrder)
        {
            OriginalOrder = originalOrder;
            OrderList = new LinkedList<Tuple<int, int>>();

            for (int i = 0; i < originalOrder.Count; i++)
            {
                OrderList.AddLast(new Tuple<int, int>(i, originalOrder[i]));
            }
        }

        public void DoMove(int step)
        {

            var tNow = new Tuple<int, int>(step, OriginalOrder[step]);
            var nodeNow = OrderList.Find(tNow);
            if (nodeNow.Value.Item2 < 0)
            {
                LinkedListNode<Tuple<int, int>> nodeNew = nodeNow.Previous ?? nodeNow.List.Last;
                OrderList.Remove(nodeNow);
                for (int i = 0; i > nodeNow.Value.Item2; i--)
                {
                    nodeNew = nodeNew.Previous ?? nodeNew.List.Last;
                }

                OrderList.AddAfter(nodeNew, tNow);
            }
            else if (nodeNow.Value.Item2 > 0)
            {
                LinkedListNode<Tuple<int, int>> nodeNew = nodeNow.Next ?? nodeNow.List.First;
                OrderList.Remove(nodeNow);
                for (int i = 0; i < nodeNow.Value.Item2; i++)
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

        public int FindNthValueAfterZero(int nth)
        {
            // zero is unique
            var index = OriginalOrder.IndexOf(0);

            var tZero = new Tuple<int, int>(index, OriginalOrder[index]);
            var nodeNew = OrderList.Find(tZero);
            if (nodeNew.Value.Item2 != 0)
            {
                throw new Exception("Did not find node 0!");
            }
            for (int i = 0; i < nth; i++)
            {
                nodeNew = nodeNew.Next ?? nodeNew.List.First;
            }
            return nodeNew.Value.Item2;
        }
    }
}
