using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log_Enemy : Enemy
{
    private Rigidbody2D rb;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homeRadius;
    public Animator ani;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentState = EnemyState.idle;
    }

    void FixedUpdate()
    {
        checkDistance();

    }


    void checkDistance() 
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
       {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

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
}
