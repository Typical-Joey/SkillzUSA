﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool dialogActive;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact") && dialogActive) 
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);

            }
            else 
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {

            dialogActive = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            dialogActive = false;
            dialogBox.SetActive(false);
        }
    }

}
