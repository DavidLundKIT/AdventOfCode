using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode2019
{
    public class NBodyCalculator
    {
        private const int kLength = 4;
        private MD5 _hasher;

        public int[,] Bodies { get; set; }
        public int[,] Velocities { get; set; }
        public NBodyCalculator(int[,] bodies)
        {
            Bodies = CopyTo(bodies);
            Velocities = new int[4, 4];
            _hasher = MD5.Create();
        }

        public void CalculateVelocity()
        {
            for (int i = 0; i < kLength; i++)
            {
                for (int j = i; j < kLength; j++)
                {
                    for (int v = 0; v < 3; v++)
                    {
                        if (Bodies[i, v] < Bodies[j, v])
                        {
                            Velocities[i, v] += 1;
                            Velocities[j, v] += -1;
                        }
                        if (Bodies[i, v] > Bodies[j, v])
                        {
                            Velocities[i, v] += -1;
                            Velocities[j, v] += 1;
                        }
                    }
                }
            }
        }

        public void ApplyVelocity()
        {
            for (int i = 0; i < kLength; i++)
            {
                for (int v = 0; v < 3; v++)
                {
                    Bodies[i, v] += Velocities[i, v];
                }
            }
        }
        public int CalculateTotalEnergy()
        {
            int totalEnergy = 0;
            for (int i = 0; i < kLength; i++)
            {
                int pe = 0;
                int ke = 0;
                for (int v = 0; v < 3; v++)
                {
                    pe += Math.Abs(Bodies[i, v]);
                    ke += Math.Abs(Velocities[i, v]);
                }
                totalEnergy += (pe * ke);
            }
            return totalEnergy;
        }

        public void DumpBodiesAndVelocities()
        {
            Debug.WriteLine("Bodies                             Velocities");
            for (int i = 0; i < kLength; i++)
            {
                Debug.Write($"Body {i}: pos< ");
                for (int v = 0; v < 3; v++)
                {
                    Debug.Write($"{Bodies[i, v]}, ");
                }
                Debug.Write("> vel < ");
                for (int v = 0; v < 3; v++)
                {
                    Debug.Write($"{Velocities[i, v]}, ");
                }
                Debug.WriteLine(">");
            }
        }

        public int[,] CopyTo(int[,] orgBodies)
        {
            int[,] bodies = new int[4, 3];
            for (int i = 0; i < kLength; i++)
            {
                for (int v = 0; v < 3; v++)
                {
                    bodies[i, v] = orgBodies[i, v];
                }
            }
            return bodies;
        }

        public bool Equal(int[,] orgBodies, int vector)
        {
            for (int i = 0; i < kLength; i++)
            {
                if (Bodies[i, vector] != orgBodies[i, vector])
                {
                    return false;
                }
                if (Velocities[i, vector] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public string Md5Hash(byte[] indata)
        {
            var bhash = _hasher.ComputeHash(indata);

            StringBuilder sb = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < bhash.Length; i++)
            {
                sb.Append(bhash[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sb.ToString();
        }

        public byte[] BothToBytes()
        {
            using (var mem = new MemoryStream())
            {
                for (int i = 0; i < kLength; i++)
                {
                    for (int v = 0; v < 3; v++)
                    {
                        mem.Write(BitConverter.GetBytes(Bodies[i, v]));
                    }
                }

                for (int i = 0; i < kLength; i++)
                {
                    for (int v = 0; v < 3; v++)
                    {
                        mem.Write(BitConverter.GetBytes(Velocities[i, v]));
                    }
                }
                return mem.ToArray();
            }
        }

        public string HashBodiesAndVelocities()
        {
            var bb = BothToBytes();
            return Md5Hash(bb);
        }
    }
}
