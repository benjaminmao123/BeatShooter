using System;
using UnityEngine;

public class SecondaryFireInput : MonoBehaviour, IInput
{ 
    void Start()
    {
        Released = true;
        InputActions = GetComponents<IInputAction>();
    }
    public void Execute()
    {
        if (Input.GetAxis("Fire2") > 0)
        {
            if (Released)
            {
                Released = false;
                Array.ForEach(InputActions, action => action.Execute());
            }
        }
        else
        {
            Released = true;
        }
    }

    public bool Released { get; set; }
    IInputAction[] InputActions;
}
