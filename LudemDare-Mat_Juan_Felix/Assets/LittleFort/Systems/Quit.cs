using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

namespace LittleFort.Managers
{
    public class Quit : MonoBehaviour
    {
        public bool m_isStart = false;

        private void Update()
        {
            if(m_isStart == true)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    SceneManager.LoadScene(1);
                }
                if (Input.GetKeyUp(KeyCode.Escape))
                {
                    Application.Quit();
                }
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.Escape))
                {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
}