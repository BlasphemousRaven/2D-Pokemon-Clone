/* There should be audio for:   

                                - killing
                                - losing HP
                                - bumping into borders
                                - entering a scene (swoosh)



*/

// ! music wont work if camera set prefab is not in scene
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clips")]
    [SerializeField] AudioClip musicClip;
    [SerializeField] AudioClip shootSFX;
    [SerializeField] AudioClip interactSFX;
    [SerializeField] AudioClip clickSFX;
    [SerializeField] AudioClip wooshSFX;


    private void Start(){
        if(musicSource == null)return;
            musicSource.clip = musicClip;
            musicSource.loop = true;

        if(!musicSource.isPlaying){
            musicSource.Play();
        }

    }

    public void PlayAudioClip(ClipType clipType){
        //making sure there is a sfx source
        if(sfxSource == null){
            Debug.LogError("No sfx audio source! create an audio manager gameobject.");
            return;
        }

        AudioClip sound = null;

        switch(clipType){
            case ClipType.shoot:
            sound = shootSFX;
            break;
            case ClipType.interact:
            sound = interactSFX;
            break;
            case ClipType.click:
            sound = clickSFX;
            break;
            case ClipType.woosh:
            sound = wooshSFX;
            break;
        }

        if(sound == null) return;
        if(sfxSource.isPlaying) return;

        sfxSource.PlayOneShot(sound);
    }
}

public enum ClipType{
    shoot,
    interact,
    click,
    woosh
}