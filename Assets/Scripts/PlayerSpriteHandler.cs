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
}
