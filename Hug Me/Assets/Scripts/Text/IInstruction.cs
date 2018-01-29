using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInstruction 
{
    void OutputInstruction(GameObject gameObject = null, params string[] data);
}
