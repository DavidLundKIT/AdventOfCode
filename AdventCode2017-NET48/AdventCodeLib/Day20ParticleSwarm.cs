using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventCodeLib
{
    public class Particle
    {
        public Particle(string row, int i)
        {
            Org = row;
            Index = i;
            var vals = row.Split(new char[] { '<', '>', ',', ' ', 'p', 'a', 'v', '=' }, StringSplitOptions.RemoveEmptyEntries);
            OrgPosition = MakeVector(vals[0], vals[1], vals[2]);
            Position = MakeVector(vals[0], vals[1], vals[2]);
            Velocity = MakeVector(vals[3], vals[4], vals[5]);
            Acceleration = MakeVector(vals[6], vals[7], vals[8]);
            Destroyed = false;
        }

        public bool Destroyed { get; set; }
        public int Index { get; set; }
        public string Org { get; set; }
        public Vector3 OrgPosition { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Velocity { get; set; }
        public Vector3 Acceleration { get; set; }

        public Vector3 MakeVector(string x, string y, string z)
        {
            return new Vector3(float.Parse(x), float.Parse(y), float.Parse(z));
        }
    }

    static public class ParticleHelpers
    {
        public static float AbsV3(this Vector3 a)
        {
            return (Math.Abs(a.X) + Math.Abs(a.Y) + Math.Abs(a.Z));
        }

        public static string MakeKey(this Vector3 a)
        {
            return $"<{a.X},{a.Y},{a.Z}>";
        }
    }
    public class Day20ParticleSwarm
    {
        public Day20ParticleSwarm()
        {
            Particles = new List<Particle>();
        }
        public List<Particle> Particles { get; set; }

        public Particle FindSlowest()
        {
            float minAcc = Particles.Min(a => a.Acceleration.AbsV3());
            float maxAcc = Particles.Max(a => a.Acceleration.AbsV3());
            var accList = Particles.FindAll(b => b.Acceleration.AbsV3() == minAcc);

            float minVel = Particles.Min(a => a.Velocity.AbsV3());
            float maxVel = Particles.Max(a => a.Velocity.AbsV3());
            var velList = Particles.FindAll(b => b.Velocity.AbsV3() == minVel);

            float minDist = Particles.Min(a => a.Position.AbsV3());
            float maxDist = Particles.Max(a => a.Position.AbsV3());
            var distList = Particles.FindAll(b => b.Position.AbsV3() == minDist);

            for (int i = 0; i < maxDist; i++)
            {
                MoveParticles();
            }
            float distNow = Particles.Min(b => b.Position.AbsV3());
            var closest = Particles.FindAll(c => c.Position.AbsV3() == distNow);

            return closest[0];
        }

        public void MoveParticles()
        {
            foreach (var p in Particles)
            {
                p.Velocity = Vector3.Add(p.Velocity, p.Acceleration);
                p.Position = Vector3.Add(p.Position, p.Velocity);
            }
        }

        public int ResolveCollisions()
        {
            Dictionary<string, Particle> collisions = new Dictionary<string, Particle>();

            foreach (var p in Particles)
            {
                string key = p.Position.MakeKey();
                if(collisions.ContainsKey(key))
                {
                    p.Destroyed = true;
                    collisions[key].Destroyed = true;
                } else
                {
                    collisions.Add(key, p);
                }
            }
            Particles = collisions.Values.ToList().FindAll(p => p.Destroyed == false);
            return Particles.Count;
        }

        public void ParseData(string path)
        {
            var rows = DataTools.ReadAllLines(path);
            Particles.Clear();
            for (int idx = 0; idx < rows.Length; idx++)
            {
                Particle p = new Particle(rows[idx], idx);
                Particles.Add(p);
            }
        }
    }
}
