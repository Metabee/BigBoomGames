using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    // SPECIAL THANKS TO OLARTE
    AudioSource mBGM;
    public AudioClip mMain_Theme;
    public AudioClip mMain_Theme_Crop;

    private void Awake()
    {
        mBGM = GetComponent<AudioSource>();
    }


    // Use this for initialization
    void Start()
    {
        mBGM.PlayOneShot(mMain_Theme);
    }

    // Update is called once per frame
    void Update()
    {
        if (mBGM.clip == mMain_Theme && !mBGM.isPlaying)
        {
            print("putos");
            mBGM.clip = mMain_Theme_Crop;
            mBGM.Play();
            mBGM.loop = true;

            StartCoroutine(ChangePitch());

        }

    }
    public IEnumerator ChangePitch()
    {
        while (true)
        {
            mBGM.pitch += Random.Range(-1, 2);

            yield return new WaitForSeconds(mMain_Theme_Crop.length);
        }
    }
}
