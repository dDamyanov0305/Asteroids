using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayShield : MonoBehaviour {


    public GameObject shield;

    void Start()
    {
        shield = GameObject.Find("PowerUp");
    }

    void Update () {
        if (GetComponent<HitReceiver>().health > 1)
        {
           shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
	}
}
