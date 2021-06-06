using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMonobehaviourObservable<T> : MonoBehaviour, IObservable<T>
{
    private readonly List<IObserver<T>> observers = new List<IObserver<T>>();
    public void Subscribe(IObserver<T> observer)
    {
        this.observers.Add(observer);
    }

    public void Unsubscribe(IObserver<T> observer)
    {
        this.observers.Remove(observer);
    }

    protected void NotifyAll(T message)
    {
        foreach (IObserver<T> obs in observers)
        {
            obs.Notify(message);
        }
    }
}
