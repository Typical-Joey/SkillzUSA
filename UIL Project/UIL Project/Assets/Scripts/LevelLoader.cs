using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public float transistionTime =  1f;
    public Animator transistion;

    void Update()
    {
        
    }

    public void LoadNextLevel() 
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadNextLevel();
        }
    }

    IEnumerator LoadLevel(int levelIndex) 
    {
        transistion.SetTrigger("Start");

        yield return new WaitForSeconds(transistionTime);

        SceneManager.LoadScene(levelIndex);


    }

}
