using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static ProjectName.MiniGames.Bar.DrinkRecipe;
using System.Text;
using System;

namespace ProjectName.MiniGames.Bar
{
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

        public String GetRecipe()
        {
            int recipeIndex = UnityEngine.Random.Range(0, m_barRecipes.Count - 1);

            StringBuilder builder = new StringBuilder();

            builder.Append(m_barRecipes[recipeIndex].Name);

            foreach (Ingredient ingredient in m_barRecipes[recipeIndex].Ingredients)
            {
                builder.Append(", " + ingredient.ToString());
            }

            return builder.ToString();
        }
    }
}