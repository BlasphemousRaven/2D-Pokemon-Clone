using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitInteraction : MonoBehaviour
{
    GameObject player;
    bool _casePickedUp = false;

    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update(){
        if(player.GetComponent<PlayerInteraction>().GetIsInteracting()){
           PickUpSuitCase(); 
        }
    }

    public void PickUpSuitCase(){
        if(Input.GetKeyDown(KeyCode.Space)){
            //destroys suit case after its picked up
            _casePickedUp = true;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public bool GetCasePickedUp(){return _casePickedUp;}
}
