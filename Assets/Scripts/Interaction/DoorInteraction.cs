using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    PlayerInteraction playerInteraction;
    private bool _canLeave = false;
    private bool _isLeaving = false;


    private void Awake() => playerInteraction = FindObjectOfType<PlayerInteraction>();

    private void Update(){
        bool interactingWithDoor = playerInteraction.GetIsInteracting()
        && playerInteraction.GetInteractable()==this.gameObject;

        if(interactingWithDoor && _canLeave && !_isLeaving){
            _isLeaving = true;
            print("Peace!");
        }
    }


    public void ToggleInfo(){
        string newInfo = "Lets go!";
        _canLeave = true;
        GetComponent<BasicInteraction>().ChangeObjectInfo(newInfo);
    }
}
