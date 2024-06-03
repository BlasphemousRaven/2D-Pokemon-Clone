using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteraction : MonoBehaviour
{
    public void ExitInteraction(){
        //canvas has to be parent of button
        GameObject canvas = transform.parent.gameObject;

        //enable PlayerController and set isInteracting to false 
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerInteraction>().ControllerEnabled(true);
        player.GetComponent<PlayerInteraction>().SetIsInteracting(false);

        canvas.SetActive(false);
    }

}
