using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2022.Models
{
    public class SupplyCrane
    {
        public List<Stack<char>> Stacks { get; set; }

        public SupplyCrane(int stackSize)
        {
            Stacks = new List<Stack<char>>(stackSize);
            if (3 == stackSize)
            {
                // test
                Stacks[0] = new Stack<char>(new [] { 'N', 'Z' });
                Stacks[1] = new Stack<char>(new[] { 'N', 'Z' });
                Stacks[2] = new Stack<char>(new[] { 'N', 'Z' });
            }
            else 
            { 

            }
        }
    }
}
