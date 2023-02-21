using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider) {
       if(collider.CompareTag("Player")){
        collider.transform.GetComponent<PlayerController>().PlayerDied();
       } 
    }
}
