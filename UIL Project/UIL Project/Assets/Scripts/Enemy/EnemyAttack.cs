using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage;
    //public LayerMask player;
    public Transform player;
    float attackRadius;
    public bool playerhurt = false;


    private void Start()
    {
        StartCoroutine(LateStart());

    }

    private IEnumerator LateStart()
    {
        yield return new WaitForSeconds(1);
        attackRadius = GetComponentInParent<Enemy>().attackRadius;
    }

    private void Update()
    {
        if(CompareTag("Player"))
        {
            playerhurt = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Attack Player");
        collision.GetComponent<Player>().takeDamage(attackDamage);
        StartCoroutine(CoolDown());
        collision.GetComponent<Player>().takeDamage(attackDamage);


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerhurt = false;
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(.3f);
    }

}
