﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine.UI;

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
        public Text BarTab;


        private void Update()
        {
            if (m_orderComplete)
            {
                FeedBackLog.FeedBack.Log("You made the drink " + m_currentOrder.ToString());
                NewOrder();
            }
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
            BarTab.text = m_currentOrder.ToString();
        }

        /// <summary>
        /// Adds ingredient to the mixer
        /// </summary>
        /// <param name="ingredient">Ingredient Added</param>
        ///  -- This is a player initiated action -- 
        public void AddToMixer(DrinkRecipe.Ingredient ingredient)
        {
            m_drinkMixer.Add(ingredient);
        }

        /// <summary>
        /// Checks the current drink mixer against the current order. 
        /// Out of 100 points, either all will go to party life, or some to party life and some to violence.
        /// Remainder of points awarded out of the full 100 goes to violence: life/violence; 100/0, 75/25, 25/75, 
        /// </summary>
        ///  -- This is a player initiated action -- 
        public void CheckOrder()
        {
            if (m_drinkMixer.SequenceEqual(m_currentOrder.Ingredients))
            {
                // full points
                Debug.Log("fullpoints");
            }
            else if (m_drinkMixer.All(m_currentOrder.Ingredients.Contains) && m_drinkMixer.Count == m_currentOrder.Ingredients.Count)
            {
                // 75% of points
                Debug.Log("75%");
            }
            else
            {
                // 25% of points 
                Debug.Log("25%");
            }

            m_orderComplete = true;
        }
    }
}