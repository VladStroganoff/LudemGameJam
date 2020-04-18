using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Anything relating to systems outside of a minigame.
/// </summary>
namespace ProjectName.Core
{
    /// <summary>
    /// Statistics of the party
    /// </summary>
    public class PartyStatistics
    {
        /// <summary>
        /// How vibrant and dancy your party is; if it reaches 0 -> GameOver
        /// </summary>
        private float m_life;
        public float PartyLife { get { return m_life; } set { m_life = value; } }

        /// <summary>
        /// How violent your customers are; -> the higher this is, the faster your party m_life will drain
        /// </summary>
        private float m_violence;
        public float PartyViolence { get { return m_violence; } set { m_violence = value; } }

        /// <summary>
        /// How drunk your clientele are; The higher this value, the quicker that violence rises, however if it is too low, the party life also begin to drop.
        /// </summary>
        private float m_alcoholLevel;
        public float AlcoholLevel { get { return m_alcoholLevel; } set { m_alcoholLevel = value; } }
        
        /// <summary>
        /// How much the crowd is vibing to your music; The higher this value, the less effect alcohol has on violence.
        /// </summary>
        private float m_musicVibe;
        public float MusicVibe { get { return m_musicVibe; } set { m_musicVibe = value; } }

        /// <summary>
        /// Instance for access
        /// </summary>
        public static PartyStatistics Instance = new PartyStatistics();
    }
}