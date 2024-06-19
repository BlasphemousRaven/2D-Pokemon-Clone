using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Combat{
    public class PlayerShoot : MonoBehaviour
    {   
        [Header("Projectile Information")]
        [SerializeField] GameObject projectilePrefab;  
        [SerializeField] float projectileLifetime = 7.5f;

        AudioManager audioManager;

        private void Awake() => audioManager = FindObjectOfType<AudioManager>();

        private void Update(){
            if(Input.GetMouseButtonDown(0)){

                //AUDIO
                if(audioManager != null){
                    audioManager.PlayAudioClip(ClipType.shoot);
                }
                else{
                    Debug.LogError("no audiomanager in scene");
                }
                

                var proj = Instantiate(projectilePrefab,transform.position,projectilePrefab.transform.rotation);
                //prevents projectile from infinite lifetime
                Destroy(proj, projectileLifetime);
            }
        }
    }
}
