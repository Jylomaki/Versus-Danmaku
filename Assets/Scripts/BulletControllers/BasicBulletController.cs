using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletController : MonoBehaviour {
    public float speedFactor = 1.0f;
    Vector2 movement= new Vector2(0,-1);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(movement * (Time.deltaTime * speedFactor * Bullets.bulletBaseSpeed));
	}
}
