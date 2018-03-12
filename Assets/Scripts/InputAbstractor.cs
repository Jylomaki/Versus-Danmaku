using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAbstractor : MonoBehaviour {
    public enum InputID { KB, J1, J2};
    public InputID inputId = InputID.J1;
    string inputname_begin;

    Vector2 move;
    Vector2 aim;
    float dash, fire, alternateFire;

    public Vector2 Aim
    {
        get
        {
            return aim;
        }
    }

    // Use this for initialization
    void Awake () {
        inputname_begin = inputId.ToString() + "_";
        move = new Vector2(0, 0);
        aim = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	public void refreshInputs () {
		//Debug.Log("InputAbstractor: the name is:\"" + inputname_begin + "\"");

        fire = Input.GetAxis(inputname_begin + "fire1");
        dash = Input.GetAxis(inputname_begin + "dash");
        alternateFire = Input.GetButton(inputname_begin + "fire2") ? 1 : 0 ;
        Debug.Log("InputAbstractor: fire:" + fire + " dash: " + dash + " alternatefire:" + alternateFire);


        float x, y;
        x = Input.GetAxis(inputname_begin + "mvt_X");
        y = Input.GetAxis(inputname_begin + "mvt_Y");
        this.move.Set(x, y);
        //Debug.Log("InputAbstractor: move" + move );


        x = Input.GetAxis(inputname_begin + "aim_X");
        y = Input.GetAxis(inputname_begin + "aim_Y");
        this.aim.Set(x, y);

    }

    public bool dashPressed() { return dash>0.2; }
    public bool firePressed() { return fire>0.2; }
    public bool alternateFirePressed() { return alternateFire>0.2; }
    public Vector2 getAim() { return aim; }
    public Vector2 getMove() { return move; }
}
