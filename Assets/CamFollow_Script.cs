using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow_Script : MonoBehaviour
{
    public Transform player;
    public Transform came;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        came.up = player.up;
        came.position = player.position;
        
    }
}
