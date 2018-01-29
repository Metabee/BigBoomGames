using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AlertSearch : MonoBehaviour
{
    SpriteRenderer mSprite;
    int randomNum;
    [SerializeField]
    NPC_AlertHide alertNPChide;
    [SerializeField]
    NPC_AlertRun alertNPCRun;
    //[SerializeField]
    //NPC_BurningFlee burningNPCflee;
    //[SerializeField]
    //NPC_BurningLay burningNPClay;
    // Use this for initialization

    void Start()
    {
        mSprite = GetComponent<SpriteRenderer>();      
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] radarPlayer = Physics2D.OverlapCircleAll(transform.position, 10f);

        for (int i = 0; i < radarPlayer.Length; i++)
        {
            if (radarPlayer[i].gameObject.tag == "Character")
            {
                AlertOn();

                break;
            }
        }

    }

    void AlertOn()
    {
        GetComponent<Animator>().SetBool("Run",true);

        Villager mVillager = GetComponent<Villager>();
        mVillager.normal = false;
        mVillager.enabled = false;

        int randomNum = Random.Range(0, 2);

        if (randomNum == 1)
        {
           alertNPChide.enabled = true;
        }
        if (randomNum == 0)
        {
            alertNPCRun.enabled = true;
        }

        this.enabled = false;
    }
}
