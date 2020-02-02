using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Vector2 new_maxPosition;
    public Vector2 new_minPosition;

    public Vector3 playerChange;
    private CameraMovement cam;


    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            cam.maxPosition = new Vector2(new_maxPosition.x,new_maxPosition.y);
            cam.minPosition = new Vector2(new_minPosition.x, new_minPosition.y);

            collision.transform.position += playerChange;
        }
    }
}
