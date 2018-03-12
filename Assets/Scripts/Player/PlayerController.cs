using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    enum State { idle, dash, shoot, action, freezed};

    private Rigidbody2D rigidbody;
    public static float speed_running = 5.0f;
    public static float speed_dashing = 7.5f;
    public static float speed_shooting = 2.0f;
    static float deadZone = 0.2F;

    State currentPlayerState;
	// Use this for initialization
	void Start () {
        rigidbody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        float x = Input.GetAxis("x");
        if (Mathf.Abs(x) < deadZone)
            x = 0;

        float y = Input.GetAxis("y");
        if (Mathf.Abs(y) < deadZone)
            y = 0;

        float rightTrigger = Input.GetAxis("10");
        float leftTrigger = Input.GetAxis("9");
        bool dashpushed = leftTrigger > 0.7;
        bool shotpushed = rightTrigger > 0.7;


        
    }

    private void updateState()
    {

    }

    private void move(float x, float y)
    {
        Vector2 v = new Vector2(x, y);
        v *= state_speed_factor();
        rigidbody.transform.Translate(v);
    }

    private float state_speed_factor()
    {
        switch (this.currentPlayerState)
        {
            case State.idle:
                return playerController.speed_running;
            case State.dash:
                return playerController.speed_dashing;
            case State.shoot:
                return playerController.speed_shooting;
            case State.action:
                break;
            case State.freezed:
                return 0;
        }
        return 1f;
    }
}