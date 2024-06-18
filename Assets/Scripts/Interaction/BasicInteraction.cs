using System;
using UnityEngine;
using Game.UI;

public class BasicInteraction : MonoBehaviour,IInteractable
{
    [SerializeField] string objectInformation;
    UITextHandler _uiHandler;
    Canvas canvas;


    private void Awake(){
        _uiHandler = GameObject.FindObjectOfType<UITextHandler>();

        if(_uiHandler==null) return;
        canvas = _uiHandler.transform.parent.GetComponent<Canvas>();
    }

    void IInteractable.Interact(){
        if(canvas == null)return;
        if(!canvas.gameObject.activeSelf){
            canvas.gameObject.SetActive(true);
            StartCoroutine(_uiHandler.Type(objectInformation));
        }
    }

}
