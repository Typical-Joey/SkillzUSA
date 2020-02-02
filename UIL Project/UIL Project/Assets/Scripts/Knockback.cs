using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float force;
    public float knockTime;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Breakable"))
        {
            collision.GetComponent<Pot>().Smash();
        }

        if (collision.gameObject.CompareTag("Enemy")) 
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy != null) 
            {
                enemy.GetComponent<Enemy>().currentState = EnemyState.stagger;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * force;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(ResetEnemy(enemy));
                Debug.Log("Coroutine Started");

            }

        }
    }

    private IEnumerator ResetEnemy(Rigidbody2D enemy) 
    {
        Debug.Log("IEnumerator Entered");
        if (enemy != null) 
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.GetComponent<Enemy>().currentState = EnemyState.idle;
        }

    }
}
