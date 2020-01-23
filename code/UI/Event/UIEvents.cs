using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIEvents : MonoBehaviour
{
    public static void ScoreChanged(int value)
    {
        OnScoreChanged?.Invoke(value);
    }

    public static void HealthChanged(int  value)
    {
        OnHealthChanged?.Invoke(value);
    }

    public delegate void ScoreChangedEventHandler(int value);
    public static event ScoreChangedEventHandler OnScoreChanged;
    public delegate void HealthChangedEventHandler(int value);
    public static event HealthChangedEventHandler OnHealthChanged;
}
