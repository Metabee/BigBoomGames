using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

    ScoreController mScore;
    Text mText;
    string final;
       // Use this for initialization


	void Start () {
        mScore = GameObject.Find("Score").GetComponent<ScoreController>();
        mText = GetComponent<Text>();
        final = mScore.totalPoints.ToString();

    }
	
	// Update is called once per frame
	void Update () {

        if (mScore.totalPoints == 0)
            mText.text = "Easter Egg (PACIFISTA) +10000000 Hug Points";
        else
            mText.text = "Tu puntaje final fue:" + final;
	}
}
