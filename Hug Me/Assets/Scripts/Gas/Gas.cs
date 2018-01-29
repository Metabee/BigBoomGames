using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    public GameObject explosion;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            GetComponent<Animator>().SetBool("Explosion", true);

            StartCoroutine(SlefDestroy());
        }
    }

    public IEnumerator SlefDestroy()
    {
        yield return new WaitForSeconds(3.04f);       

        Instantiate(explosion, transform.position, transform.rotation);

        Destroy(gameObject);

    }
}
