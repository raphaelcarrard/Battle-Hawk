using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public static MusicController instance;

    [HideInInspector]
    public AudioSource audioSource;

    public AudioClip background, gameplay, explode, coin, bossExplode;

    void Awake(){
        audioSource = GetComponent<AudioSource>();
        CreateInstance();
    }

    void CreateInstance(){
        if(instance != null){
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayBackgroundSound(){
        if(background){
            audioSource.clip = background;
            audioSource.volume = 0.5f;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void PlayGameplaySound(){
        if(gameplay){
            audioSource.clip = gameplay;
            audioSource.volume = 0.5f;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void StopAllSound(){
        if(audioSource.isPlaying){
            audioSource.Stop();
        }
    }

    public void PlayerDeath(){
        if(explode){
            audioSource.PlayOneShot(explode);
        }
    }
}
