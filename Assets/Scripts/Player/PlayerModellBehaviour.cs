using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModellBehaviour : MonoBehaviour
{
    private Transform target;
    private bool followingTarget = false;
    public float maxMoveSpeed;
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
        if (followingTarget)
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
        moveSpeed -= accelerationRate * Time.deltaTime;
        if (moveSpeed < 0)
        {
            moveSpeed = 0;
        }
    }

    private void Accelerate()
    {
        moveSpeed += accelerationRate * Time.deltaTime;
        if (moveSpeed > maxMoveSpeed)
        {
            moveSpeed = maxMoveSpeed;
        }
        Debug.Log(moveSpeed);
    }

    public void SetTarget(Transform target, bool follow = false)
    {
        this.target = target;
        FollowTarget(follow);
    }

    public void FollowTarget(bool follow)
    {
        followingTarget = follow;
    }

    public bool isFollowingTarget()
    {
        return this.followingTarget;
    }
}
