using System.Collections.Generic;

public class SimpleObservable<T> : IObservable<T>
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