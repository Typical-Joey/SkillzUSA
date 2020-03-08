using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage;

    //public Transform attackArea;
    public float attackRange = 1f;
    public LayerMask enemy;




    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Attack();
        }
    }


    public void Attack()
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(transform.position, attackRange, enemy);

        foreach (Collider2D enemy in hitEnemy)
        {
            Debug.Log("Hit Enemy");
            enemy.GetComponent<Enemy>().takeDamage(attackDamage);
            StartCoroutine(attackCoolDown());

        }
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


    IEnumerator attackCoolDown()
    {
        yield return new WaitForSeconds(.5f);
    }



}
