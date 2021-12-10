using System.Collections.Generic;
using System.Linq;

namespace AdventCode2021
{
    public class SyntaxChecker
    {
        public string[] Lines { get; set; }
        public Stack<char> ChunkStack { get; set; }
        public List<long> CompScores { get; set; }

        public SyntaxChecker(string[] lines)
        {
            ChunkStack = new Stack<char>();
            CompScores = new List<long>();
            Lines = lines;
        }

        public long CheckSyntaxScore()
        {
            long score = 0;
            foreach (var line in Lines)
            {
                score += SyntaxScore(line);
            }
            return score;
        }

        public long GetCompScore()
        {
            CompScores.Sort();
            int idx = CompScores.Count / 2;
            long midvalue = CompScores.Skip(idx).Take(1).ToList()[0];
            return midvalue;
        }

        public long SyntaxScore(string line)
        {
            long score = 0;
            char chpopped;
            ChunkStack.Clear();

            foreach (var ch in line.ToCharArray())
            {
                switch (ch)
                {
                    case '(':
                        ChunkStack.Push(ch);
                        break;
                    case ')':
                        chpopped = ChunkStack.Pop();
                        if (chpopped != '(')
                        {
                            // bad chunk
                            score += 3;
                        }
                        break;
                    case '[':
                        ChunkStack.Push(ch);
                        break;
                    case ']':
                        chpopped = ChunkStack.Pop();
                        if (chpopped != '[')
                        {
                            // bad chunk
                            score += 57;
                        }
                        break;
                    case '{':
                        ChunkStack.Push(ch);
                        break;
                    case '}':
                        chpopped = ChunkStack.Pop();
                        if (chpopped != '{')
                        {
                            // bad chunk
                            score += 1197;
                        }
                        break;
                    case '<':
                        ChunkStack.Push(ch);
                        break;
                    case '>':
                        chpopped = ChunkStack.Pop();
                        if (chpopped != '<')
                        {
                            // bad chunk
                            score += 25137;
                        }
                        break;
                    default:
                        break;
                }
                if (score > 0)
                    break;
            }
            if (score == 0)
            {
                // an incomplete row
                long compScore = 0;
                while (ChunkStack.Count > 0)
                {
                    char ch = ChunkStack.Pop();
                    switch (ch)
                    {
                        case '(':
                            compScore = 5 * compScore + 1;
                            break;
                        case '[':
                            compScore = 5 * compScore + 2;
                            break;
                        case '{':
                            compScore = 5 * compScore + 3;
                            break;
                        case '<':
                            compScore = 5 * compScore + 4;
                            break;
                        default:
                            break;
                    }
                }
                CompScores.Add(compScore);
            }
            return score;
        }
    }
}
