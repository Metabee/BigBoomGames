using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_BurningCircle : MonoBehaviour {

	public float speed;
	float angle;
    float radio;
	float randomSign = 0;

	// Use this for initialization
	void Start ()
    {
		angle = Random.Range (0,360);

        radio = Random.Range(5, 10);

		while (randomSign == 0)
        {
			randomSign = Random.Range (-1, 2);
		}
	}
	
	// Update is called once per frame
	void Update ()
    {

		angle += speed * Time.deltaTime;

		transform.position += new Vector3(radio * (Mathf.Sin (randomSign*angle)*Mathf.PI/180f), radio * (Mathf.Cos (randomSign*angle)*Mathf.PI/180f),0);

	}
}
