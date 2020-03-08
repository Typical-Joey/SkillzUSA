using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseArea : MonoBehaviour
{
    Transform target;
    Rigidbody2D enemy_rb;
    float moveSpeed;
    

    private void Start()
    {
        enemy_rb = GetComponentInParent<Rigidbody2D>();
        moveSpeed = GetComponent<Enemy>().moveSpeed;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(CompareTag("Player"))
        {
            Debug.Log("Player in range  ");
            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
            enemy_rb.MovePosition(temp);
        }
    }
}
