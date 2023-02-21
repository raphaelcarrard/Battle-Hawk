using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    public float speed;
    public Transform targetPoint;

    void Awake()
    {
        targetPoint = GameObject.Find("TargetPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != targetPoint.position){
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        }else{
            transform.GetComponent<BossHealth>().invulnerable = false;
            transform.GetComponent<BossShoot>().isReadyToShoot = true;
        }
    }
}
