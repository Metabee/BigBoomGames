using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deep : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Collider2D coll;

    // Use this for initialization
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        coll = GetComponent<Collider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        spriteRenderer.sortingOrder = -(int)(transform.position.y + coll.bounds.extents.y);       
    }
}
