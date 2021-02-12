using System;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    public class RefineryNanoFactory
    {
        public Dictionary<string, Recipe> Chemicals { get; set; }

        public RefineryNanoFactory()
        {
            Chemicals = new Dictionary<string, Recipe>();
        }

        public void ParseRecipe(string input)
        {
            string[] ingredients = input.Substring(0, input.IndexOf("=>")).Split(",");
            string chemical = input.Substring(input.IndexOf("=>") + 2);

            Recipe recipe = Recipe.ParseIngredient(chemical);

            foreach (string item in ingredients)
            {
                Recipe ingredient = Recipe.ParseIngredient(item);
                recipe.Ingredients.Add(ingredient);
            }

            if (!Chemicals.ContainsKey(recipe.Chemical))
            {
                Chemicals.Add(recipe.Chemical, recipe);
            }
            else
            {
                throw new ArgumentException($"Same chemical: {recipe.Chemical}");
            }
        }

        public long OreCostFor(string chemical, long neededAmount)
        {
            long oreCost = 0;
            if (Chemicals.TryGetValue(chemical, out Recipe recipe))
            {
                if (recipe.SurplusAmount < neededAmount)
                {
                    // don't have enough, make enough
                    do
                    {
                        foreach (Recipe item in recipe.Ingredients)
                        {
                            oreCost += OreCostFor(item.Chemical, item.CreatesAmount);
                        }
                        recipe.SurplusAmount += recipe.CreatesAmount;
                    } while (recipe.SurplusAmount < neededAmount);
                }
                recipe.SurplusAmount -= neededAmount;
            }
            else
            {
                if (chemical == "ORE")
                {
                    oreCost = neededAmount;
                }
                else
                {
                    throw new ArgumentNullException($"Could not find {chemical}");
                }
            }
            return oreCost;
        }
    }
}
