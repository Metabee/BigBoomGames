using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

	// Use this for initialization
	public void PassEscene()
    {
        SceneManager.LoadScene(0);
	}

}
