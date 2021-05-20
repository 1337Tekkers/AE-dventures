using System.Collections.Generic;

public class MemoryObservable<T> : IObservable<T>
{
    private readonly List<IObserver<T>> observers = new List<IObserver<T>>();
    protected T lastValue;
    public void Subscribe(IObserver<T> observer)
    {
        this.observers.Add(observer);
        observer.Notify(lastValue);
    }

    public void Unsubscribe(IObserver<T> observer)
    {
        this.observers.Remove(observer);
    }

    protected void NotifyAll(T message)
    {
        lastValue = message;
        foreach (IObserver<T> obs in observers)
        {
            obs.Notify(message);
        }
    }
}
