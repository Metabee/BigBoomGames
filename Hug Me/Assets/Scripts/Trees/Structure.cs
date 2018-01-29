using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    public GameObject firePrefab;

    public bool isBurning = false;
    Transform mTransform;
    bool timeToBurn = true;
    SpriteRenderer mSprite;
    ScoreController score;
    public int p = 5;

    // Use this for initialization
    void Start()
    {
        mTransform = GetComponent<Transform>();
        mSprite = GetComponent<SpriteRenderer>();
        score = GameObject.Find("Score").GetComponent<ScoreController>();
        mSprite.sortingOrder = (int)-transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {

        if (isBurning)
        {
            while (timeToBurn)
            {
                StartCoroutine(WaitToBurn());

                Collider2D[] coll = Physics2D.OverlapCircleAll(mTransform.position, 6f);

                for (int i = 0; i < coll.Length; i++)
                {
                    Structure otherAarbol = coll[i].gameObject.GetComponent<Structure>();

                    if (coll[i].gameObject.tag == ("Structure"))
                    {
                        if (otherAarbol.isBurning != true)
                        {
                            float chance = Random.Range(0, 10);

                            if (chance == 0)
                                otherAarbol.OnFire();
                        }
                    }
                }
            }

        }

        if (!isBurning)
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(mTransform.position, 6f);

            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].gameObject.tag == ("Character"))
                {
                    OnFire();
                }
            }
        }
    }

    IEnumerator WaitToBurn()
    {
        timeToBurn = false;
        yield return new WaitForSeconds(2);
        timeToBurn = true;
    }
    // Rquiere de que el jugador posea un tag llamado "Player"

    void OnTriggerEnter2D(Collider2D collider)
    {

        GameObject triggered = collider.gameObject;

        if (isBurning == false)
        {         
            if (triggered.tag == ("Villager") && triggered != null)
            {
                Fire_Collision npcFireCollisioner = triggered.GetComponent<Fire_Collision>();

                if (npcFireCollisioner.isBurning == true)
                {
                    OnFire();
                }

            }
        }
    }
    void OnFire()
    {
        score.Score(p);
        
        isBurning = true;

        float r = Random.Range(1, 4);

        for (int i = 0; i < r; i++)
        {
            Collider2D coll = GetComponent<Collider2D>();

            float randomX = Random.Range(0, coll.bounds.extents.x / 2);
            float randomY = Random.Range(0, coll.bounds.extents.y / 2);

            float randomSignX = Random.Range(-1, 1);
            while (randomSignX == 0)
            {
                randomSignX = Random.Range(-1, 1);
            }

            float randomSignY = Random.Range(-1, 1);
            while (randomSignY == 0)   
            {
                randomSignY = Random.Range(-1, 1);
            }


            GameObject fire = Instantiate(firePrefab, new Vector2(transform.position.x + (randomSignX * randomX), transform.position.y + (randomSignY * randomY)), transform.rotation) as GameObject;
            SpriteRenderer fireRenderer = fire.GetComponent<SpriteRenderer>();
            fireRenderer.sortingOrder = (int)-transform.position.y + 1;

        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow * new Color(1,1,1,0.25f);
        Gizmos.DrawSphere(transform.position, 6);
    }
}
