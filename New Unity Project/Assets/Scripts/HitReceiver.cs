using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReceiver : MonoBehaviour {
	public GameObject ObjectToSpawnOnDeath;
	public GameObject DestructionFX;
    public GameObject powerUpToDrop;

    public float SpawnDistance = 2;
	public float DeflectionAngle = 45;
	public float DestructionFXDuration = 0.5f;
	public bool DebugDraw = false;
    public int health;

    private void Awake()
    {
        health = 1;
    }

    public void ReceiveHit(GameObject damageDealer)
	{
        health--;

        if (health == 0)
        {
            if (ObjectToSpawnOnDeath != null)
		    {
                Vector3 hitDirection = transform.position - damageDealer.transform.position;
			    hitDirection.Normalize();
			    if (DebugDraw) {
				    Debug.DrawLine (damageDealer.transform.position, transform.position, Color.red, 2.0f);
			    }
			    SpawnDeathObject (hitDirection, -DeflectionAngle);
			    SpawnDeathObject (hitDirection, DeflectionAngle);
		    }
		    if (DestructionFX != null) {
                GameObject spawnedFX = Instantiate (DestructionFX, transform.position, Random.rotation);
			    Destroy (spawnedFX, DestructionFXDuration);
		    }
            if(powerUpToDrop != null)
            {
                
                Instantiate(powerUpToDrop, gameObject.transform.position,Quaternion.identity);
            }
		    Destroy (gameObject);
        }

		
	}

	private void SpawnDeathObject(Vector3 hitDirection, float angle)
	{
		Vector3 spawnDirection = Quaternion.AngleAxis (angle, Vector3.up) * hitDirection;
		Vector3 spawnPosition = transform.position + spawnDirection * SpawnDistance;
		if (DebugDraw) {
			Debug.DrawLine (transform.position, spawnPosition, Color.green, 2.0f);
		}

		GameObject spawnedObject = Instantiate(ObjectToSpawnOnDeath, spawnPosition, Random.rotation);
		var asteroidMovementController = spawnedObject.GetComponent<AsteroidMovementController> ();
		if (asteroidMovementController) {
			asteroidMovementController.InitialDirection = spawnDirection;
		}
	}
}
