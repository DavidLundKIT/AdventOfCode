﻿namespace AdventCode2024.Models;

public record Button(long X, long Y);
public record ClawState(Button A, Button B, Button Prize);
public record ClawResult(long PushA, long PushB, long Tokens);

public class ClawCalculator
{
    public List<ClawState> ClawStates { get; set; }

    public ClawCalculator(string[] lines, long offset = 0)
    {
        ClawStates = new List<ClawState>();
        Button? a = null;
        Button? b = null;
        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                var parts = line.Split(new string[] { "Button", ":", ",", " ", "X", "Y", "=", "+" }, StringSplitOptions.RemoveEmptyEntries);
                if (string.Equals(parts[0], "A"))
                {
                    a = new Button(long.Parse(parts[1]), long.Parse(parts[2]));
                }
                if (string.Equals(parts[0], "B"))
                {
                    b = new Button(long.Parse(parts[1]), long.Parse(parts[2]));
                }
                if (string.Equals(parts[0], "Prize"))
                {
                    var prize = new Button(long.Parse(parts[1]) + offset, long.Parse(parts[2]) + offset);
                    ClawStates.Add(new ClawState(a ?? throw new ArgumentNullException("a"), b ?? throw new ArgumentNullException("b"), prize));
                }
            }
            else
            {
                a = null;
                b = null;
            }
        }
    }

    public long FindTokenPrizeCost()
    {
        List<ClawResult> results = new List<ClawResult>();
        long tokens = 0;

        foreach (var cs in ClawStates)
        {
            var cr = TokensForPrize(cs);
            if (cr != null)
            {
                results.Add(cr);
                tokens += cr.Tokens;
            }
        }

        return tokens;
    }

    public long FindTokenPrizeCalcCost()
    {
        List<ClawResult> results = new List<ClawResult>();
        long tokens = 0;

        foreach (var cs in ClawStates)
        {
            var cr = TokensForPrizeCalc(cs);
            if (cr != null)
            {
                results.Add(cr);
                tokens += cr.Tokens;
            }
        }

        return tokens;
    }

    /// <summary>
    /// Previous version (not saved) had one not so smart loop.
    /// The previous version and this version die on Part 2 (too long).
    /// </summary>
    /// <param name="cs"></param>
    /// <returns></returns>
    public ClawResult? TokensForPrize(ClawState cs)
    {
        List<ClawResult> results = new List<ClawResult>();
        long maxA = Math.Max(cs.Prize.X / cs.A.X, cs.Prize.Y / cs.A.Y);
        long maxB = Math.Max(cs.Prize.X / cs.B.X, cs.Prize.Y / cs.B.Y);

        for (long i = 0; i < maxA; i++)
        {
            long tempX = cs.Prize.X - (i * cs.A.X);
            long tempY = cs.Prize.Y - (i * cs.A.Y);
            long j = tempX / cs.B.X;
            long j1 = tempY / cs.B.Y;

            if ((j == j1) && (i * cs.A.X + j * cs.B.X == cs.Prize.X) && (i * cs.A.Y + j * cs.B.Y == cs.Prize.Y))
            {
                results.Add(new ClawResult(i, j, (i * 3) + j));
            }
        }
        for (long j = 0; j < maxB; j++)
        {
            long tempX = cs.Prize.X - (j * cs.B.X);
            long tempY = cs.Prize.Y - (j * cs.B.Y);
            long i = tempX / cs.A.X;
            long i1 = tempY / cs.A.Y;
            if ((i == i1) && (i * cs.A.X + j * cs.B.X == cs.Prize.X) && (i * cs.A.Y + j * cs.B.Y == cs.Prize.Y))
            {
                results.Add(new ClawResult(i, j, (i * 3) + j));
            }
        }
        if (results.Any())
        {
            return results.FirstOrDefault(cr => cr.Tokens == results.Min(cr => cr.Tokens));
        }
        return null;
    }

    /// <summary>
    /// works on the idea that:
    /// n*Ax + m*Bx = Px
    /// n*Ay + m*By = Py
    /// n = (Px - m*Bx)/ Ax
    /// etc.
    /// </summary>
    /// <param name="cs"></param>
    /// <returns></returns>
    public ClawResult? TokensForPrizeCalc(ClawState cs)
    {
        long bottom = (cs.B.Y * cs.A.X - cs.B.X * cs.A.Y);
        if (bottom == 0)
        {
            return null;
        }
        long m = (cs.Prize.Y * cs.A.X - cs.Prize.X * cs.A.Y) / bottom;
        if (cs.A.X == 0)
        {
            return null;
        }

        long n = (cs.Prize.X - m * cs.B.X) / cs.A.X;

        // long div is truncated, check the calculations this way
        if ((n * cs.A.X + m * cs.B.X == cs.Prize.X)
            && (n * cs.A.Y + m * cs.B.Y == cs.Prize.Y))
        {
            return new ClawResult(n, m, n * 3 + m);
        }
        return null;
    }
}
