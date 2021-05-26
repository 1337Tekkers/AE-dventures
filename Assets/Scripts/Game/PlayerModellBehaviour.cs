using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModellBehaviour : MonoBehaviour
{
    private Transform target;
    private bool followTarget = false;
    public readonly float maxMoveSpeed;
    private float moveSpeed;
    public float accelerationRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Turn();
        if (followTarget)
        {
            Accelerate();
            Move();
        }
        else
        {
            Decelerate();
        }
    }

    private void Turn()
    {
        if (target != null)
        {
            this.transform.LookAt(target);
        }
    }

    private void Move()
    {
        this.transform.Translate(this.transform.forward * moveSpeed * Time.deltaTime);
    }

    private void Decelerate()
    {
        this.moveSpeed -= accelerationRate * Time.deltaTime;
        if (moveSpeed < 0)
        {
            moveSpeed = 0;
        }
    }

    private void Accelerate()
    {
        this.moveSpeed += accelerationRate * Time.deltaTime;
        if (moveSpeed > maxMoveSpeed)
        {
            moveSpeed = maxMoveSpeed;
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void SetMovement(bool moving)
    {
        followTarget = moving;
    }
}
