using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour, IInstruction
{
    public bool C_fade = false;

    public bool inverse = false;

    # region User parameters
    public bool crossFade;

    public int curveNumber;

    public AnimationCurve curve;

    public AnimationCurve otherCurve;

    public float x;
    # endregion

    public float fadeTime;

    public float time;

    // ----------
    // Interface

    public bool outPut;

    public GameObject[] gameObjectInstructions;

    public IInstruction[] instructions;

    // interface function
    public void OutputInstruction (GameObject gameObject = null, params string[] data)
    {
        if (data.Length != 0)
        {
            if (data[0] == "Inverse")
            {
                inverse = true;
            }
        }
        else
        {
            if (inverse)
            {
                inverse = false;
            }
        }

        C_fade = true;

        // time
        //{
        time = Time.time;
        //}
    }
}
