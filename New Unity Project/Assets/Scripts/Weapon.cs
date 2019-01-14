using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float ShotsPerSecond = 10f;
    public GameObject ProjectileToSpawn;
    public Transform SpawnPosition;
    public int guns;

    [SerializeField]float NextShotTime;

    private void Start()
    {
        NextShotTime = NextShotTime + Time.time;
    }
    private void Update()
    {
        guns = GetComponent<HitReceiver>().health>3 ? 3 : GetComponent<HitReceiver>().health;
    }
   

    public void Shoot()
    {
        float mult = 0.5f; ;
        GameObject newProjectile;
        

        float cooldown = 1 / ShotsPerSecond;

        if (Time.time > NextShotTime)
        {

            for(int i = 0; i < guns ; i++)
            {
                newProjectile = Instantiate(ProjectileToSpawn, SpawnPosition.position + new Vector3(0 - i * mult, 0, 0), SpawnPosition.rotation);
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), newProjectile.GetComponent<Collider>());

                if (i > 0) {
                    newProjectile = Instantiate(ProjectileToSpawn, SpawnPosition.position + new Vector3(0 + i * mult, 0, 0), SpawnPosition.rotation);
                    Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), newProjectile.GetComponent<Collider>());
                }
                

                GetComponent<AudioSource>().Play();
                NextShotTime = Time.time + cooldown;
                
                
            }
           
        }
    }
}
