using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_AlertRun : MonoBehaviour
{
    public Vector3 moveVector;

    public float timetoStop;

    float t;

	// Use this for initialization
	void Start ()
    {
        moveVector = -transform.position;

        t = Time.time;

        StartCoroutine(TakeDistance());
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // Coroutine

    public IEnumerator TakeDistance()
    {
        while (Time.time <= t + timetoStop)
        {
            transform.position += Vector3.Normalize(moveVector) * -7 * Time.deltaTime;

            yield return new WaitForSeconds(Time.deltaTime);

            if (GetComponent<NPC_BurningController>().burningControllerburn)
            {
                break;
            }
        }
        if (!GetComponent<NPC_BurningController>().burningControllerburn)
        {
            GetComponent<Animator>().SetBool("Run", false);

            GetComponent<NPC_AlertSearch>().enabled = true;

            Villager mVillager = GetComponent<Villager>();

            mVillager.normal = true;
            mVillager.enabled = true;

            StartCoroutine(mVillager.VillagerMove());

            this.enabled = false;
        }       

        StopCoroutine("TakeDistance");
    }
}
