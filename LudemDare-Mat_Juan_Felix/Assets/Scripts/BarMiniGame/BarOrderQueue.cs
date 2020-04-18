using UnityEngine;
using System.Collections;
using ProjectName.MiniGames.Bar;
using System;
using static ProjectName.MiniGames.Bar.DrinkRecipe;
using System.Text;
using System.Runtime.CompilerServices;

public class BarOrderQueue : MonoBehaviour
{
    private BarCookbook m_cookbook = new BarCookbook();
    private String m_currentOrder;

    private float m_timer = 1;

    private void Start()
    {
        
    }

    private void Update()
    {
        m_timer -= Time.deltaTime;

        if (m_timer < 0)
        {
            m_currentOrder = NewOrder();
            Debug.Log(m_currentOrder);

            m_timer = 1;
        }
    } 

    public String NewOrder()
    {
        return m_cookbook.GetRecipe();
    }

}
