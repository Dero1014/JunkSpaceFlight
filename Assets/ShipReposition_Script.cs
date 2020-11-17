using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipReposition_Script : MonoBehaviour
{

    public float maxDistance;

    private Vector2 distance;

    void Update()
    {
        distance = (Vector2)transform.position - Vector2.zero;

        if (distance.magnitude > maxDistance)
        {
            if (transform.position.x > transform.position.y)
            {

            }
        }
    }
}
