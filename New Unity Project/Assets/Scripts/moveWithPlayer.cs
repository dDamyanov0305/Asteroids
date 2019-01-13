using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWithPlayer : MonoBehaviour {

    public GameObject mainPlayer;
	void Awake () {
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
    }
	
	
	void Update () {
        gameObject.transform.position = mainPlayer.transform.position;
	}
}
