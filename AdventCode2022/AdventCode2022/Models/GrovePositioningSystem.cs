using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
            // The numbers are not unique
            //var uniqueNumbers = new Dictionary<long, long>();
            //foreach (var item in originalOrder)
            //{
            //    uniqueNumbers.Add(item, 1);
            //}
        }

        public void DoMove(int step)
        {
            // step 1 is at index 0 and remember to wrap
            int index = step % OriginalOrder.Count;

            var tNow = new Tuple<int, int>(index, OriginalOrder[index]);
            var nodeNow = OrderList.Find(tNow);
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
    }
}
