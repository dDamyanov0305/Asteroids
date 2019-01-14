using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float EnemySpeed=0.1f;
    GameObject mainPlayer;
    Vector3 position;

    void Start () {
        mainPlayer = GameObject.FindGameObjectWithTag("Player");
    }

	

    void FixedUpdate()
    {
        if (mainPlayer != null)
        {
            GetComponent<Weapon>().Shoot();
            position = mainPlayer.transform.position;
            
        }
        MoveShip();
    }

    

    void MoveShip()
    {

        Quaternion newRotation = Quaternion.LookRotation(position - transform.position);
        Vector3 direction = new Vector3(-1, 0, 0);
        direction = transform.rotation * direction;
        direction = direction * EnemySpeed * Time.deltaTime;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.MovePosition(transform.position + direction);
        rb.MoveRotation(newRotation);
    }
}
