using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderLimit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D x)
    {
        if (x.gameObject.tag == "Villager")
        {
            x.gameObject.transform.position = new Vector3(Mathf.Abs(x.gameObject.transform.position.x) * -Vector3.Normalize(x.gameObject.transform.position).x, Mathf.Abs(x.gameObject.transform.position.y) * -Vector3.Normalize(x.gameObject.transform.position).y, x.gameObject.transform.position.z);
        }
    }
}
