using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_BurningController : MonoBehaviour
{
    public float life;
    public float loseLifeperFrame;
    [SerializeField]
    NPC_BurningCircle burningNPCcircle;
    [SerializeField]
    NPC_BurningFlee burningNPCflee;
    [SerializeField]
    int selected = 0;
    NPC_BurningController mBurningController;
    [HideInInspector]
    public bool burningControllerburn;
    public AnimationClip clip;
    public bool death;

    // Use this for initialization
    void Start()
    {
        life = 100;

        selected = Random.Range(1, 3);
 
        ActiveBehaviour();
       
    }

    // Update is called once per frame
    void Update()
    {
        life -= loseLifeperFrame * Time.deltaTime;
       
        if (life <= 0 && !death)
        {
            death = true;
           
            GetComponent<Animator>().SetBool("Death", true);

            StartCoroutine(Death());
        }
    }
    void ActiveBehaviour()
    {
        if (selected == 1)
        {
            burningNPCcircle.enabled = true;
        }
        else if (selected == 2)
        {
            burningNPCflee.enabled = true;
        }
    }

    // Coroutine
    public IEnumerator Death()
    {
        yield return new WaitForSeconds(clip.length -1.5f);

        burningNPCcircle.enabled = false;
        burningNPCflee.enabled = false;

        //Agregar ejecucion de muerte o animacion de muerte
        this.enabled = false;

        StopCoroutine("Death");
    }

}
