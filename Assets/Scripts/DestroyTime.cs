using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour
{
    
    void Awake(){
        Destroy(gameObject, 2f);
    }

}
