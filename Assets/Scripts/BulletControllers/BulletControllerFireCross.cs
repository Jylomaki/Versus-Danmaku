using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerFireCross : MonoBehaviour {
    public float speedFactor = 1.0f;
    Vector2 movement = new Vector2(0, -1);

    public float waveAmplitude = 12f;
    public float waveFrequence = 2f;
    public float pauseLength = 0.5f;
    public static float offset;
    private float self_offset;

    private float timer;
    private float timer_pause;
    // Use this for initialization
    void Awake () {
        timer = 1 / (waveFrequence*2);
        timer_pause = -1f;
        self_offset = offset;
        movement.x = self_offset * waveAmplitude/(1.5f * Bullets.bulletBaseSpeed);
        //divide by 1.5 to account for the fact the the offset go from -1.5  to +1.5
	}
	
	// Update is called once per frame
	void Update () {
        if (timer_pause < 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer_pause = pauseLength;
                timer = 1 / waveFrequence;
                self_offset = -self_offset;
                movement.x = self_offset * waveAmplitude / (1.5f * Bullets.bulletBaseSpeed);
            }
            this.transform.Translate(movement * (Time.deltaTime * speedFactor * Bullets.bulletBaseSpeed));
            Debug.Log("BulletCrtonllerFireCross: mvt: " + movement);
        }
        else
        {
            timer_pause -= Time.deltaTime;
        }
    }
}
