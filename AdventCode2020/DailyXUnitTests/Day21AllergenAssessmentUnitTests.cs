using AdventOfCode2020;
using Xunit;

namespace DailyXUnitTests
{
    public class Day21AllergenAssessmentUnitTests
    {
        [Fact(Skip = "Daily completed")]
        public void Day21_ReadData_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day21Data.txt");
            Assert.Equal(35, lines.Length);
        }

        [Fact(Skip = "Daily completed")]
        public void Day21_Example1_OK()
        {
            string[] foods = new string[] {
                "mxmxvkd kfcds sqjhc nhms(contains dairy, fish)",
                "trh fvjkl sbzzf mxmxvkd(contains dairy)",
                "sqjhc fvjkl(contains soy)",
                "sqjhc mxmxvkd sbzzf(contains fish)"
            };

            Assert.Equal(4, foods.Length);

            var sut = new AllergenAssessor(foods);
            Assert.Equal(3, sut.AllergenIngredientsMap.Count);
            int actual = sut.RemoveAllergenicIngredients();
            Assert.Equal(5, actual);
            var cdil = sut.CanonicalDangerousIngredientList();
            Assert.Contains("mxmxvkd,sqjhc,fvjkl", cdil);
        }

        [Fact(Skip = "Daily completed")]
        public void Day21_AllergenAssessment_Part1_and_Part2_Ok()
        {
            var foods = DailyDataUtilities.ReadLinesFromFile("Day21Data.txt");
            Assert.Equal(35, foods.Length);

            var sut = new AllergenAssessor(foods);
            Assert.Equal(8, sut.AllergenIngredientsMap.Count);
            int actual = sut.RemoveAllergenicIngredients();
            Assert.Equal(1913, actual);

            var cdil = sut.CanonicalDangerousIngredientList();
            // wrong: gpgrb,spbxz,pfdkkzp,gtjmd,tjlz,xcfpc,txzv,znqbr
            Assert.Contains("gpgrb,tjlz,gtjmd,spbxz,pfdkkzp,xcfpc,txzv,znqbr", cdil);
        }

    }
}
