using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject bullet;
    public float speed;
    public AudioClip shoot;

    private float time = 0f;
    private float delay = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if(GameplayController.instance.gameInProgress){
            ShootBullet();
        }
    }

    void ShootBullet(){
        if(GameController.instance != null){
            switch(GameController.instance.weaponLevel){
                case 1:
                    time += Time.deltaTime;
                    if(time >= delay){
                        time = 0;
                        Vector3[] position = new[]{
                            new Vector3(transform.position.x - 0.15f, transform.position.y + 0.4f, 0),
                            new Vector3(transform.position.x + 0.15f, transform.position.y + 0.4f, 0)
                        };
                        for(int i = 0; i < position.Length; i++){
                            GameObject newBullet = Instantiate(bullet, position[i], Quaternion.identity) as GameObject;
                            newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                        }
                        if(GameController.instance != null){
                            if(GameController.instance.isMusicOn){
                                transform.GetComponent<AudioSource>().PlayOneShot(shoot);
                            }
                        }
                    }
                    break;
                case 2:
                    time += Time.deltaTime;
                    if(time >= delay){
                        time = 0;
                        Vector3[] position = new[]{
                            new Vector3(transform.position.x - 0.15f, transform.position.y + 0.4f, 0),
                            new Vector3(transform.position.x + 0.15f, transform.position.y + 0.4f, 0),
                            new Vector3(transform.position.x, transform.position.y + 0.4f, 0)
                        };
                        for(int i = 0; i < position.Length; i++){
                            GameObject newBullet = Instantiate(bullet, position[i], Quaternion.identity) as GameObject;
                            newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                        }
                        if(GameController.instance != null){
                            if(GameController.instance.isMusicOn){
                                transform.GetComponent<AudioSource>().PlayOneShot(shoot);
                            }
                        }
                    }
                    break;
                case 3:
                    time += Time.deltaTime;
                    if(time >= delay){
                        time = 0;
                        Vector3[] position = new[]{
                            new Vector3(transform.position.x - 0.05f, transform.position.y + 0.4f, 0),
                            new Vector3(transform.position.x - 0.15f, transform.position.y + 0.4f, 0),
                            new Vector3(transform.position.x + 0.05f, transform.position.y + 0.4f, 0),
                            new Vector3(transform.position.x + 0.15f, transform.position.y + 0.4f, 0)
                        };
                        for(int i = 0; i < position.Length; i++){
                            GameObject newBullet = Instantiate(bullet, position[i], Quaternion.identity) as GameObject;
                            newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                        }
                        if(GameController.instance != null){
                            if(GameController.instance.isMusicOn){
                                transform.GetComponent<AudioSource>().PlayOneShot(shoot);
                            }
                        }
                    }
                    break;
                case 4:
                    time += Time.deltaTime;
                    if(time >= delay){
                        time = 0;
                        Vector3[] position = new[]{
                            new Vector3(transform.position.x - 0.10f, transform.position.y + 0.4f, 0),
                            new Vector3(transform.position.x - 0.20f, transform.position.y + 0.4f, 0),
                            new Vector3(transform.position.x + 0.10f, transform.position.y + 0.4f, 0),
                            new Vector3(transform.position.x + 0.20f, transform.position.y + 0.4f, 0),
                            new Vector3(transform.position.x, transform.position.y + 0.4f, 0)
                        };
                        for(int i = 0; i < position.Length; i++){
                            GameObject newBullet = Instantiate(bullet, position[i], Quaternion.identity) as GameObject;
                            newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                        }
                        if(GameController.instance != null){
                            if(GameController.instance.isMusicOn){
                                transform.GetComponent<AudioSource>().PlayOneShot(shoot);
                            }
                        }
                    }
                    break;
                case 5:
                    time += Time.deltaTime;
                    if(time >= delay){
                        time = 0;
                        Vector3[] position = new[]{
                            new Vector3(transform.position.x - 0.05f, transform.position.y + 0.4f, 0),
                            new Vector3(transform.position.x - 0.15f, transform.position.y + 0.4f, 0),
                            new Vector3(transform.position.x - 0.25f, transform.position.y + 0.4f, 0),
                            new Vector3(transform.position.x + 0.05f, transform.position.y + 0.4f, 0),
                            new Vector3(transform.position.x + 0.15f, transform.position.y + 0.4f, 0),
                            new Vector3(transform.position.x + 0.25f, transform.position.y + 0.4f, 0)
                        };
                        for(int i = 0; i < position.Length; i++){
                            GameObject newBullet = Instantiate(bullet, position[i], Quaternion.identity) as GameObject;
                            newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                        }
                        if(GameController.instance != null){
                            if(GameController.instance.isMusicOn){
                                transform.GetComponent<AudioSource>().PlayOneShot(shoot);
                            }
                        }
                    }
                    break;
            }
        }
    }
}
