using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine.UI;

using LittleFort.Managers;

namespace ProjectName.MiniGames.Bar
{
    /// <summary>
    /// Bar Minigame main script. Manages new orders at the bar, and effect on PartyStatistics based on perfomance of the player.
    /// </summary>
    public class BarOrderQueue : MonoBehaviour
    {

        private BarCookbook m_cookbook = new BarCookbook();
        private DrinkRecipe m_currentOrder;

        private List<DrinkRecipe.Ingredient> m_drinkMixer = new List<DrinkRecipe.Ingredient>();

        private bool m_orderComplete = false;

        [SerializeField] private GameManager m_gameManager;

        private void Start()
        {
            NewOrder();
        }


        /// <summary>
        /// Creates a new order
        /// </summary>
        /// -- This is a customer initiated action --
        public void NewOrder()
        {
            m_drinkMixer.Clear();
            m_currentOrder = m_cookbook.GetRandomRecipe();
            m_orderComplete = false;
            FeedBackLog.FeedBack.Wipe();
            FeedBackLog.FeedBack.Log("New Order for a: " + m_currentOrder.Name);

            foreach (DrinkRecipe.Ingredient liquid in m_currentOrder.Ingredients)
            {
                FeedBackLog.FeedBack.Log(liquid.ToString());
            }
        }

        /// <summary>
        /// Adds ingredient to the mixer
        /// </summary>
        /// <param name="ingredient">Ingredient Added</param>
        ///  -- This is a player initiated action -- 
        public void AddToMixer(DrinkRecipe.Ingredient ingredient)
        {

            m_drinkMixer.Add(ingredient);

            FeedBackLog.FeedBack.LogIngredient(ingredient.ToString());
        }

        /// <summary>
        /// Checks the current drink mixer against the current order. 
        /// Out of 100 points, either all will go to party life, or some to party life and some to violence.
        /// Remainder of points awarded out of the full 100 goes to violence: life/violence; 100/0, 75/25, 25/75, 
        /// </summary>
        ///  -- This is a player initiated action -- 
        public void CheckOrder()
        {
            if (m_currentOrder == null)
                return;


            if (m_drinkMixer.SequenceEqual(m_currentOrder.Ingredients))
            {
                // full points
                m_gameManager.Score += 100;
                FeedBackLog.FeedBack.Log("Correct!!! Full Points!!!");

            }
            else if (m_drinkMixer.All(m_currentOrder.Ingredients.Contains) && m_drinkMixer.Count == m_currentOrder.Ingredients.Count)
            {
                // 75% of points
                m_gameManager.Score += 75;
                FeedBackLog.FeedBack.Log("Good Enough! 75%");
            }
            else
            {
                // 25% of points 
                m_gameManager.Score += 25;
                FeedBackLog.FeedBack.Log("Eww... 25%");
            }

            FeedBackLog.FeedBack.Log("You made the drink " + m_currentOrder.Name);
            m_orderComplete = true;

            // NewOrder();

            Invoke("NewOrder", 3);
        }
    }
}