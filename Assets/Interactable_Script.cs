using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Script : MonoBehaviour
{
    public Player_Input p_i;

    public ProblemBattery_Script pb;
    public ProblemPower_Script pp;
    public ProblemEngine_Script pe;

    public bool interactable = false;
    public bool interacted = false;

    [Header("ProblemFocus")]
    public bool battery;
    public bool power;
    public bool engine;

    void Start()
    {
        p_i = gameObject.GetComponentInParent<Player_Input>();
        pb = gameObject.GetComponent<ProblemBattery_Script>();
        pp = gameObject.GetComponent<ProblemPower_Script>();
        pe = gameObject.GetComponent<ProblemEngine_Script>();
    }

    void Update()
    {
        if (interacted)
        {
            p_i.enabled = false;

            if (battery)
            {
                pb.ShowPanel();
            }

            if (power)
            {
                pp.ShowPanel();
            }

            if (engine)
            {
                pe.ShowPanel();
            }

            print("Interacted");
            interacted = !interacted;
        }

    }

    public void InputOn()
    {
        p_i.enabled = true;
    }
}
