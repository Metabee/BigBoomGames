using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_BurningFlee : MonoBehaviour {

    public float speed;
    float randomX;
	float randomY;
	bool timeToChange = true;
	float randomSign = 0;
	float randomSwinger;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

		if(timeToChange)
			StartCoroutine (RandomMovement());

		transform.position += new Vector3((randomX * speed * Time.deltaTime ), (randomY * speed * Time.deltaTime),0);
	}

	IEnumerator RandomMovement ()
	{
		timeToChange = false;
		randomX = Random.Range (-3, 4);
        while (randomX >= -1 && randomX <= 1)
        {
            randomX = Random.Range(-3, 4);
        }
		randomY = Random.Range (-3, 4);
        while (randomY >= -1 && randomY <= 1)
        {
            randomY = Random.Range(-3, 4);
        }
        randomSwinger = Random.Range (3, 6);
		yield return new WaitForSeconds (randomSwinger);
		timeToChange = true;
	}
}
