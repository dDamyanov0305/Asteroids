using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float ShotsPerSecond = 10f;
    public GameObject ProjectileToSpawn;
    public Transform SpawnPosition;
    public int guns;

    float NextShotTime = 0;


    private void Update()
    {
        guns = GetComponent<HitReceiver>().health;
    }
    IEnumerator waitUntilShoot()
    {
   
        yield return new WaitForSeconds(3);
    }

    public void Shoot()
    {
        float mult = 0.5f; ;
        GameObject newProjectile;
        StartCoroutine(waitUntilShoot());

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
                //mult *= -1;
                
            }
            /*if (guns > 1)
            {
                
                newProjectile = Instantiate(ProjectileToSpawn, SpawnPosition.position + new Vector3(guns * 0.5f, 0, 0), SpawnPosition.rotation);
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), newProjectile.GetComponent<Collider>());
                newProjectile = Instantiate(ProjectileToSpawn, SpawnPosition.position + new Vector3(-guns * 0.5f, 0, 0), SpawnPosition.rotation);
                GetComponent<AudioSource>().Play();
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), newProjectile.GetComponent<Collider>());
                NextShotTime = Time.time + cooldown;
            }
            else
            {
                newProjectile = Instantiate(ProjectileToSpawn, SpawnPosition.position, SpawnPosition.rotation);
                GetComponent<AudioSource>().Play();
                Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), newProjectile.GetComponent<Collider>());
                NextShotTime = Time.time + cooldown;
            }
            newProjectile = Instantiate(ProjectileToSpawn, SpawnPosition.position, SpawnPosition.rotation);
            GetComponent<AudioSource>().Play();
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), newProjectile.GetComponent<Collider>());
            NextShotTime = Time.time + cooldown;*/
        }
    }
}
