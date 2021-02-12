using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019
{
    public class Recipe
    {
        public Recipe()
        {
            Ingredients = new List<Recipe>();
        }

        public long CreatesAmount { get; set; }
        public long SurplusAmount { get; set; }
        public string Chemical { get; set; }
        public List<Recipe> Ingredients { get; set; }

        public static Recipe ParseIngredient(string ingredient)
        {
            Recipe recipe = new Recipe();

            string[] parts = ingredient.Trim().Split(" ");
            recipe.Chemical = parts[1].Trim();
            recipe.CreatesAmount = long.Parse(parts[0]);
            return recipe;
        }

        public override string ToString()
        {
            return $"Recipe c: {Chemical}, a: {CreatesAmount}, s: {SurplusAmount} i: {Ingredients.Count}";
        }
    }
}
