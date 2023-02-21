using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public GameObject explosion;
    private Vector3 position, realPos;
    private float maxLeft, maxRight;
    private AudioSource audioSource;

    void Awake(){
        InitializePlayerVariables();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(GameController.instance != null && MusicController.instance != null){
            if(GameController.instance.isMusicOn){
                audioSource.Play();
            }else{
                audioSource.Stop();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameplayController.instance.gameInProgress){
            LimitPosition();
            if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.LinuxPlayer || Application.platform == RuntimePlatform.WebGLPlayer){
                PlayerMovement();
            }else if(Application.platform == RuntimePlatform.Android){
                TouchMovement();
            }
        }
    }

    void PlayerMovement(){
        if(Input.GetKey(KeyCode.LeftArrow)){
            position.x -= speed * Time.deltaTime;
        }else if(Input.GetKey(KeyCode.RightArrow)){
            position.x += speed * Time.deltaTime;
        }
        position.x = Mathf.Clamp(position.x, maxLeft + 0.5f, maxRight - 0.5f);
        transform.position = position;
    }

    void TouchMovement(){
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Began){
                Vector3 fingerPos = touch.position;
                position.x = fingerPos.x;
                realPos = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, position.z));
                transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(realPos.x, maxLeft + 0.5f, maxRight - 0.5f), transform.position.y, transform.position.z), Time.deltaTime * speed);
            }
            if(touch.phase == TouchPhase.Moved){
                Vector3 fingerPos = touch.position;
                position.x = fingerPos.x;
                realPos = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, position.z));
                transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(realPos.x, maxLeft + 0.5f, maxRight - 0.5f), transform.position.y, transform.position.z), speed);
            }
        }
    }

    void LimitPosition(){
        Vector3 leftBound = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
        Vector3 rightBound = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, Camera.main.transform.position.z));
        maxLeft = leftBound.x;
        maxRight = rightBound.x;
    }

    void InitializePlayerVariables(){
        position = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayerDied(){
        if(GameController.instance != null && MusicController.instance != null){
            if(GameController.instance.isMusicOn){
                MusicController.instance.PlayerDeath();
            }
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        GameplayController.instance.GameOver();
    }
}
