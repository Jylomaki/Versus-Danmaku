using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public enum HealthType { INSTA_DEATH=0, HITPOINT=1, RESPAWNPOINT=2 }
    public static HealthType healthType = 0;
    public static int Healthcount=1;

    public HealthType ht;
    public int hp = 1;
	// Use this for initialization
	void Start () {
        healthType = ht;
        if (ht == 0)
            Healthcount = 1;
        else
            Healthcount = hp;
	}
    public void takeDamage()
    {
        hp--;
        if (hp == 0)
            //DIE
            Object.Destroy(this);
        else if (healthType == HealthType.HITPOINT)
        {

        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        if (collider.CompareTag("Bullet"))
        {

        }
    }
}
