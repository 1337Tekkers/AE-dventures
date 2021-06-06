using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AufgabeTriggerObservable : SimpleMonobehaviourObservable<Object>
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " collided with " + other.gameObject.name);
        NotifyAll(null);
    }
}
