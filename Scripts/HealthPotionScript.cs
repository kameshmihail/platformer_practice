using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HealthPotionScript : MonoBehaviour
{
    public Health healthBar;
    public GameObject potionhealth;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && potionhealth.GetComponent<TakeDamageOnCollision>().currentHealth < 5)
        {
            if (potionhealth.GetComponent<TakeDamageOnCollision>().currentHealth < 4)
            {
                potionhealth.GetComponent<TakeDamageOnCollision>().currentHealth += 2;
                Destroy(gameObject);
                healthBar.SetMaxHealth(potionhealth.GetComponent<TakeDamageOnCollision>().currentHealth);
            }
            else
            {
                potionhealth.GetComponent<TakeDamageOnCollision>().currentHealth += 1;
                Destroy(gameObject);
                healthBar.SetMaxHealth(potionhealth.GetComponent<TakeDamageOnCollision>().currentHealth);
            }

        }
    }
}
      
