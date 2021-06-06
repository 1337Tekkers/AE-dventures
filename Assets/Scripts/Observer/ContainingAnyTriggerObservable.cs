using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainingAnyTriggerObservable : SimpleMonobehaviourObservable<bool>
{
    private readonly HashSet<Collider> collidingObjects = new HashSet<Collider>();
    private int LastCollidingObjectCount = 0;

    private void OnTriggerEnter(Collider collider)
    {
        collidingObjects.Add(collider);
    }

    private void OnTriggerStay(Collider collider)
    {
        collidingObjects.Add(collider);
    }

    private void FixedUpdate()
    {
        collidingObjects.Clear();
    }

    private void Update()
    {
        int collidingObjectsCount = collidingObjects.Count;
        if (collidingObjectsCount > 0 && LastCollidingObjectCount == 0)
        {
            NotifyAll(true);
        }
        else if (collidingObjectsCount == 0 && LastCollidingObjectCount > 0)
        {
            NotifyAll(false);
        }
        LastCollidingObjectCount = collidingObjectsCount;
    }
}
