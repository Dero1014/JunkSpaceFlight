using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Pilot_Controls : MonoBehaviour
{
    public float speed = 0;
    public GameObject img;
    [Space(20)]
    public float radius = 0;
    public LayerMask problemInteract;
    private Rigidbody2D player;

    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();

    }


    Vector2 movement;
    public void AppliedMovementPlayer(Vector2 directionKeys)
    {

        movement = ((transform.up * directionKeys.y) + (transform.right * directionKeys.x)).normalized;
        movement = movement * speed * Time.deltaTime;

        player.velocity = movement;

    }

    public void Interact() 
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, radius, problemInteract);

        if (col.Length!=0)
        {
            img.SetActive(true);
        }
        else
        {
            img.SetActive(false);
        }

        if (Input.GetKeyDown("e"))
        {
            for (int i = 0; i < col.Length; i++)
            {
                if (col[i].GetComponent<Interactable_Script>().interactable && !col[i].GetComponent<Interactable_Script>().interacted)
                {
                    print("Interact");
                    col[i].GetComponent<Interactable_Script>().interacted = true;
                }
            }
        }
        
    }
}
