using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    Ball Ball_Object;

    public Rigidbody2D Bullet_Rigidbody;

    public float BulletForce;
    public float DestroyingBullet_Time;

    public virtual void Bullet_Force()
    {
        Debug.Log("Forcing power");
    }

    public virtual void DestroyingBullet()
    {
        Debug.Log("Destroying bullet");
    }

    void Start()
    {
        Bullet_Rigidbody = GetComponent<Rigidbody2D>();
        Ball_Object = FindObjectOfType<Ball>();
    }

    void Update()
    {
        Bullet_Force();
        DestroyingBullet();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            Ball_Object.Explode_Ball();
        }
    }

}
