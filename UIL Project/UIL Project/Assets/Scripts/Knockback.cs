using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float force = 1f;
    public float knockTime = 1f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy != null) 
            {
                enemy.isKinematic = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * force;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(knockco(enemy));
            }
        }
    }

    private IEnumerator knockco(Rigidbody2D enemy) 
    {
        if (enemy != null) 
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.isKinematic = true;
        }
    } 
}
