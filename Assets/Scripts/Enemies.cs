using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Rigidbody2D Enemy_Rigidbody;

    public float X_Speed;
    public float Shooting_Time;

    public virtual void Moving()
    {
        Debug.Log("I move");
    }

    public virtual void Shooting()
    {
        Debug.Log("I shoot");
    }

    void Start()
    {
        Enemy_Rigidbody = GetComponent<Rigidbody2D>();
        Moving();
    }

    void Update()
    {
        Shooting();
        
    }
}
