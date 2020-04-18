using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine.Experimental.AI;

namespace ProjectName.MiniGames.Bar
{
    public class DrinkRecipe
    {
        public enum Ingredient
        {
            Pink,
            Red,
            Blue,
            Green
        }

        private string m_name = "";
        public string Name { get { return m_name; } }

        private List<Ingredient> m_ingredients = new List<Ingredient>();
        public List<Ingredient> Ingredients { get { return m_ingredients; } }

        public DrinkRecipe(string name, params Ingredient[] ingredients)
        {
            m_name = name;
            m_ingredients.AddRange(ingredients);
        }
    }
}