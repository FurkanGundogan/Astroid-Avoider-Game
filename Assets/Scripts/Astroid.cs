using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
       PlayerHealth ph = other.GetComponent<PlayerHealth>();
       if(ph == null){return;}

       ph.Crash();
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
   
}
