using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariableSetter : MonoBehaviour {
    //This class is use to setup the Static variables on start, whilst allowing acces from editor
    public float player_speed_dash = 20f;
    public float player_speed_shooting = 4f;
    public float player_speed_running = 10f;

    public float player_timer_dash = 0.5f;
    public float player_timer_shoot = 0.3f;
    public float player_timer_shoot_again = 0.2f;

    public float shot_speed=15f;
	// Use this for initialization
	void Awake () {
        PlayerMove.speed_dashing = player_speed_dash;
        PlayerMove.speed_running = player_speed_running;
        PlayerMove.speed_shooting = player_speed_shooting;

        PlayerState.timer_dash = player_timer_dash;
        PlayerState.timer_shooting = player_timer_shoot;
        PlayerState.timer_shoot_again = player_timer_shoot - player_timer_shoot_again;

        Bullets.bulletBaseSpeed = shot_speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
