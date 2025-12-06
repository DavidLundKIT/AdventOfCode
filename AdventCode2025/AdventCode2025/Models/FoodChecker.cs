namespace AdventCode2025.Models;

public class FoodChecker
{
    public Dictionary<IngredientRange, long> IngredientRanges { get; set; }
    public SortedList<long, long> Ingredients { get; set; }

    public FoodChecker(string[] lines)
    {
        bool inRangesSection = true;
        IngredientRanges = new Dictionary<IngredientRange, long>();
        Ingredients = new SortedList<long, long>();

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                inRangesSection = false;
                continue;
            }
            if (inRangesSection)
            {
                // Parse ingredient range
                var parts = line.Split('-');
                var startId = long.Parse(parts[0]);
                var endId = long.Parse(parts[1]);
                if (endId < startId)
                {
                    // Wrap around case
                    var temp = startId;
                    startId = endId;
                    endId = temp;
                }
                var foodRange = new IngredientRange(startId, endId);
                if (IngredientRanges.ContainsKey(foodRange))
                {
                    IngredientRanges[foodRange]++;
                }
                else
                {
                    IngredientRanges.Add(new IngredientRange(startId, endId), 0);
                }
            }
            else
            {
                var foodId = long.Parse(line);
                Ingredients.Add(foodId, 1);
            }
        }
    }

    public int FindFreshIngredients()
    {
        var FreshIngredients = new Dictionary<long, int>();

        foreach (var range in IngredientRanges.Keys)
        {
            var freshFoodsInRange = Ingredients.Where(ingredient => ingredient.Key >= range.StartFoodId && ingredient.Key <= range.EndFoodId).Select(ingredient => ingredient.Key)
                .ToList();
            foreach (var foodId in freshFoodsInRange)
            {
                if (FreshIngredients.ContainsKey(foodId))
                {
                    FreshIngredients[foodId]++;
                }
                else
                {
                    FreshIngredients[foodId] = 1;
                }
            }
        }
        return FreshIngredients.Count;
    }

    public long FindValidIngredients()
    {
        Dictionary<long, long> CombinedIngredientRanges = new Dictionary<long, long>();

        Queue<IngredientRange> rangesQueue = new Queue<IngredientRange>(IngredientRanges.Keys.OrderBy(range => range.StartFoodId).ToList());
        var lastRange = rangesQueue.Dequeue();
        CombinedIngredientRanges.Add(lastRange.StartFoodId, lastRange.EndFoodId);
        long highestEndFoodId = lastRange.EndFoodId;
        while (rangesQueue.Count > 0)
        {
            var nextRange = rangesQueue.Dequeue();
            if (CombinedIngredientRanges.ContainsKey(nextRange.StartFoodId))
            {
                // Exact match on start
                if (nextRange.EndFoodId > CombinedIngredientRanges[lastRange.StartFoodId])
                {
                    // new latest end foodid
                    CombinedIngredientRanges[lastRange.StartFoodId] = nextRange.EndFoodId;
                    highestEndFoodId = nextRange.EndFoodId;
                }
                // else no update needed
                continue;
            }
            else if (nextRange.StartFoodId <= highestEndFoodId)
            {
                // starts inside existing range
                if (nextRange.EndFoodId > CombinedIngredientRanges[lastRange.StartFoodId])
                {
                    // new latest end foodid
                    CombinedIngredientRanges[lastRange.StartFoodId] = nextRange.EndFoodId;
                    highestEndFoodId = nextRange.EndFoodId;
                }
                // else no update needed
                continue;
            }
            else
            {
                // past the last range
                lastRange = nextRange;
                CombinedIngredientRanges.Add(nextRange.StartFoodId, nextRange.EndFoodId);
                highestEndFoodId = nextRange.EndFoodId;
            }
        }

        long totalValidIngredients = 0;
        foreach (var range in CombinedIngredientRanges)
        {
            totalValidIngredients += (range.Value - range.Key + 1);
        }
        return totalValidIngredients;
    }
}

public record IngredientRange(long StartFoodId, long EndFoodId);
