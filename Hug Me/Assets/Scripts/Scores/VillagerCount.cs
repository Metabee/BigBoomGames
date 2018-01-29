using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VillagerCount : MonoBehaviour {
    public int a = 0;
    int b = 0;
    public VillagerSpawner c;
    public Text d;
	// Use this for initialization
	void Start () {
        b = c.numberofVillagers;
	}
	
	// Update is called once per frame
	void Update () {
        d.text = a.ToString() + " Of " + b.ToString() + " Villagers";
	}
}
