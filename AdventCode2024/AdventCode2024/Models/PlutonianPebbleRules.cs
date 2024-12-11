namespace AdventCode2024.Models;

public class PlutonianPebbleRules
{
    public LinkedList<long> Stones { get; set; }
    public PlutonianPebbleRules(string inData)
    {
        var list = inData.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => long.Parse(s)).ToList();

        Stones = new LinkedList<long>(list);
    }

    public void DoBlink()
    {
        LinkedListNode<long>? current = Stones.First;
        while (current != null)
        {
            current = BlinkStone(current);
        }
    }

    public LinkedListNode<long>? BlinkStone(LinkedListNode<long> current)
    {
        /*
         - If the stone is engraved with the number 0, it is replaced by a stone engraved with the number 1.
         - If the stone is engraved with a number that has an even number of digits, 
            it is replaced by two stones. The left half of the digits are engraved on the new left stone, 
            and the right half of the digits are engraved on the new right stone. 
            (The new numbers don't keep extra leading zeroes: 1000 would become stones 10 and 0.)
         - If none of the other rules apply, the stone is replaced by a new stone; 
            the old stone's number multiplied by 2024 is engraved on the new stone.
         */
        string sval = current.Value.ToString();
        if (current.Value == 0)
        {
            current.Value = 1;
        }
        else if (sval.Length % 2 == 0)
        {
            string sval1 = sval.Substring(0, sval.Length/2);
            string sval2 = sval.Substring(sval.Length / 2).TrimStart('0');
            sval2 = string.IsNullOrWhiteSpace(sval2) ? "0": sval2;
            current.Value = long.Parse(sval2);
            Stones.AddBefore(current, long.Parse(sval1));
        } 
        else
        {
            current.Value = current.Value * 2024;
        }
        return current.Next;
    }
}
