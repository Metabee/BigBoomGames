using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class TextFade : Fade
{
    #region Components
    private Text text;
    private Color colorVector;
    #endregion

    // Use this for initialization
    void Awake()
    {
        C_fade = false;

        curveNumber = 0;

        // Get A Instrution Component
        if (gameObjectInstructions != null)
        {
            // Create a Instrution array
            instructions = new IInstruction[gameObjectInstructions.Length];

            for (int i = 0; i < gameObjectInstructions.Length; i++)
            {
                instructions[i] = gameObjectInstructions[i].GetComponent<IInstruction>();
            }
        }

        text = GetComponent<Text>();

        // Create a Color Vector
        colorVector = text.color;
    }

    // Update is called once per frame
    private void Update()
    {
        if (C_fade)
        {
            if (Time.time < time + fadeTime
                &&
                colorVector.a >= 0 && colorVector.a <= 1)
            {
                x = (Time.time - time) / fadeTime;

                // Put Alpha
                switch (curveNumber)
                {
                    case 0:
                        colorVector.a = curve.Evaluate(x);
                        break;
                    case 1:
                        colorVector.a = otherCurve.Evaluate(x);
                        break;
                }  
                
                // Put Color
                text.color = colorVector;
            }

            // Cross fade
            else if (crossFade)
            {
                time = Time.time;

                // Change curve
                curveNumber = (curveNumber == 0) ? 1 : 0;
            }

            else
            {
                for (int i = 0; i < instructions.Length; i++)
                {
                    instructions[i].OutputInstruction(gameObject);
                }

                StopFade();
            }
        }
    }

    // ----------

    public void StopFade()
    {
        if (colorVector.a <= 0 || colorVector.a >= 1)
        {
            // Reset the Limit
                // fade Out
            if (colorVector.a <= 0)
            {
                text.color = new Color(1, 1, 1, 0);
            }
                // Fade In
            else
            {
                text.color = new Color(1, 1, 1, 1);
            }
        }
        C_fade = false;
    }
}

