using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Combat;


public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] float distance = 4f;
    PlayerSpriteHandler _sp;
    LayerMask _layer;
    bool _isInteracting = false;

    GameObject _currentInteractable = null;

    private void Awake() {
        _sp = GetComponentInChildren<PlayerSpriteHandler>();  
        _layer = LayerMask.GetMask("Default");
    } 

    private void Update(){
            
        if(Input.GetKeyDown(KeyCode.E) && !_isInteracting){
            TryInteraction(); 
        }
    }

    private void TryInteraction(){
        //raycast to look direction of player
        Vector2 dir = _sp.GetLookDir();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir,distance,_layer);

        if(hit.transform == null) return;
            
        //interacts with obj if it is of type IInteractable
        if(hit.transform.GetComponent<IInteractable>() != null){
            hit.transform.GetComponent<IInteractable>().Interact();
            
            _isInteracting = true;

            _currentInteractable = hit.transform.gameObject;

            //interaction audio
            GameObject.FindObjectOfType<AudioManager>().PlayAudioClip(ClipType.interact);

            //stops player movement (BUG FIX)
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            //player can't move during interaction
            ControllerEnabled(false);
        }

    }   

    public void ControllerEnabled(bool enable){
       GetComponent<PlayerController>().enabled = enable;
       GetComponent<PlayerShoot>().enabled = enable;
    }

    public void SetIsInteracting(bool interacting){
        _isInteracting = interacting;
    }

    public bool GetIsInteracting() {return _isInteracting;}

    public GameObject GetInteractable() {return _currentInteractable;}
}
