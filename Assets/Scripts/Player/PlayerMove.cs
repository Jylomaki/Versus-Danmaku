using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    public static float speed_running;
    public static float speed_dashing;
    public static float speed_shooting;

    

    //public inputAbstractor inputs;

    Vector2 movement;
    Vector2 inputMove;
    Rigidbody2D playerRigidBody;
    PlayerState playerState;
    int floorMask;

    void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerState = GetComponent<PlayerState>();

        movement = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        if (!global_variables.frozen)
        {
            inputMove = playerState.inputAbstractor.getMove();
            //Debug.Log("PlayerMove: values:(" + h + "," + v + ")");
            // Si la commande de dash est faite ET qu'on l'état du joueur le permet
            if (dashPressed(inputMove) && playerState.dash())
            {
                movement= inputMove;
                movement.Normalize();
            }
            this.Move(inputMove);
            playerRigidBody.angularVelocity = 0;
        }
    }

    private bool dashPressed(Vector2 v)
    {
        return dashPressed(v.x, v.y);
    }
    private bool dashPressed(float h,float v)
    {
        if (h == 0 && v == 0)
            return false;
        
        if (playerState.inputAbstractor.dashPressed()) {

            return true;
        }
        return false;
    }

    /**
     * La fonction qui effectue le mouvement prévu/commencé:
     * Dashing: goes in the same direction
     * else: goes in the direction of the inputs
     * */
    private void Move(Vector2 v)
    {
        Move(v.x, v.y);
    }

    private void Move(float x, float y)
    {
        float speed = getSpeed();

        if (playerState.currentState == PlayerState.State.DASH)
        {
            //rien a faire
        }
        else
        {
            //on utilise les inputs pour décider le mouvement
            movement.Set(x, y);
            if (movement.magnitude > 1f)
                movement.Normalize();
        }
        Vector2 mvt = movement * speed * Time.deltaTime;
        mvt.x += transform.position.x;
        mvt.y += transform.position.y;
        playerRigidBody.MovePosition(mvt);
    }

    private float getSpeed()
    {
        switch (playerState.currentState)
        {
            case (PlayerState.State.IDLE):
                return speed_running;
            case (PlayerState.State.DASH):
                return speed_dashing;
            case PlayerState.State.SHOOT:
                return speed_shooting;
        }
        Debug.Log(message: "playerMove: Unknown state. can't relate to speed: returning 0");
        return 0;
    }
}
