using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedBackLog : MonoBehaviour
{

    public static FeedBackLog FeedBack;
    public Text LogText;
    string log;

     public void Log(string message)
    {
        log = message + Environment.NewLine + message;
        LogText.text = log;
    }

    void Awake()
    {
        FeedBack = this;
    }
}
