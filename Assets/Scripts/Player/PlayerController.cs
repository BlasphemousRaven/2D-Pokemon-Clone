using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
  [SerializeField] float playerSpeed = 15f;
  Rigidbody2D _rigidbody;
  Vector2 _moveDir = Vector2.zero;

  private void Awake() => _rigidbody = GetComponent<Rigidbody2D>();
  
  private void Update(){
     GetInput();
  }
   private void FixedUpdate(){    
      MovePlayer();
   }

  private void GetInput(){
    float xInput = Input.GetAxisRaw("Horizontal");
    float yInput = Input.GetAxisRaw("Vertical");

    //kein Input
    if(xInput == 0 && yInput == 0){
      _moveDir = new Vector2(0,0);
    }

    //links - rechts
    if(xInput>0){
      _moveDir = new Vector2(1,0);
    }
    else if(xInput<0){
      _moveDir = new Vector2(-1,0);
    }
    
    //hoch - runter
    if(yInput>0){
      _moveDir = new Vector2(0,1);
    }
    else if(yInput<0){
      _moveDir = new Vector2(0,-1);
    }
  
  }

  private void MovePlayer(){
    //bewegt den Spieler
    _rigidbody.velocity = _moveDir * playerSpeed;
  }
  public Vector2 GetMoveDir(){
    return _moveDir;
  } 
}