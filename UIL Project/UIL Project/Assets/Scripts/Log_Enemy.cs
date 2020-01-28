using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log_Enemy : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homeRadius;
    public Animator ani;


    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        checkDistance();
    }


    void checkDistance() 
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
}
