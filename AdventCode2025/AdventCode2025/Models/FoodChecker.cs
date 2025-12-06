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

    /// <summary>
    /// Blows up for large ranges
    /// </summary>
    /// <returns></returns>
    public long FindValidIngredients_No_Good()
    {
        Dictionary<long, long> ValidIngredients = new Dictionary<long, long>();
        foreach (var range in IngredientRanges.Keys)
        {
            for (long foodId = range.StartFoodId; foodId <= range.EndFoodId; foodId++)
            {
                if (ValidIngredients.ContainsKey(foodId))
                {
                    ValidIngredients[foodId]++;
                }
                else
                {
                    ValidIngredients[foodId] = 1;
                }
            }
        }
        return ValidIngredients.Count;
    }

    public long FindValidIngredients()
    {
        Dictionary<long, long> ValidIngredients = new Dictionary<long, long>();
        foreach (var range in IngredientRanges.Keys)
        {
            for (long foodId = range.StartFoodId; foodId <= range.EndFoodId; foodId++)
            {
                if (ValidIngredients.ContainsKey(foodId))
                {
                    ValidIngredients[foodId]++;
                }
                else
                {
                    ValidIngredients[foodId] = 1;
                }
            }
        }
        return ValidIngredients.Count;
    }
}

public record IngredientRange(long StartFoodId, long EndFoodId);
