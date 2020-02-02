using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState { 
    walk,
    attack,
    interact

}


public class PlayerMovement : MonoBehaviour
{
    public float speed = 3;
    private Rigidbody2D rb;
    private Vector3 change;
    private Animator ani;
    public PlayerState currentState;
    public int health;


    void Start()
    {
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


}
