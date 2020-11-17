using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemPower_Script : MonoBehaviour
{
    public Interactable_Script i_s;
    [Space(10)]

    public PowerMiniGame_Script pm_s;

    [Space(10)]
    public bool problem = false;

    [Header("Battery panel")]
    public Animator p_Anim;

    void Start()
    {
        pm_s = GameObject.FindObjectOfType<PowerMiniGame_Script>();
        i_s = gameObject.GetComponent<Interactable_Script>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ShowPanel()
    {
        //add animation here
        p_Anim.SetTrigger("ShowUp");
    }

    public void Fixed()
    {
        p_Anim.SetTrigger("Done");
        problem = false;
        i_s.interactable = false;
        i_s.InputOn();
    }

    public void PowerEncounteredAProblem()
    {
        print("Power is fucked up");
        pm_s.RandomizeSwitches();
        problem = true;
        i_s.interactable = true;
    }
}

