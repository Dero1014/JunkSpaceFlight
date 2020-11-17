using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    public RecordProblems_Script problemsReport;
    public Player_Ship_Controls p_s;
    public Player_Pilot_Controls p_p;
    public Player_Switch p_switch;
    public Player_Muzzle p_muzzle;
    [Space(10)]
    public Transform graphic;

    private Vector2 directionKeys;
    private Vector2 mousePosition;

    private bool shoot;
    [HideInInspector]public bool switchPerspective = false;

    Vector2 origin;

    void Start()
    {
        problemsReport = gameObject.GetComponent<RecordProblems_Script>();
        p_s = gameObject.GetComponent<Player_Ship_Controls>();
        p_p = gameObject.GetComponentInChildren<Player_Pilot_Controls>();
        p_muzzle = gameObject.GetComponent<Player_Muzzle>();
        p_switch = gameObject.GetComponent<Player_Switch>();

        origin = p_p.gameObject.transform.localPosition;
    }

    void Update()
    {
        directionKeys = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown("r"))
        {
            switchPerspective = !switchPerspective;

            p_p.GetComponent<Rigidbody2D>().simulated = switchPerspective;

            if (switchPerspective)
                p_s.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            else
                p_s.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            p_switch.SwitchPerspective(switchPerspective);
        }

        if (!switchPerspective)
        {
            PutPlayerBackInChair();
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButton(0) && (!problemsReport.batteryProblem && !problemsReport.powerProblem) )
                shoot = true;
            else
                shoot = false;

            if (Input.GetMouseButtonDown(0) && (!problemsReport.batteryProblem && !problemsReport.powerProblem))
                p_muzzle.JustShootOnce();
        }
        else
        {
            //interaction with ship
            
        }
        p_p.Interact();

        UpOtherDates();
        GraphicsManipulation();
    }

    private void FixedUpdate()
    {
        if (!switchPerspective && (!problemsReport.powerProblem) && !problemsReport.engineProblem)
        {
            p_s.AppliedMovement(directionKeys, switchPerspective);
        }
        else
        {
            p_s.AppliedMovement(Vector2.zero, switchPerspective);
            p_p.AppliedMovementPlayer(directionKeys);
        }
    }

    private float waitASec = 0;
    private void UpOtherDates()
    {
        p_muzzle.Shoot(shoot);
        if (waitASec<1 && !switchPerspective)
        {
            waitASec += Time.deltaTime;
        }

        if (!switchPerspective && waitASec>1)
        {
            p_s.RotateTowardsMouse(mousePosition);
        }

        if (switchPerspective)
        {
            waitASec = 0;
        }
    }

    private void GraphicsManipulation()
    {
        if (switchPerspective && directionKeys != Vector2.zero)
        {
            graphic.up = ((transform.up) * directionKeys.y) + (transform.right*directionKeys.x) ;
        }
    }
    
    private void PutPlayerBackInChair()
    {
        p_p.gameObject.transform.localPosition = origin;
    }
}
