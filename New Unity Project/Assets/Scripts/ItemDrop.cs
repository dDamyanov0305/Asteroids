using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour {

    public GameObject drop;
    private void OnDestroy()
    {

        Instantiate(drop, gameObject.transform.position,gameObject.transform.rotation);
        
    }
}
