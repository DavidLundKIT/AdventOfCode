namespace AdventCode2025.Models;

public class PresentPlacer
{
    public Dictionary<int, PresentShape> Shapes { get; set; }
    public List<Tree> Trees { get; set; }
    public List<Tree> DefaultTrees { get; set; }
    public List<Tree> CalculatedTrees { get; set; }

    public PresentPlacer(string[] lines)
    {
        Shapes = new Dictionary<int, PresentShape>();
        Trees = new List<Tree>();
        DefaultTrees = new List<Tree>();
        CalculatedTrees = new List<Tree>();

        var shapeLines = lines.Take(30).ToList();
        int take = 5;
        for (int skip = 0; skip < shapeLines.Count; skip += take)
        {
            var ps = GetShape(shapeLines.Skip(skip).Take(take).ToList());
            Shapes.Add(ps.Id, ps);
        }

        var treeLines = lines.Skip(30).ToList();

        foreach (var line in treeLines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;
            var parts = line.Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var presents = parts.Skip(1).Select(int.Parse).ToList();
            var size = parts[0].Split("x", StringSplitOptions.RemoveEmptyEntries);
            var tree = new Tree(int.Parse(size[0]), int.Parse(size[1]), presents);
            Trees.Add(tree);
        }
    }

    public PresentShape GetShape(List<string> lines)
    {
        int id = int.Parse(lines[0].Split(':', StringSplitOptions.RemoveEmptyEntries)[0]);
        var shape = lines.Skip(1).Take(3).ToList();
        int size = shape.Sum(s => s.Count(c => c == '#'));
        var ps = new PresentShape(id, size, shape);
        return ps;
    }

    public SimpleTreeSizes GetTotalPresentSize(Tree tree)
    {
        int minSize = 0;
        int maxSize = 0;
        for (int i = 0; i < tree.Presents.Count; i++)
        {
            var shape = Shapes[i];
            minSize += tree.Presents[i] * shape.Size;
            maxSize += tree.Presents[i] * 9;
        }
        int treeSize = tree.X * tree.Y;

        return new SimpleTreeSizes(treeSize, minSize, maxSize);
    }

    public int GetTotalOkRegions()
    {
        DefaultTrees.Clear();
        CalculatedTrees.Clear();
        foreach (var tree in Trees)
        {
            var sizes = GetTotalPresentSize(tree);
            if (sizes.maxPresentSize <= sizes.treeSize)
            {
                DefaultTrees.Add(tree);
                continue;
            }
            if (sizes.minPresentSize <= sizes.treeSize)
            {
                CalculatedTrees.Add(tree);
                continue;
            }
        }
        return DefaultTrees.Count() + CalculatedTrees.Count();
    }
}

public record PresentShape(int Id, int Size, List<string> Shape);
public record Tree(int X, int Y, List<int> Presents);
public record SimpleTreeSizes(int treeSize, int minPresentSize, int maxPresentSize);
