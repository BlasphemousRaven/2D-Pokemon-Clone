using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] float distance = 4f;
    PlayerSpriteHandler _sp;
    LayerMask _layer;
    bool _isInteracting = false;

    private void Awake() {
        _sp = GetComponentInChildren<PlayerSpriteHandler>();  
        _layer = LayerMask.GetMask("Default");
    } 

    private void Update(){
            
        if(Input.GetKeyDown(KeyCode.E)){
            TryInteraction(); 
        }
    }

    private void TryInteraction(){
        //Raycast vom Spieler in die Richtung, in die er guckt
        Vector2 dir = _sp.GetLookDir();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir,distance,_layer);

        if(hit.transform == null) return;
            
        //interagiert mit dem Objekt, falls dies das IInteractable interface hat
        if(hit.transform.GetComponent<IInteractable>() != null){
            hit.transform.GetComponent<IInteractable>().Interact();
            ControllerEnabled(false);
            _isInteracting = true;
        }

    }   

    public void ControllerEnabled(bool enable){
       GetComponent<PlayerController>().enabled = enable;
    }

    public void SetIsInteracting(bool interacting){
        _isInteracting = interacting;
    }

    public bool GetIsInteracting() {return _isInteracting;}
}
