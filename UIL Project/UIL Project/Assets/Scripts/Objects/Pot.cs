using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void Smash() 
    {
        ani.SetBool("Smashed", true);
        StartCoroutine(breakco());
    }

    IEnumerator breakco() 
    {
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
    }
}
