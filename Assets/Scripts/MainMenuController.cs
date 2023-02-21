using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public GameObject quitPanel;

    // Start is called before the first frame update
    void Start()
    {
        if(GameController.instance && MusicController.instance){
            if(GameController.instance.isMusicOn){
                MusicController.instance.PlayBackgroundSound();
            }
            else 
            {
                MusicController.instance.StopAllSound();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(!quitPanel.activeInHierarchy){
                quitPanel.SetActive(true);
            }
            else 
            {
                quitPanel.SetActive(false);
            }
        }
    }

    public void StartButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void YesButton(){
        SceneManager.LoadScene("EndGame");
        //Application.Quit();
    }

    public void NoButton(){
        if(quitPanel.activeInHierarchy){
            quitPanel.SetActive(false);
        }
    }
}
