using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public AudioClip boom;

    AudioSource audioSource;

    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.PlayOneShot(boom);

        StartCoroutine(Explode());

    
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public IEnumerator Explode()
    {
        yield return new WaitForSeconds(1.02f);

        Destroy(gameObject);
    }
}
