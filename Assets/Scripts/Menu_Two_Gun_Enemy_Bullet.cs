using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Two_Gun_Enemy_Bullet : Bullets
{
    public override void Bullet_Force()
    {
        Bullet_Rigidbody.velocity = new Vector2(0, BulletForce);
    }

    public override void DestroyingBullet()
    {
        Destroy(this.gameObject, DestroyingBullet_Time);

    }
}
