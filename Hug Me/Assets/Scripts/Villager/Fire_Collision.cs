using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Collision : MonoBehaviour
{

    
    public bool isBurning = false;

    ScoreController score;
    public int p = 11;
    // Use this for initialization
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    // Rquiere de que el jugador posea un tag llamado "Player"

    void OnTriggerStay2D(Collider2D collider)
    {
        GameObject triggered = collider.gameObject;

        if (isBurning == false)
        {
            if (triggered.tag == "Character" && triggered != null)
            {
                OnFire();
            }
            if (triggered.tag == "Villager" && triggered != null)
            {
                Fire_Collision npcFireCollisioner = triggered.GetComponent<Fire_Collision>();

                if (npcFireCollisioner.isBurning == true)
                {
                    OnFire();
                }
            }
            if (triggered.tag == ("Structure"))
            {
                Structure mStructure = triggered.GetComponent<Structure>();

                if (mStructure.isBurning == true)
                {
                    OnFire();
                }
            }
        }
    }

    void OnFire()
    {
        score.Score(p);
        GameObject.Find("Score").GetComponent<VillagerCount>().a++;
        if (!isBurning)
        {
            isBurning = true;

            Villager mVillager = GetComponent<Villager>();
            mVillager.normal = false;
            mVillager.enabled = false;

            int rAnimarion = Random.Range(0, 2);

            GetComponent<Animator>().SetBool("Burn", true);

            GetComponent<Animator>().SetInteger("BurnType", rAnimarion);

            GetComponent<NPC_AlertSearch>().enabled = false;
            if (GetComponent<NPC_AlertHide>().enabled)
            {
                GetComponent<NPC_AlertHide>().enabled = false;
            }

            if (GetComponent<NPC_AlertRun>().enabled)
            {               
                GetComponent<NPC_AlertRun>().StopCoroutine(GetComponent<NPC_AlertRun>().TakeDistance());

                GetComponent<NPC_AlertRun>().enabled = false;
            }

            NPC_BurningController mNPC_BC = GetComponent<NPC_BurningController>();
            mNPC_BC.enabled = true;

            mNPC_BC.burningControllerburn = true;

            Fire_Collision mFC = GetComponent<Fire_Collision>();
            mFC.enabled = false;
        }
    }
}
