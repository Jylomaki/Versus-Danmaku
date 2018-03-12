using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {
    //this class will be used to store all pointful datas about the player, to be shared by its controllers
    /*Controller:
     * Movement
     * Shooting
     * Animation
    */
    public static float timer_dash = 0.5f;
    public static float timer_shooting = 0.2f;
    public static float timer_shoot_again = 0.05f;
    public float defaultInvincibleTime = 0.5f;

    public enum State { IDLE, SHOOT, DASH };

    Animator animator;
    public InputAbstractor inputAbstractor;
    public State currentState = State.IDLE;
    private float timer;
    private float invicibleTimer;

    public void Awake()
    {
        inputAbstractor = GetComponent<InputAbstractor>();
        animator = GetComponentInChildren<Animator>();
    }

    public void FixedUpdate()
    {
        inputAbstractor.refreshInputs();
        updateState();
        setAnimatorState();
    }

    private void updateState()
    {
        if (invicibleTimer > 0)
            invicibleTimer -= Time.deltaTime;
        else
            this.animator.SetBool("Invincible", false);

        if (timer > 0)
            timer -= Time.deltaTime;
        else
            currentState = State.IDLE;
    }

    public bool dashPossible()
    {
        return currentState == State.IDLE;
    }
    public bool shootPossible()
    {
        return currentState == State.IDLE || (currentState == State.SHOOT && timer < timer_shoot_again);
    }
    public bool dash()
    {
        if (dashPossible())
        {
            this.currentState = State.DASH;
            this.timer = PlayerState.timer_dash;
            return true;
        }
        return false;
    }

    public bool isInvincible()
    {
        return invicibleTimer > 0;
    }

    public void setInvincible()
    {
        setInvincible(defaultInvincibleTime);
    }
    public void setInvincible(float time)
    {
        if (time > invicibleTimer)
            invicibleTimer = time;
        this.animator.SetBool("Invincible", true);
    }
    public bool shoot()
    {
        Debug.Log("PlayerState: shoot called");
        if (shootPossible())
        {
            this.currentState = State.SHOOT;
            this.timer = PlayerState.timer_shooting;
            animator.SetTrigger("Shoot");
            return true;
        }
        return false;
    }


    private void setAnimatorState()
    {
        switch (currentState)
        {
            case State.IDLE:
                animator.SetBool("Dashing", false);
                break;
            case State.SHOOT:
                animator.SetTrigger("Shoot");
                animator.SetBool("Dashing", false);
                break;
            case State.DASH:
                animator.SetBool("Dashing", true);
                break;
        }
    }
}
