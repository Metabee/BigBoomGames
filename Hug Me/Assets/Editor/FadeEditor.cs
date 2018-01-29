using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

[CustomEditor(typeof(Fade), true)]
/* 
 * Note(0):
 * CustomEditor(Arg 0, Arg 1)
 * Arg 0 -> Script
 * Arg 1 -> Can Change Childrens
 */
public class FadeEditor : Editor
{
    private SerializedObject targetObject;

    public void OnEnable()
    {
        // Generic
        targetObject = new SerializedObject(target);
    }

    public override void OnInspectorGUI()
    {
        targetObject.Update();

        // Specific
        Fade fade = target as Fade;

        GUILayout.Label("On: " + fade.C_fade.ToString());

        # region Rich text
        GUIStyle style = new GUIStyle();
        style.richText = true;
        # endregion

        GUILayout.Space(10);

        // Args
        GUILayout.Label("<b>Args[]: </b>",style);

        fade.crossFade = EditorGUILayout.Toggle("Cross Fade: ", fade.crossFade);

        GUILayout.Label("Curve: ");

        EditorGUILayout.BeginHorizontal();
        {          
            fade.curve = EditorGUILayout.CurveField(fade.curve);

            if (fade.crossFade)
            {
                fade.otherCurve = EditorGUILayout.CurveField(fade.otherCurve);
            }
        }
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(5);

        GUILayout.Label(new GUIContent("Timer for Fade: ", "Time Range > 1"));

        fade.fadeTime = EditorGUILayout.FloatField(fade.fadeTime);
        // Control
        if (fade.fadeTime < 0)
        {
            fade.fadeTime = 0;
        }
 
		GUILayout.Space(10);

        fade.outPut = EditorGUILayout.BeginToggleGroup("Output Instructions", fade.outPut);
        // {
        if (fade.outPut)
        {
            var prop = targetObject.FindProperty("gameObjectInstructions");

            EditorGUILayout.PropertyField(prop, true);

            targetObject.ApplyModifiedProperties();
        }
        // }
        EditorGUILayout.EndToggleGroup();
    }
}
