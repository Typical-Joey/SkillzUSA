using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState { 
    walk,
    attack,
    interact

}


public class Player : MonoBehaviour
{
    public float speed = 3;
    private Rigidbody2D rb;
    private Vector3 change;
    private Animator ani;
    public PlayerState currentState;

    public int maxHealth;
    private int currentHealth;

    public bool key = false;



    void Start()
    {
        currentHealth = maxHealth;
        currentState = PlayerState.walk;
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        ani.SetFloat("x", 0);
        ani.SetFloat("y", -1);
    }

    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump") && currentState != PlayerState.attack)
        {
            StartCoroutine(Attackco());
        }else if (currentState == PlayerState.walk) 
        {
            playAnimation();
        }
        if(Input.GetButtonDown("Kill")) 
        {
            Debug.Log("Player Died");
            Die();
        }
    }


    private IEnumerator Attackco() 
    {
        ani.SetBool("Attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        ani.SetBool("Attacking", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;

    }


    void MovePlayer()
    {
        change.Normalize();
        rb.MovePosition(transform.position + change * speed * Time.deltaTime);
    }


    void playAnimation() 
    {
        if (change != Vector3.zero)
        {
            MovePlayer();
            ani.SetFloat("x", change.x);
            ani.SetFloat("y", change.y);
            ani.SetBool("walking", true);
        }else
        {
            ani.SetBool("walking", false);
        }

    }


    // Taking Damage
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

        speed = 0;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        SceneManager.LoadScene(1);
    }




}
