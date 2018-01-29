using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    [Header("Move:")]
    [Range(0,1)]
    public float velocity;
    public Road road;
    public Vector3 point;
    public int pointNumber;

    [Header("States:")]
    public bool normal;
    public float distanceLimit;

    // Use this for initialization
    void Start()
    {

    }

    // Coroutines

    public IEnumerator VillagerMove()
    {
        while (normal)
        {
            if (Vector2.Distance(transform.position, point) > distanceLimit)
            {
                Vector2 direction = (point  - transform.position);

                Vector2 normalizeDirection = velocity * Vector3.Normalize(direction);

                transform.Translate(normalizeDirection);

                yield return new WaitForSeconds(Time.deltaTime);
            }
            else
            {
                pointNumber++;

                if (pointNumber == road.Points.Length)
                {
                    break;
                }

                point = road.Points[pointNumber];
            }
        }

        StopCoroutine("VillagerMove");
    }
}
