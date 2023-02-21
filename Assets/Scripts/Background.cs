using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public float speed;
    private Vector2 offset = Vector2.zero;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        InitializeBackground();   
    }

    // Update is called once per frame
    void Update()
    {
        if(GameplayController.instance.startMoving){
            ScrollMovement();
        }
    }

    void InitializeBackground(){
        mat = GetComponent<Renderer>().material;
        offset = mat.GetTextureOffset("_MainTex");
        float height = Camera.main.orthographicSize * 2f;
        float width = height * Screen.width / Screen.height;
        transform.localScale = new Vector3(width, height + 1, transform.position.z);
    }

    void ScrollMovement(){
        offset.y += speed * Time.deltaTime;
        mat.SetTextureOffset("_MainTex", offset);
    }
}
