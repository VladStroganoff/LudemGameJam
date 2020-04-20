using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ProjectName.MiniGames.Bar;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace LittleFort.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private BarOrderQueue m_thisBarQue;
        private float m_score = 100;
        public float Score { get { return m_score; } set { m_score = value; } }
        [SerializeField] private Image m_scoreBar;
        [SerializeField] private Text m_scoreText;

        private float m_timeDelay = 1;

        private void Update()
        {
            if(m_score > 100)
            {
                m_score = 100;
            }
            if(m_score < 0)
            {
                m_score = 0;
                SceneManager.LoadScene(0);
            }

            m_timeDelay += (0.05f * Time.deltaTime);

            m_score -= (m_timeDelay * Time.deltaTime);

            m_scoreBar.fillAmount = (m_score / 100);
            m_scoreText.text = (m_score.ToString("000") + " %");
        }
    }
}