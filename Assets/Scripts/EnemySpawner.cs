using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemies;
    public GameObject[] boss;
    public int count, maxCount;
    public bool active, isBossReady;
    public float time;

    private float delay;
    private float maxTop;

    // Start is called before the first frame update
    void Start()
    {
        InitializeVariables();
        LimitBounds();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameplayController.instance.gameInProgress){
            LimitBounds();
            SpawnEnemies();
            CheckedEnemies();
        }
    }

    void SpawnEnemies(){
        if(active){
            if(count != 0){
                delay = 3;
                Vector3[] position = new[]{
                    new Vector3(-2, maxTop, 0),
                    new Vector3(-1, maxTop, 0),
                    new Vector3(0, maxTop, 0),
                    new Vector3(1, maxTop, 0),
                    new Vector3(2, maxTop, 0)
                };
                time += Time.deltaTime;
                if(time > delay){
                    delay = Random.Range(3, 8);
                    int randomEnemy = Random.Range(0, position.Length);
                    time = 0;
                    for(int i = 0; i < position.Length; i++){
                        if(i != randomEnemy){
                            Instantiate(enemies[0], position[i], Quaternion.Euler(0, 0, 180));
                        }else{
                            Instantiate(enemies[1], position[i], Quaternion.Euler(0, 0, 180));
                        }
                    }
                    count--;
                }
            }else{
                active = false;
            }
        }else{
            count = maxCount;
        }
    }

    void LimitBounds(){
        Vector3 topBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
        maxTop = topBoundary.y;
    }

    void CheckedEnemies(){
        if(!active){
            if(GameObject.FindGameObjectWithTag("Enemy") == null){
                if(!isBossReady){
                    isBossReady = true;
                    GameplayController.instance.ShowWarning();
                }
            }
        }
    }

    public void SpawnBoss(){
        Instantiate(boss[0], new Vector3(0, maxTop + 3, 0), Quaternion.Euler(0, 0, 180));
    }

    public void InitializeVariables(){
        count = maxCount;
        time = 0f;
        active = true;
        isBossReady = false;
    }
        
}
