using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour {
	public string TagToHit = "Enemy";
    public GameController gameController;
    public int scoreValue;

    void Awake()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagToHit))
        {

            if (!other.gameObject.CompareTag("Player"))
            {
                if(other.gameObject.GetComponent<HitReceiver>().health == 1)
                {
                    gameController.AddScore(other.gameObject.GetComponent<DamageDealer>().scoreValue);
                }
                
            }
            
            HitReceiver hitReceiver = gameObject.GetComponent<HitReceiver>();
            HitReceiver hitReceiverOther = other.gameObject.GetComponent<HitReceiver>();
            Destroy(gameObject);
            if (hitReceiver)
            {
                hitReceiver.ReceiveHit(gameObject);
                
            }
            if(!hitReceiverOther)
            {
                Destroy(other.gameObject);
            }
            else
            {
                hitReceiverOther.ReceiveHit(gameObject);
            }


        }
    }
    
}
