using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AlertHide : MonoBehaviour
{
    SpriteRenderer mSpriteRender;
    GameObject[] structures;
    int structureSelected = 0;
    // Use this for initialization
    void Start()
    {
        structures = GameObject.FindGameObjectsWithTag("Structure");
        mSpriteRender = GetComponent<SpriteRenderer>();
        FindClosestStructure();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, structures[structureSelected].transform.position, 12 * Time.deltaTime);
        if (Vector3.Distance(transform.position, structures[structureSelected].transform.position) <= 1.5f)
        {
            mSpriteRender.sortingOrder = -500;
        }
    }
    void FindClosestStructure()
    {
        Vector3 structureTemp;
        float distanceToClosestStructure;
        for (int i = 0; i < structures.Length; i++)
        {
            structureTemp = structures[i].transform.position;
            distanceToClosestStructure = Vector3.Distance(structureTemp, transform.position);
            if (distanceToClosestStructure <= (Vector3.Distance(structures[structureSelected].transform.position, transform.position)))
            {
                bool checkFire = false;
                checkFire = structures[i].GetComponent<Structure>().isBurning;
                if (!checkFire)
                {
                    structureSelected = i;
                }
                
            }
        }
    }
}
