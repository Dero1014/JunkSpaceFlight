using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMiniGame_Script : MonoBehaviour
{
    public Switcher_Script[] switches;
    public ProblemPower_Script pp;

    public bool fix = true;

    void Start()
    {
        switches = gameObject.GetComponentsInChildren<Switcher_Script>();
        pp = GameObject.FindObjectOfType<ProblemPower_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!fix)
        {
            int n = 0;
            for (int i = 0; i < switches.Length; i++)
            {

                if (switches[i].switched)
                {
                    fix = false;
                    break;
                }

                n++;
            }

            if (n == 6)
            {
                fix = true;
                print("Fixed");
                pp.Fixed();
            }
        }
       


    }

    public void RandomizeSwitches()
    {
        for (int i = 0; i < 4; i++)
        {
            int ran = Random.Range(0, 6);

            switches[ran].switched = true;

        }

        fix = false;
    }
}
