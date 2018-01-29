using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int totalPoints = 0;
    public float maxTimeKS;
    float t;
    int multiplier = 1;
    public Text ks;
    Text[] fastPoints;
    public GameObject pFastPoints;
    [SerializeField]
    float disB;


    private void Start()
    {
        fastPoints = pFastPoints.GetComponentsInChildren<Text>();
        for (int i = 0; i < fastPoints.Length; i++)
        {
            fastPoints[i].transform.position = new Vector3(pFastPoints.transform.position.x, pFastPoints.transform.position.y + (disB* i));
        }
    }
    void Update()
    {
        t -= Time.deltaTime;
        if (t <= 0)
        {
            multiplier = 1;
        }
        ks.text = "Killing Spree X"+multiplier.ToString();
        

    }
    public void Score(int x)
    {
        t = maxTimeKS;
        totalPoints += x * multiplier;
        multiplier++;
        for (int i = 0; i < fastPoints.Length; i++)
        {
            if (fastPoints[i].transform.position.y + disB > (disB * (fastPoints.Length-1)) + pFastPoints.transform.position.y)
            {
                fastPoints[i].transform.position = new Vector3(pFastPoints.transform.position.x, pFastPoints.transform.position.y);
                fastPoints[i].text = totalPoints.ToString() + " Points";
                fastPoints[i].GetComponent<InFade>().Fade();
            }
            else
            {
                fastPoints[i].transform.position = new Vector3(pFastPoints.transform.position.x, fastPoints[i].transform.position.y + disB);
            }
        }
    }
}
