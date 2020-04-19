using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedBackLog : MonoBehaviour
{

    public static FeedBackLog FeedBack;
    public Text LogText;
    public Text IngredientsText;
    string log = "";
    string ingredientLog = "";

     public void Log(string message)
    {
        log = log + Environment.NewLine + message;
        LogText.text = log;
    }

    public void LogIngredient(string message)
    {
        ingredientLog = ingredientLog + Environment.NewLine + message;
        IngredientsText.text = ingredientLog;
    }

    void Awake()
    {
        FeedBack = this;
    }

    public void Wipe()
    {
        log = "";
        LogText.text = "";

        ingredientLog = "";
        IngredientsText.text = "";

    }
}
