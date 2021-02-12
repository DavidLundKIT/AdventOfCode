using System;
using System.Collections.Generic;
using System.Linq;

namespace days.day08
{
    public class NavigationNode
    {
        private readonly IDay08Input _src;
        public NavigationNode(IDay08Input src)
        {
            NavNodes = new List<NavigationNode>();
            MetaData = new List<int>();
            _src = src;
            InitNode();
        }
        public int NumberNodes { get; set; }
        public int NumberMetaData { get; set; }
        public List<NavigationNode> NavNodes { get; set; }
        public List<int> MetaData { get; set;}

        private void InitNode()
        {
            NumberNodes = _src.GiveMe();
            NumberMetaData = _src.GiveMe();
            if (NumberNodes > 0)
            {
                for (int i = 0; i < NumberNodes; i++)
                {
                    NavNodes.Add(new NavigationNode(_src));
                }
            }
            if (NumberMetaData > 0)
            {
                for (int j = 0; j < NumberMetaData; j++)
                {
                    MetaData.Add(_src.GiveMe());
                }
            }
        }

        public int MetaDataSum()
        {
            int sum = 0;
            if (MetaData.Count > 0)
            {
                sum = MetaData.Sum();
            }
            if (NumberNodes > 0)
            {
                foreach (var node in NavNodes)
                {
                    sum += node.MetaDataSum();
                }
            }

            return sum;
        }

        public int NodeSum()
        {
            int sum = 0;
            if (NavNodes.Count == 0)
            {
                sum = MetaData.Sum();
                return sum;
            }
            foreach (var inode in MetaData)
            {
                if (inode > 0 && inode <= NavNodes.Count)
                {
                    sum += NavNodes[inode-1].NodeSum();
                }
            }
            return sum;
        }
    }
}
