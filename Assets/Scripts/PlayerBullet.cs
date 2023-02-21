using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    
    public int damage;
    public GameObject hit;

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Enemy")){
            Instantiate(hit, transform.position, Quaternion.identity);
            collider.transform.GetComponent<EnemyHealth>().Health(damage);
            Destroy(gameObject);
        }
        if(collider.CompareTag("Boss")){
            Instantiate(hit, transform.position, Quaternion.identity);
            collider.transform.GetComponent<BossHealth>().Health(damage);
            Destroy(gameObject);
        }
    }
}
