using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState 
{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;

    public int maxHealth;
    private int currentHealth;

    public float moveSpeed;

    public Transform target;
    private Rigidbody2D rb;
    public Animator ani;
    
    public float chaseRadius;
    public float attackRadius;
   


    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentState = EnemyState.idle;
    }



    void FixedUpdate()
    {
        checkDistance();
    }


    // Enemy AI
    void checkDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {

                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);

                rb.MovePosition(temp);
                changeState(EnemyState.walk);
            }
        }
    }



    private void changeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }


    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        moveSpeed = 0;
        GetComponent<Collider2D>().enabled = false;
        Destroy(this);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponentInChildren<Collider2D>().enabled = false;
    }


}
