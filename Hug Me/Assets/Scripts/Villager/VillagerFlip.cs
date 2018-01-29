using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerFlip : MonoBehaviour
{
    float lastX;

    SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	// Update is called once per frame
	void Update ()
    {
        float deltaX = transform.position.x - lastX;

        if (deltaX > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (deltaX < 0)
        {
            spriteRenderer.flipX = true;
        }

        lastX = transform.position.x;
	}
}
