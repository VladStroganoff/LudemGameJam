using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static ProjectName.MiniGames.Bar.DrinkRecipe;
using System.Text;

namespace ProjectName.MiniGames.Bar
{
    /// <summary>
    /// This class holds our defined recipes to be called from when an order is made at the bar.
    /// This data will also be displayed for the player to recreate the drink in order of ingredients.
    /// </summary>
    public class BarCookbook
    {
        private List<DrinkRecipe> m_barRecipes = new List<DrinkRecipe>()
        {
            new DrinkRecipe("TestOne", Ingredient.Blue, Ingredient.Pink),
            new DrinkRecipe("TestTwo", Ingredient.Green, Ingredient.Blue),
            new DrinkRecipe("TestThree", Ingredient.Blue, Ingredient.Pink, Ingredient.Blue),
            new DrinkRecipe("TestFour", Ingredient.Blue, Ingredient.Pink, Ingredient.Red, Ingredient.Green),
            new DrinkRecipe("TestFive", Ingredient.Red, Ingredient.Green, Ingredient.Pink)
        };

        /// <summary>
        /// AS GetRecipe() but with a randomized recipe from "m_barRecipes"
        /// </summary>
        /// <returns></returns>
        public string GetRandomRecipe()
        {
            return GetRecipe(Random.Range(0, m_barRecipes.Count - 1));
        }

        /// <summary>
        /// Returns a string combination of the DrinkRecipe at "index" position of the "m_barRecipes" list defined as "name, ingredient 1, ingredient 2, ingredient 3, etc, etc"
        /// </summary>
        /// <param name="index">Index position of the recipe in the "m_barRecipes" list</param>
        /// <returns></returns>
        public string GetRecipe(int index)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(m_barRecipes[index].Name);

            foreach (Ingredient ingredient in m_barRecipes[index].Ingredients)
            {
                builder.Append(", " + ingredient.ToString());
            }

            return builder.ToString();
        }
    }
}