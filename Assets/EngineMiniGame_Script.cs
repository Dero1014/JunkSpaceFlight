using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineMiniGame_Script : MonoBehaviour
{
    public Slider lever;
    public ProblemEngine_Script pe;
    public bool fix = true;

    void Start()
    {
        pe = GameObject.FindObjectOfType<ProblemEngine_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!fix)
        {
            if (lever.value == 1)
            {
                fix = true;
                pe.Fixed();
            }
        }
        
    }

    public void Reset()
    {
        lever.value = 0;
        fix = false;
    }

}
