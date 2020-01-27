using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        
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
