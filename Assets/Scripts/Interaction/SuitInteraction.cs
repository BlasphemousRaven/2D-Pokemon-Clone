using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitInteraction : MonoBehaviour
{   
    [SerializeField] DoorInteraction door;
    GameObject player;
    bool _casePickedUp = false;


    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        door = FindObjectOfType<DoorInteraction>();
    }
    private void Update(){
        //condition: currently interacting and interacting with suitcase
        bool interactingWithSuitCase = player.GetComponent<PlayerInteraction>().GetIsInteracting()
        && player.GetComponent<PlayerInteraction>().GetInteractable()==this.gameObject;

       //picking up suitcase (or not)
        if(!_casePickedUp && interactingWithSuitCase){
            _casePickedUp = true;
           Invoke("PickUpSuitCase",1.5f); 
           
           //avoids text bug
           FindObjectOfType<TextResetter>().ResetText();
        }
    }

    public void PickUpSuitCase(){
            //destroys suit case after its picked up
            FindObjectOfType<AudioManager>().PlayAudioClip(ClipType.interact);

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false; 

            //activating door
            door.ToggleInfo();  
    }

}
