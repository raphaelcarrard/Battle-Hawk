using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{

    public GameObject bullet;
    public bool isReadyToShoot, fireBullet;
    private float fireRate, firstDelay, secondDelay;

    // Update is called once per frame
    void Update()
    {
        if(isReadyToShoot){
            fireRate = Random.Range(4, 6);
            firstDelay += Time.deltaTime;
            if(firstDelay >= fireRate){
                if(!fireBullet){
                    fireBullet = true;
                    if(GameObject.FindGameObjectWithTag("Player") != null){
                        GameObject newBullet = Instantiate(bullet, new Vector3(transform.position.x, 0.3f, transform.position.z), Quaternion.identity) as GameObject;
                        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
                        newBullet.GetComponent<Rigidbody2D>().velocity = (target.position - transform.position).normalized * 5f;
                    }else{
                        GameObject newBullet = Instantiate(bullet, new Vector3(transform.position.x, 0.3f, transform.position.z), Quaternion.identity) as GameObject;
                        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f, 1f), -2f);
                    }
                }
            }
            if(fireBullet){
                secondDelay += Time.deltaTime;
                if(secondDelay >= 0.5f){
                    secondDelay = 0;
                    firstDelay = 0;
                    if(GameObject.FindGameObjectWithTag("Player") != null){
                        GameObject newBullet = Instantiate(bullet, new Vector3(transform.position.x, 0.3f, transform.position.z), Quaternion.identity) as GameObject;
                        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
                        newBullet.GetComponent<Rigidbody2D>().velocity = (target.position - transform.position).normalized * 5f;
                    }else{
                        GameObject newBullet = Instantiate(bullet, new Vector3(transform.position.x, 0.3f, transform.position.z), Quaternion.identity) as GameObject;
                        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-0.1f, 0.1f), -2f);
                    }
                    fireBullet = false;
                }
            }
        }
    }
}
