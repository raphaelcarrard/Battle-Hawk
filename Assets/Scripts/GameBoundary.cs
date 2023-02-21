using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoundary : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("PlayerBullet") || collider.CompareTag("Enemy") || collider.CompareTag("Coin") || collider.CompareTag("BossBullet")){
            Destroy(collider.gameObject);
        }
    }
}
