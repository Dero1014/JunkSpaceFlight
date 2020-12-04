using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemEngine_Script : MonoBehaviour
{
    public Interactable_Script i_s;
    [Space(10)]
    public EngineMiniGame_Script emg;

    [Space(10)]
    public bool problem = false;

    [Header("Power panel")]
    public Animator p_Anim;

    Vector3 origin;
    void Start()
    {
        i_s = gameObject.GetComponent<Interactable_Script>();
        emg = GameObject.FindObjectOfType<EngineMiniGame_Script>();
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
        print("fIXED");
        p_Anim.SetTrigger("Done");
        FindObjectOfType<AudioManager>().Play("Done");
        problem = false;
        i_s.interactable = false;
        i_s.InputOn();
    }

    public void EngineEncounteredAProblem()
    {
        print("Engine malfunctioned");
        problem = true;
        i_s.interactable = true;
        emg.Reset();
    }
}
