using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBonus : MonoBehaviour {

    
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            
            other.gameObject.GetComponent<HitReceiver>().health++;
            Destroy(gameObject);
        }
    }
}
