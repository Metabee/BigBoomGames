using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacifistModeChecker : MonoBehaviour {

    Vector3 old_Position;
    Transform playerPos;
    float easterEggTime;

	// Use this for initialization
	void Start () {

        playerPos = GameObject.Find("Character").GetComponent<Transform>();
        old_Position = playerPos.position;

	}
	
	// Update is called once per frame
	void Update () {

        print(easterEggTime);

        if(playerPos.position == old_Position)
        {
            CheckPacifism();
        }

        old_Position = playerPos.position;
	}

    void CheckPacifism()
    {
        easterEggTime += Time.deltaTime;
        if(easterEggTime >= 30f)
        {
            print("10,000,000 Hug Points Adquired");
        }


    }

}
