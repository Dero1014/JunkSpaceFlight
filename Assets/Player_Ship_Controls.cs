using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ship_Controls : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody2D player;

    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();

    }


    Vector2 movement;
    public void AppliedMovement(Vector2 directionKeys, bool switchedPerspective)
    {
        if (directionKeys != Vector2.zero)
        {
            movement = (transform.up * directionKeys.y);
            movement = movement * speed * Time.deltaTime;

            player.AddForce(movement);
        }

        if (switchedPerspective)
        {
            player.velocity = Vector2.zero;
        }



    }

    Vector2 mDir = Vector2.zero;
    public void RotateTowardsMouse(Vector2 mousePosition)
    {
        mDir = (Vector2)transform.position - mousePosition;

        transform.up = -mDir.normalized;

    }

    
 
}
