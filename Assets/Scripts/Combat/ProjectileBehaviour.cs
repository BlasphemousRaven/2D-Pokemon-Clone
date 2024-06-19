using System.Collections;
using UnityEngine;

namespace Game.Combat{
    public class ProjectileBehaviour : MonoBehaviour
    {
        [SerializeField] float projectileSpeed = 15f;
        Vector2 _lookDir = Vector2.zero;

        private void Start() => _lookDir = GameObject.FindObjectOfType<PlayerSpriteHandler>().GetLookDir();

        private void Update(){
            transform.Translate(projectileSpeed*_lookDir*Time.deltaTime);
        }

        // TODO projectile Death On Collision
         
    }
}
