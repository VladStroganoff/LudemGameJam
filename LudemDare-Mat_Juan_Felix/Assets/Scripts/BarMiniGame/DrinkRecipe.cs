using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine.Experimental.AI;

namespace ProjectName.MiniGames.Bar
{
    /// <summary>
    /// Data class for a drink recipe
    /// </summary>
    public class DrinkRecipe
    {
        public enum Ingredient
        {
            Pink,
            Red,
            Blue,
            Green
        }
        
        /// <summary>
        /// Name of the drink
        /// </summary>
        private string m_name = "";
        public string Name { get { return m_name; } }

        /// <summary>
        /// List of ingredients in the drink, in order of preperation
        /// </summary>
        private List<Ingredient> m_ingredients = new List<Ingredient>();
        public List<Ingredient> Ingredients { get { return m_ingredients; } }

        /// <summary>
        /// Struct
        /// </summary>
        public DrinkRecipe(string name, params Ingredient[] ingredients)
        {
            m_name = name;
            m_ingredients.AddRange(ingredients);
        }
    }
}