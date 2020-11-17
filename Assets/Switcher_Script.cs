using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher_Script : MonoBehaviour
{
    public GameObject[] switches;

    public bool switched = false;

    private void Update()
    {
        switches[0].SetActive(!switched);
        switches[1].SetActive(switched);
    }

    public void Switch()
    {
        switched = !switched;
        
    }

}
