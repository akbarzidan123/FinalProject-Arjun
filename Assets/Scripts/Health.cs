using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] private float startHealth;
   public GameManager gameManager;
   public float healthNow{get; private set;}

   private void Awake() 
   {
       healthNow = startHealth;
   }

   public void TakeDmg(float _dmg)
   {
       healthNow = Mathf.Clamp(healthNow - _dmg, 0, startHealth);

       if(healthNow > 0)
       {
            //Take DMG but not dead
           
         
       }
       //else
       //{
           //Dieee
       //}
        //if (damage <= 0) return;
        //currentHealth -= damage;

        //playerAS.clip = playerHurt;
        //playerAS.Play();
        //playerAS.PlayOneShot(playerHurt);

       //healthSlider.value = currentHealth;
        //damaged = true;

        if (healthNow <= 0)
        {
           makeDead();
        }
    }
   private void Update() 
   {
           
   }
    public void makeDead()
    {
        Debug.Log("Test dead");
        gameManager.GameOver();
    }
}
