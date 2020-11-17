using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Switch : MonoBehaviour
{

    public GameObject sceneCam;
    public GameObject playerCam;

    public SpriteRenderer shipExt;
   // public SpriteRenderer shipInt;

    private Color extS;
//    private Color intS;

    bool fadeIn;
    private void Update()
    {
        if (fadeIn)
        {
            extS = shipExt.color;
            extS.a = 0;
            shipExt.color = extS;

        }
        else
        {
            extS = shipExt.color;
            extS.a = 1;
            shipExt.color = extS;
        }
    }

    public void SwitchPerspective(bool zoomIn)
    {
        if (zoomIn)
        {
            sceneCam.SetActive(!zoomIn);
            playerCam.SetActive(zoomIn);
        }
        else
        {
            sceneCam.SetActive(!zoomIn);
            playerCam.SetActive(zoomIn);
        }
        fadeIn = zoomIn;
    }

}
