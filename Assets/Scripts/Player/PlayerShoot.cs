using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    Vector2 aim;
    Vector2 inputAim;
    Rigidbody2D playerRigidBody;
    PlayerState playerState;
    BulletPatternCreator patternCreator;

    private int nextBulletType;
    // Use this for initialization
    void Start () {
        patternCreator = GetComponentInChildren<BulletPatternCreator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerState = GetComponent<PlayerState>();
        aim = new Vector2(0, 1);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        if (!global_variables.frozen)
        {
            inputAim = playerState.inputAbstractor.getAim();

            this.Aim(inputAim);

            if (shootPressed() && playerState.shoot())
            {
                patternCreator.bulletType = Bullets.BulletMetaType.FIRE;
                patternCreator.alternate = playerState.inputAbstractor.alternateFirePressed();
                patternCreator.shoot();
            }
            
        }
    }
    private bool shootPressed()
    {
        //no direction is required, last know direction is used
        if (playerState.inputAbstractor.firePressed() || playerState.inputAbstractor.alternateFirePressed())
        {
            return true;
        }
        return false;
    }
    private void Aim(Vector2 v)
    {
        Aim(v.x, v.y);
    }
    private void Aim(float x, float y)
    {
        //Debug.Log("Playershoot: Vector:(" + x + "," + y + ")");
        if (x != 0 || y != 0)
        {
            aim.Set(x, y);
            aim.Normalize();
            float angle = Vector2.SignedAngle(Vector2.up, aim);

            playerRigidBody.MoveRotation(angle);
        }

        
    }
}
