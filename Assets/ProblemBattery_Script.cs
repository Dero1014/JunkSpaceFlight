using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemBattery_Script : MonoBehaviour
{
    public Interactable_Script i_s;
    [Space(10)]

    [Space(10)]
    public bool problem = false;

    [Header("Battery panel")]
    public Animator b_Anim;

    Vector3 origin;
    void Start()
    {
        i_s = gameObject.GetComponent<Interactable_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void ShowPanel()
    {
        //add animation here
        b_Anim.SetTrigger("ShowUp");
    }

    public void Fixed()
    {
        b_Anim.SetTrigger("Done");
        FindObjectOfType<AudioManager>().Play("Done");
        problem = false;
        i_s.interactable = false;
        i_s.InputOn();
    }

    public void BatteryEncounteredAProblem()
    {
        print("Battery is overloaded");
        problem = true;
        i_s.interactable = true;
    }
}
