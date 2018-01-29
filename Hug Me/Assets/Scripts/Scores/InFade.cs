using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InFade : MonoBehaviour {
    Text text;
    float x=0;
    bool inFade=false;
    float t=0;
    [SerializeField]
    float time;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();



	}
	
	// Update is called once per frame
	void Update () {

      

        x = Mathf.Clamp(x, 0, 1);
        if (inFade)
        {
            t += Time.deltaTime;
        }

        if (t>time)
        {
            x -= 0.01f;
            inFade = false;
        }

        text.color = new Color(text.color.r,text.color.g,text.color.b,x);
	}

    public void Fade()
    {
        x = 1;
        inFade = true;
        t = 0;
    }
}
