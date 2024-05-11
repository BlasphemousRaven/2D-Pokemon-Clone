using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBreathingAnimation : MonoBehaviour
{
    
    [SerializeField] float scaleMax = 1.55f;
    [SerializeField] float lerpingSpeed = .9f;
    private float _percentageComplete = 0f;
    private float _scaleFactor = 0;
    private float _startingScale;
    private bool isAscending = true;
    
    private void Start(){
        _startingScale = transform.localScale.x;
    }

    private void Update(){

        if(isAscending){
            LerpUp();
        }
        else{
            LerpDown();
        }
    
        transform.localScale = new Vector3(_scaleFactor,_scaleFactor);
    }

    private void LerpUp(){
        _percentageComplete += Time.deltaTime/lerpingSpeed;
        _scaleFactor = Mathf.Lerp(_startingScale,scaleMax,_percentageComplete);

        if(_percentageComplete>= 1f){
            isAscending = false;
            _percentageComplete = 0f;
        }

    }

    private void LerpDown(){
        _percentageComplete += Time.deltaTime/lerpingSpeed;
        _scaleFactor = Mathf.Lerp(scaleMax,_startingScale,_percentageComplete);

        if(_percentageComplete >= 1f){
            isAscending = true;
            _percentageComplete = 0f;
        }
    }


}
