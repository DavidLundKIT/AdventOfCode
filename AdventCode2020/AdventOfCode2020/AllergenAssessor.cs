using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class AllergenAssessor
    {
        public SortedDictionary<string, HashSet<string>> AllergenIngredientsMap { get; set; }
        public List<string> AllIngredients { get; set; }
        public List<string> CleanIngredients { get; set; }

        public AllergenAssessor(string[] foods)
        {
            AllergenIngredientsMap = new SortedDictionary<string, HashSet<string>>();
            AllIngredients = new List<string>();
            foreach (var food in foods)
            {
                ParseFoods(food);
            }
        }

        public void ParseFoods(string food)
        {
            var parts = food.Replace("(", " ").Replace(")", " ").Split("contains");
            List<string> ingredients = new List<string>(parts[0].Split(' ', StringSplitOptions.RemoveEmptyEntries));
            List<string> allergens = new List<string>(parts[1].Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries));
            foreach (var item in allergens)
            {
                if (AllergenIngredientsMap.ContainsKey(item))
                {
                    // Intersect the hashsets to get the common ingredients
                    AllergenIngredientsMap[item].IntersectWith(ingredients);
                }
                else
                {
                    HashSet<string> list = new HashSet<string>(ingredients);
                    AllergenIngredientsMap.Add(item, list);
                }
            }
            AllIngredients.AddRange(ingredients);
        }

        public int RemoveAllergenicIngredients()
        {
            CleanIngredients = new List<string>(AllIngredients);
            foreach (var badIngredients in AllergenIngredientsMap.Values)
            {
                foreach (var badIngredient in badIngredients)
                {
                    CleanIngredients.RemoveAll(i => i.Equals(badIngredient));
                }
            }

            return CleanIngredients.Count;
        }

        public string CanonicalDangerousIngredientList()
        {
            List<string> ingredients = new List<string>();

            while (AllergenIngredientsMap.Values.Any(h => h.Count > 1))
            {
                ingredients = AllergenIngredientsMap.Values.Where(bi => bi.Count == 1).Select(bi => bi.ToArray()[0]).ToList();

                foreach (var badIngredients in AllergenIngredientsMap.Values)
                {
                    if (badIngredients.Count > 1)
                    {
                        ingredients.Select(s => badIngredients.Remove(s)).ToArray();
                    }
                }
            }

            ingredients.Clear();
            foreach (var badIngredients in AllergenIngredientsMap)
            {
                foreach (var badIngredient in badIngredients.Value)
                {
                    if (!ingredients.Exists(i => i.Equals(badIngredient)))
                    {
                        ingredients.Add(badIngredient);
                    }
                }
            }
            string cdil = string.Join(',', ingredients);
            return cdil;
        }
    }
}
