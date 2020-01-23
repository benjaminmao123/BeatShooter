using System;

public class InputManager : Singleton<InputManager>
{
    private void Start()
    {
        Inputs = GetComponentsInChildren<IInput>();
    }

    private void Update()
    {
        Array.ForEach(Inputs, i => i.Execute());
    }

    IInput[] Inputs;
}
