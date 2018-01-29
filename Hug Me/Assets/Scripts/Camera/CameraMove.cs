using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform pTrans;
    Vector3 pTransFix;
    [SerializeField]
    Transform downLimit, upLimit, rightLimit, leftLimit;
    float distanceToPlayer;
    Canvas mCanvas;
    // Use this for initialization
    void Start()
    {
        pTrans = GameObject.Find("Character").GetComponent<Transform>();
        mCanvas = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
        mCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        pTransFix = new Vector3(Mathf.Clamp(pTrans.position.x, leftLimit.position.x + 20f, rightLimit.position.x - 20f), Mathf.Clamp(pTrans.position.y, downLimit.position.y + 8f, upLimit.position.y - 8f), transform.position.z);
        distanceToPlayer = Vector3.Distance(pTransFix, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, pTransFix, distanceToPlayer * 5 * Time.deltaTime);
    }

}
