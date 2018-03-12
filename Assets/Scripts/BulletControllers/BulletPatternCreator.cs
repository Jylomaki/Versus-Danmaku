using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPatternCreator : MonoBehaviour {
    public float total_angle_aperture = 90f;
    public Bullets.BulletMetaType bulletType;
    public bool alternate;

    public void shoot()
    {
        switch (bulletType)
        {
            case Bullets.BulletMetaType.EARTH:
                shoot_earth();
                break;
            case Bullets.BulletMetaType.FIRE:
                shoot_fire();
                break;
            case Bullets.BulletMetaType.AIR:
                break;
            case Bullets.BulletMetaType.WATER:
                break;
        }
    }

    private void shoot_earth()
    {
        if (alternate)
        {
            shoot_earth_alternate();
            return;
        }
        Object bullet = Bullets.bullets[(int)Bullets.BulletType.BASIC];
        float delta_angle = total_angle_aperture / 5f * 1.2f;
        //orientation for the rightmost bullet

        transform.Rotate(0, 0, delta_angle * 2.5f);
        Instantiate(bullet, transform.position, transform.rotation);

        for(int i=0; i<5; i++)
        {
            transform.Rotate(0, 0, delta_angle * -1f);
            Instantiate(bullet, transform.position, transform.rotation);
        }
        //total should go from -2.5 to +2.5 delta

        transform.Rotate(0, 0, delta_angle * 2.5f);

    }
    private void shoot_fire()
    {
        if (alternate)
        {
            shoot_fire_alternate();
            return;
        }
        Object bullet = Bullets.bullets[(int)Bullets.BulletType.FIRE_WAVE];
        float delta_angle = total_angle_aperture / 4;
        //orientation for the rightmost bullet

        transform.Rotate(0, 0, delta_angle * 2f);
        Instantiate(bullet, transform.position, transform.rotation);

        for (int i = 0; i < 4; i++)
        {
            transform.Rotate(0, 0, delta_angle * -1f);
            Instantiate(bullet, transform.position, transform.rotation);
        }
        //total should go from -2.5 to +2.5 delta

        transform.Rotate(0, 0, delta_angle * 2f);
    }
    private void shoot_fire_alternate() {
        Object bullet = Bullets.bullets[(int)Bullets.BulletType.FIRE_CROSS];
        float offset = -1.5f;
        for(int i=0; i<4; i++)
        {
            BulletControllerFireCross.offset = offset;
            Object currentbullet = Instantiate(bullet, transform.position, transform.rotation);
            offset++;
        }
    }
    private void shoot_earth_alternate() { }

}
