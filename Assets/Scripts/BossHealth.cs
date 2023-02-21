using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{

    public int maxHealth;
    public Slider health;
    public bool invulnerable;
    public GameObject explode, coin;

    void Awake(){
        InitializeBossVariables();
    }

    void InitializeBossVariables(){
        health.maxValue = maxHealth;
        health.value = maxHealth;
        invulnerable = true;
    }

    public void Health(int damage){
        if(!invulnerable){
            if(!health.gameObject.activeInHierarchy){
                health.gameObject.SetActive(true);
            }
            if(health.value > 0){
                health.value -= damage;
            }
            if(health.value == 0){
                BossDestroyed();
            }
        }
    }

    void BossDestroyed(){
        Destroy(gameObject);
        GameObject.FindGameObjectWithTag("Spawner").transform.GetComponent<EnemySpawner>().active = true;
        GameObject.FindGameObjectWithTag("Spawner").transform.GetComponent<EnemySpawner>().isBossReady = false;
        if(GameController.instance != null && MusicController.instance != null){
            if(GameController.instance.isMusicOn){
                MusicController.instance.audioSource.PlayOneShot(MusicController.instance.bossExplode);
            }
        }
        Instantiate(explode, transform.position, Quaternion.identity);
        for(int i = 0; i < 5; i++){
            Instantiate(coin, transform.position, Quaternion.identity);
        }
    }
}
