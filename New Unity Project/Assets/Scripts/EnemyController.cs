using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float EnemySpeed=0.1f;
    GameObject mainPlayer;

    void Start () {
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
    }

	void Update () {
 
        GetComponent<Weapon>().Shoot();

    }

    void FixedUpdate()
    {
        if (mainPlayer != null)
        {
            MoveShip();
        }
        
    }

    

    void MoveShip()
    {

        Quaternion newRotation = Quaternion.LookRotation(mainPlayer.transform.position - transform.position);
        Vector3 direction = new Vector3(-1, 0, 0);
        direction = transform.rotation * direction;
        direction = direction * EnemySpeed * Time.deltaTime;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.MovePosition(transform.position + direction);
        rb.MoveRotation(newRotation);
    }
}
