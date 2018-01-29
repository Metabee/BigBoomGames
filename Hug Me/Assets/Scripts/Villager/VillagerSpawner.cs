using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerSpawner : MonoBehaviour
{
    [Header("Villager:")]
    public GameObject [] villagers;
    public int numberofVillagers;
    public float timetoSpawnVillagers;
    public Road [] roads;
    public int maxVillagersperRoad;
    public int [] villagerCountperRoad;

	// Use this for initialization
	void Start ()
    {
        if ((numberofVillagers / roads.Length) == 0)
        {
            maxVillagersperRoad = (numberofVillagers / roads.Length);
        }
        else
        {
            maxVillagersperRoad = (numberofVillagers / roads.Length) + 1;
        }

        villagerCountperRoad = new int[roads.Length];

        StartCoroutine(VillagersSpawninTime());
        
	}
    void OnDrawGizmosSelected()
    {
        for (int i = 0; i < roads[0].Points.Length; i++)
        {
            Gizmos.color = Color.yellow;

            Gizmos.DrawSphere(roads[0].Points[i], 1);
        }
        for (int i = 0; i < roads[1].Points.Length; i++)
        {
            Gizmos.color = Color.red ;

            Gizmos.DrawSphere(roads[1].Points[i], 1);
        }
        for (int i = 0; i < roads[2].Points.Length; i++)
        {
            Gizmos.color = Color.blue;

            Gizmos.DrawSphere(roads[2].Points[i], 1);
        }
    }

    // Coroutines
    public IEnumerator VillagersSpawninTime()
    {
        for (int i = 0; i < numberofVillagers; i++)
        {
            int r = UnityEngine.Random.Range(0, roads.Length);

            while (villagerCountperRoad[r] + 1 > maxVillagersperRoad)
            {
                r = UnityEngine.Random.Range(0, roads.Length);
            }

            int random = UnityEngine.Random.Range(0, villagers.Length);

            GameObject villagerGameObject = Instantiate(villagers[random], roads[r].Points[0], transform.rotation);

            villagerGameObject.transform.SetParent(gameObject.transform);

            Villager villagerScript = villagerGameObject.GetComponent<Villager>();

            villagerScript.road = roads[r];

            villagerScript.point = roads[r].Points[1];

            villagerScript.pointNumber = 1;

            villagerScript.normal = true;

            villagerScript.StartCoroutine(villagerScript.VillagerMove());

            villagerCountperRoad[r]++;

            yield return new WaitForSeconds(timetoSpawnVillagers);                 
        }
    }
}

[Serializable]
public class Road
{
    public Vector3 [] Points;
}

