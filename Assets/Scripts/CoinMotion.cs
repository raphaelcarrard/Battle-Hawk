using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMotion : MonoBehaviour
{
    
    private Rigidbody2D myRigidbody;
    private float force = 5f;

    void Awake(){
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.AddForce(new Vector2(Random.Range(-0.5f, 0.5f), force), ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")){
            Destroy(gameObject);
            if(GameController.instance != null && MusicController.instance != null){
                if(GameController.instance.isMusicOn){
                    MusicController.instance.audioSource.PlayOneShot(MusicController.instance.coin);
                }
            }
            GameplayController.instance.UpdateCoins();
        }
    }
}
