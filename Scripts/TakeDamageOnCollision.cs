using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public Health healthBar;

    public float thrust = 1.0f;
    public Rigidbody2D rb;

    public float force = 15;
    public ForceMode2D forceMode = ForceMode2D.Impulse;

    public GameObject controller;

    public Animator animator;

    public bool invincible = false;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        
    }

void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.tag == "Enemy")
         {
            if (!invincible)
            {
                TakeDamage(1);
            }
             

            ContactPoint2D contactPoint = collision.GetContact(0);
            Vector2 playerPosition = transform.position;
            Vector2 dir = contactPoint.point - playerPosition;

            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;

            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().inertia = 0;

            controller.GetComponent<PlayerMovement>().AllowInput = false;
            invincible = true;
            Invoke("EnablePlayerControles", 0.7f);

            //---------------------------------------------------------------------------------------------------------//
            //If the problme is not resolved then lock controle key. "playerControles" is a public static boolean which you have declare in the player controller script with true. then in this script you have to enable it or disable it.like
             //if then amount of time is long then reduce it to the value you want.

            //Also in your player controller script wrap the inputs inside if condition like this if(playerControles){//input/inputs code}.
            //---------------------------------------------------------------------------------------------------------//

            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            GetComponent<Rigidbody2D>().AddForce(dir * force, forceMode);
            /*           Vector3 hit = col.contacts[0].normal;
                       float angle = Vector3.Angle(hit, Vector3.up);
                      rb = GetComponent<Rigidbody2D>();
                      transform.position = new Vector3(0.0f, -0.2f, 0.0f);
                      rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);

                      if (Mathf.Approximately(angle, 0))
                       {
                          rb = GetComponent<Rigidbody2D>();
                          transform.position = new Vector3(0.0f, 0.0f, 1.0f);
                          rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
                          //Down
                          Debug.Log("Down");
                       }
                       if(Mathf.Approximately(angle, 180))
                       {
                          rb = GetComponent<Rigidbody2D>();
                          transform.position = new Vector3(0.0f, 0.0f, 1.0f);
                          rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
                          //Up
                          Debug.Log("Up");
                       }
                       if(Mathf.Approximately(angle, 90)){
                           // Sides
                           Vector3 cross = Vector3.Cross(Vector3.forward, hit);
                           if (cross.y > 0)
                           { // left side of the player
                              rb = GetComponent<Rigidbody2D>();
                              transform.position = new Vector3(0.0f, 1.0f, 1.0f);
                              rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
                              Debug.Log("Left");
                           }
                           else
                           { // right side of the player
                              rb = GetComponent<Rigidbody2D>();
                              transform.position = new Vector3(1.0f, 0.0f, 0.0f);
                              rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
                              Debug.Log("Right");
                           }
                       } */
        }
     }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
       
        healthBar.SetMaxHealth(currentHealth);
        animator.SetTrigger("Hurt");

            if(currentHealth <= 0)
            {
                Die();
            } 
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        this.enabled = false;
        Destroy(gameObject, 1);
    }
    void EnablePlayerControles()
    {
        controller.GetComponent<PlayerMovement>().AllowInput = true;
        invincible = false;
    }
}

