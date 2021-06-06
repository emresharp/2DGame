using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Two_Gun_Enemy : Enemies
{
    [SerializeField]
    private GameObject Two_Gun_Enemy_Bullet;

    [SerializeField]
    private GameObject Bullet_Exit_Point;
    [SerializeField]
    private GameObject Bullet_Exit_Point2;

    float Current_Time;

    public override void Shooting()
    {
        Current_Time += Time.deltaTime;
        if (Current_Time >= Shooting_Time)
        {
            Current_Time = 0;
            Instantiate(Two_Gun_Enemy_Bullet, Bullet_Exit_Point.transform.position, Quaternion.identity);
            Instantiate(Two_Gun_Enemy_Bullet, Bullet_Exit_Point2.transform.position, Quaternion.identity);
        }
    }

    public override void Moving()
    {
        Enemy_Rigidbody.velocity = new Vector2(X_Speed, 0);
    }

}
