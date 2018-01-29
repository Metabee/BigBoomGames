using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    [Header("Life Time:")]
    public Slider lifeBar;
    public float lifeTime;
    public float fireAmount;

    public bool canDownLife;
    public bool death;
    public Text mText;
    public Image mRender;

    // Update is called once per frame
    void Update()
    {
        if (canDownLife)
        {
            fireAmount -= ((Time.deltaTime) / lifeTime);

            fireAmount = Mathf.Clamp(fireAmount, 0, 1);

            lifeBar.value = fireAmount;

            if (lifeBar.value <= 0)
            {
                if (!death)
                {
                    death = true;

                    GetComponent<Character>().canMove = false;

                    GetComponent<Animator>().SetBool("Death", true);

                    StartCoroutine(EndParticles());

                    StartCoroutine(PassScene());

                    
                }

            }
        }
    }
    public IEnumerator EndParticles()
    {
        yield return new WaitForSeconds(10);

        transform.GetChild(0).gameObject.SetActive(false);

        StopCoroutine("EndParticles");
    }
    public IEnumerator PassScene()
    {
        yield return new WaitForSeconds(1.2f);

        mText.gameObject.SetActive(true);

        mRender.gameObject.SetActive(true);

        StartCoroutine("PassScene2");

        StopCoroutine("PassScene");
    }
    public IEnumerator PassScene2()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(1);
    }
}
