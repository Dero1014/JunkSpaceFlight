using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player_Pilot_Controls))]
public class PlayerPilotEdit : Editor
{
    private void OnSceneGUI()
    {
        Player_Pilot_Controls pk = (Player_Pilot_Controls)target;

        Handles.color = Color.blue;

        Handles.DrawWireDisc(pk.transform.position, Vector3.forward, pk.radius);

    }
}
