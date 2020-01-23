using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    void Execute();
    bool Released { get; set; }
}
