using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AdventCodeLib
{
    public class Day21FractalArt
    {
        public Dictionary<string, char[,]> Rules { get; set; }

        public char[,] ArtWork { get; set; }

        public Day21FractalArt()
        {
            Rules = new Dictionary<string, char[,]>();
            ArtWork = new char[3, 3] { { '.', '#', '.' }, { '.', '.', '#' }, { '#', '#', '#' } };
        }

        public void ParseData(string[] lines)
        {
            foreach (var rule in lines)
            {
                ParseRule(rule);
            }
        }

        public void ParseRule(string line)
        {
            var parts = line.Split(new string[] { " => " }, StringSplitOptions.RemoveEmptyEntries);
            var ruleParts = parts[1].Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            char[,] ruleValue = null;
            if (ruleParts.Length == 3)
            {
                ruleValue = new char[3, 3];
            }
            else
            {
                ruleValue = new char[4, 4];
            }
            for (int i = 0; i < ruleParts.Length; i++)
            {
                var chs = ruleParts[i].ToCharArray();
                for (int j = 0; j < ruleParts.Length; j++)
                {
                    ruleValue[i, j] = chs[j];
                }
            }
            Rules.Add(parts[0], ruleValue);
        }

        public T[,] FlipVert<T>(T[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new ArgumentException();
            T[,] ret = new T[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    ret[j, i] = matrix[n - j - 1, i];
                }
            }

            return ret;
        }

        public T[,] FlipHori<T>(T[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new ArgumentException();
            T[,] ret = new T[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    ret[i, j] = matrix[i, n - j - 1];
                }
            }

            return ret;
        }

        /// <summary>
        /// Rotates an array by 90 degrees. (To the left <==)
        /// Modified to be generic and automatically get the array dimension size.
        /// https://stackoverflow.com/a/42535
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public T[,] RotateMatrix<T>(T[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new ArgumentException();
            T[,] ret = new T[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    ret[j, i] = matrix[i, n - j - 1];
                }
            }

            return ret;
        }

        public void DumpMatrix<T>(T[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new ArgumentException();
            Debug.WriteLine("------------------");
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    Debug.Write(matrix[i, j]);
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("------------------");
            Debug.WriteLine("");
        }

        public int CountPixels(char[,] matrix)
        {
            int n = matrix.GetLength(0);
            int pixels = 0;
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new ArgumentException();
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    if (matrix[i, j] == '#')
                        pixels++;
                }
            }
            return pixels;
        }

        public char[,] MakeKeyMatrix(int I, int J, int size, char[,] matrix)
        {
            var keyMatrix = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    keyMatrix[i, j] = matrix[i + I, j + J];
                }
            }
            return keyMatrix;
        }


        public string MakeKey(int size, char[,] matrix)
        {
            StringBuilder key = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    key.Append(matrix[i, j]);
                }
                key.Append('/');
            }
            key.Remove(key.Length - 1, 1);
            return key.ToString();
        }

        public void DoIteration()
        {
            int dimNow = ArtWork.GetLength(0);
            if (ArtWork.GetLength(0) != ArtWork.GetLength(1)) throw new ArgumentException();

            int sizeNow = (dimNow % 2 == 0) ? 2 : 3;
            int gridNow = dimNow / sizeNow;
            int dimNext = gridNow * (sizeNow + 1);

            var nextArtWork = new char[dimNext, dimNext];

            for (int i = 0; i < gridNow; i++)
            {
                int I = i * sizeNow;
                for (int j = 0; j < gridNow; j++)
                {
                    int J = j * sizeNow;
                    var matrix = MakeKeyMatrix(I, J, sizeNow, ArtWork);
                    var rule = FindRule(sizeNow, matrix);
                    InsertRule(i, j, sizeNow + 1, rule, nextArtWork);
                }
            }
            ArtWork = nextArtWork;
        }

        public void InsertRule(int x, int y, int size, char[,] rule, char[,] matrix)
        {
            int I = x * size;
            int J = y * size;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i + I, j + J] = rule[i, j];
                }
            }
        }

        public char[,] FindRule(int size, char[,] matrix)
        {
            var ruleValue = FindRuleRotated(size, matrix);
            if (ruleValue != null)
            {
                return ruleValue;
            }
            // still not, flip horizontal
            var rotate = FlipHori(matrix);
            ruleValue = FindRuleRotated(size, rotate);
            if (ruleValue != null)
            {
                return ruleValue;
            }
            // still not, flip vertically
            rotate = FlipVert(matrix);
            ruleValue = FindRuleRotated(size, rotate);
            if (ruleValue != null)
            {
                return ruleValue;
            }
            throw new ArgumentOutOfRangeException("key");
        }

        public char[,] FindRuleRotated(int size, char[,] matrix)
        {
            var key = MakeKey(size, matrix);
            if (Rules.ContainsKey(key))
            {
                return Rules[key];
            }
            // rotate 1
            var rotate = RotateMatrix(matrix);
            key = MakeKey(size, rotate);
            if (Rules.ContainsKey(key))
            {
                return Rules[key];
            }
            // rotate 2
            rotate = RotateMatrix(rotate);
            key = MakeKey(size, rotate);
            if (Rules.ContainsKey(key))
            {
                return Rules[key];
            }
            // rotate 3
            rotate = RotateMatrix(rotate);
            key = MakeKey(size, rotate);
            if (Rules.ContainsKey(key))
            {
                return Rules[key];
            }
            return null;
        }
    }
}
