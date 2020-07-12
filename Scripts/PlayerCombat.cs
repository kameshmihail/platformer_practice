using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public int attackDamage = 60;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackRate = 1.5f;
    float nextAttackTime = 0f;


    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }

    void Attack()
    {
        animator.SetBool("Jump", false);
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Combat>().TakeDamage(attackDamage);

        }
    }

    void OnDrawGizmoSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}