using System;
using UnityEngine;
using Game.UI;

public class BasicInteraction : MonoBehaviour,IInteractable
{
    [SerializeField] string objectInformation;
    UITextHandler _uiHandler;
    Canvas canvas;

    private void Start(){
        _uiHandler = GameObject.FindObjectOfType<UITextHandler>();
    }

    void IInteractable.Interact(){
        // activate UI
        // print text or menu


        StartCoroutine(_uiHandler.Type(objectInformation));


    }

}
