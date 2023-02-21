using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed;
    private Rigidbody2D myRigidbody;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement(){
        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, -speed);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")){
            collider.transform.GetComponent<PlayerController>().PlayerDied();
        }
    }
}
