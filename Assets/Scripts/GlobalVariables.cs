using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global_variables : MonoBehaviour {
    public static bool frozen = false;
    public static float time_factor = 1.0f;

    public static float deadzone_trigger = 0.2f;
    public static float deadzone_joystick = 0.2f;

    public static void freeze()
    {
        frozen = true;
        Debug.Log("GlobalVariables: Game frozen");
    }

    public static void unfreeze()
    {
        frozen = false;
        Debug.Log("GlobalVariables: Game unfrozen");
    }
}
