using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordProblems_Script : MonoBehaviour
{
    public Player_Input pi;
    [Header("Battery")]
    public ProblemBattery_Script bat;
    public Slider gunSlider;
    public Gradient grad;
    public Image fill;
    [Space(10)]

    public bool batteryProblem;
    public float overHeatTime;
    public float overHeatSpeed;
    public float coolSpeed;

    private float timeToOverHeat = 0;

    [Space(20)]

    [Header("Power")]
    public ProblemPower_Script pow;
    public GameObject problemText;

    public bool powerProblem;
    public float shortageTime;
    public int setChance;

    private float timeToShortage;

    [Header("Engine")]
    public ProblemEngine_Script eng;
    public Slider engineSlider;
    public Gradient gradEngine;
    public Image fillEngine;

    public bool engineProblem;
    public float malfunctionTime;
    public float malfunctionSpeed;

    private float timeToMalfunction;

    void Start()
    {
        pi = gameObject.GetComponent<Player_Input>();

        bat = gameObject.GetComponentInChildren<ProblemBattery_Script>();
        pow = gameObject.GetComponentInChildren<ProblemPower_Script>();
        eng = gameObject.GetComponentInChildren<ProblemEngine_Script>();
    }

    void Update()
    {
        BatteryCooling();
        PowerShortage();
        EngineMalfunction();
    }

    void BatteryCooling()
    {

        if (Input.GetMouseButton(0) && !batteryProblem && !pi.switchPerspective)
        {
            if (timeToOverHeat < overHeatTime)
            {
                timeToOverHeat += Time.deltaTime * overHeatSpeed;
            }
            else
            {
                batteryProblem = true;

                if (!bat.problem)
                    bat.BatteryEncounteredAProblem();

                timeToOverHeat = overHeatTime;
            }
        }
        else
        {
            if (!batteryProblem)
            {
                if (timeToOverHeat > 0)
                    timeToOverHeat -= Time.deltaTime * coolSpeed;
                else
                    timeToOverHeat = 0;
            }
        }

        if (batteryProblem)
        {
            batteryProblem = bat.problem;

            if (!batteryProblem)
            {
                timeToOverHeat = 0;
            }
        }

        gunSlider.value = timeToOverHeat / overHeatTime;
        fill.color = grad.Evaluate(gunSlider.value);

    }

    void PowerShortage()
    {
        if (!powerProblem)
        {
            if (timeToShortage < shortageTime)
            {
                timeToShortage += Time.deltaTime * 1;
            }
            else
            {
                int ran = Random.Range(0, 100);

                if (ran < setChance)
                {
                    powerProblem = true;
                    pow.PowerEncounteredAProblem();
                    print("PowerTrue");
                }
                else
                {
                    print("PowerFalse");
                }

                timeToShortage = 0;
            }
        }
        

        if (powerProblem)
        {
            powerProblem = pow.problem;
        }
        problemText.SetActive(powerProblem);

    }

    void EngineMalfunction()
    {
        if (!engineProblem)
        {
            if ((Input.GetButton("Vertical") && !pi.switchPerspective))
            {
                if (timeToMalfunction < malfunctionTime)
                {
                    timeToMalfunction += Time.deltaTime * malfunctionSpeed;
                }
                else
                {
                    engineProblem = true;
                    eng.EngineEncounteredAProblem();
                    timeToMalfunction = 0;
                }
            }
        }

        engineSlider.value = timeToMalfunction / malfunctionTime;
        fillEngine.color = gradEngine.Evaluate(engineSlider.value);

        if (engineProblem)
        {
            engineSlider.value = 1;
            fillEngine.color = gradEngine.Evaluate(1);
            engineProblem = eng.problem;
        }
    }



}
