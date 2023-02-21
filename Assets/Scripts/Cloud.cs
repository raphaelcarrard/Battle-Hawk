using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    public float speed;
    private float maxTop, maxBottom;
    private Vector3 target;

    void Awake()
    {
      InitializeVariables();  
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != target){
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }else{
            Destroy(gameObject);
            GameplayController.instance.InitializeSpawners();
        }
    }

    void InitializeVariables(){
        Vector3 topBound = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
        Vector3 bottomBound = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 temp = transform.position;
        target = new Vector3(0, maxBottom - 20, 0);
        maxTop = topBound.y;
        maxBottom = bottomBound.y;
        temp.y = maxTop + 11;
        transform.position = temp;
    }
}
