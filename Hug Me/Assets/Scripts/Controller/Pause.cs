using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {


    Camera mCamera;
    Canvas mCanvas;

	// Use this for initialization
	void Start () {

        mCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        mCanvas = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
        mCamera.orthographicSize = 10f;
        Time.timeScale = 1;
        mCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                mCanvas.enabled = true;
                mCamera.orthographicSize = 5f;
                Time.timeScale = 0;
                Debug.Log("Otra vez esta loca pausando");
            }
            else if (Time.timeScale == 0)
            {
                mCanvas.enabled = false;
                mCamera.orthographicSize = 10f;
                Time.timeScale = 1;
            }
        }
    
}
}
