using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteHandler : MonoBehaviour
{   
    private PlayerController _controller;
    SpriteRenderer _sr;

    [SerializeField] Sprite upSprite;
    [SerializeField] Sprite downSprite;
    [SerializeField] Sprite leftSprite;
    [SerializeField] Sprite rightSprite;

    private void Awake(){
        _controller = GetComponentInParent<PlayerController>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update(){
        Vector2 dir = _controller.GetMoveDir();

        float x = dir.x;
        float y = dir.y;

        //Spieler guckt nach oben oder unten
        if(y > 0){
            _sr.sprite = upSprite;
        }
        else if(y < 0){
            _sr.sprite = downSprite;
        }

        //Spieler guckt nach links oder rechts
        if(x > 0){
            _sr.sprite = rightSprite;
        }
        else if(x < 0){
            _sr.sprite = leftSprite;
        }
        
    }

    //Richtung, in die der Spieler guckt, als Vektor
    public Vector2 GetLookDir(){
        if(_sr.sprite == upSprite){
            return new Vector2(0,1);
        }
        else if(_sr.sprite == downSprite){
            return new Vector2(0,-1);
        }
        else if(_sr.sprite == leftSprite){
            return new Vector2(-1,0);
        }
        else if(_sr.sprite == rightSprite){
            return new Vector2(1,0);
        }

        //Falls der Spieler kein 'Sprite' hat, wird ein Nullvektor returned
        Debug.LogError("Spieler hat kein Sprite");
        return Vector2.zero;
    }
}
