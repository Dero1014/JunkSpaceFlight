using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRotate_Script : MonoBehaviour
{
    public float angles;
    // Start is called before the first frame update
    void Start()
    {
        int randomAng = Random.Range(0, 360);
        transform.localEulerAngles= new Vector3(0, 0, randomAng);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, angles);
    }
}
