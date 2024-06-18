/* There should be audio for:   - background music 

                                - shooting
                                - interacting with an object
                                - exiting interaction
                                - interacting with key objects (suitcase)
                                - killing
                                - losing HP
                                - bumping into borders
                                - entering a scene



*/



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


}
