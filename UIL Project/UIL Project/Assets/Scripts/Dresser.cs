using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dresser : MonoBehaviour
{
    public Animator ani;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ani.SetBool("Clothed", true);
        }

       

    }
}
