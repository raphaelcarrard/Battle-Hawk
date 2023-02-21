using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningText : MonoBehaviour
{

    private AudioSource audioSource;

    void Awake(){
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWarning(){
        if(GameController.instance != null && MusicController.instance != null){
            if(GameController.instance.isMusicOn){
                if(audioSource.clip != null){
                    audioSource.loop = true;
                    audioSource.Play();
                }
            }
        }
    }

    public void StopWarning(){
        if(audioSource.isPlaying){
            audioSource.Stop();
        }
    }
}
