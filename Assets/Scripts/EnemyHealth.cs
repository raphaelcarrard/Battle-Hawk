using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public Slider health;
    public int maxHealth;
    public GameObject explosion, coin;
    private bool spawn;

    void Awake(){
        health.maxValue = maxHealth;
        health.value = maxHealth;
    }

    public void Health(int damage){
        if(!health.gameObject.activeInHierarchy){
            health.gameObject.SetActive(true);
        }
        if(health.value > 0){
            health.value -= damage;
        }
        if(health.value == 0){
            Destroy(gameObject);
            if(!spawn){
                spawn = true;
                Instantiate(explosion, transform.position, Quaternion.identity);
                Instantiate(coin, transform.position, Quaternion.identity);
            }
        }
    }
}
