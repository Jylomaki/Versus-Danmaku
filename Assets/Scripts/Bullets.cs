using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets: MonoBehaviour {
    public enum BulletType { BASIC = 0, SLOW = 1, FAST = 2, FIRE_WAVE = 3, FIRE_CROSS = 4, AIR = 5, ROCK = 6, ICE_BALL = 7, ICE_ICICLE = 8 };
    public enum BulletMetaType { EARTH, FIRE, AIR, WATER};

    public static float bulletBaseSpeed = 40f;
    public static Object[] bullets;
    public Object[] bulletsObjects;
    public static BulletPatternCreator bulletPatternCreator;
    public BulletPatternCreator patternCreator;

    private void Awake()
    {
        bulletPatternCreator = patternCreator;

        int len = bulletsObjects.Length;
        bullets = new Object[len];
        for(int i = 0; i< bulletsObjects.Length; i++)
        {
            bullets[i] = bulletsObjects[i];
        }
    }
}
