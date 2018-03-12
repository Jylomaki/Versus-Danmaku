using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWaveBulletController : MonoBehaviour {
    public float speedFactor = 1.0f;
    Vector2 movement = new Vector2(0, -1);

    public float waveAmplitude = 6f;
    public float waveFrequence = 6f;


    private float timer;
    // Use this for initialization
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mvt;
        timer += Time.deltaTime;
        float X = Mathf.Cos(timer * Mathf.PI * waveFrequence) * waveAmplitude;

        //The speed is now constant
        mvt = movement*Bullets.bulletBaseSpeed + new Vector2(X, 0);
        mvt.Normalize();
        mvt *= Bullets.bulletBaseSpeed;
   
        this.transform.Translate(mvt * (Time.deltaTime * speedFactor));
        this.transform.Translate(new Vector3(X, 0, 0)* Time.deltaTime);
    }
}
