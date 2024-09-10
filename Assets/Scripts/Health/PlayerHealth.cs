using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Health{
public class PlayerHealth : MonoBehaviour,IHealth
{
    int currentHealth;
    [SerializeField] int maxHealth = 100;

    private void Start(){
        //Handle differently... carry over scenes
        currentHealth=maxHealth;
    }

    private void Update(){
        print(currentHealth);
    }

    void IHealth.AddHealth(int amount){
        if(currentHealth+amount>maxHealth){
            currentHealth=maxHealth;
            return;
        }

        currentHealth+=amount;

    }

    void IHealth.ReduceHealth(int amount){
        if(currentHealth-amount<0){
            currentHealth=0;
            //Handle Death
            return;
        }

        currentHealth-=amount;
    }


}

interface IHealth{
    public void AddHealth(int amount){
    }

    public void ReduceHealth(int amount){
    }

}
}
