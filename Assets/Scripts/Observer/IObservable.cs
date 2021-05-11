using System.Collections;
using System.Collections.Generic;

public interface IObservable<T>
{
    void Subscribe(IObserver<T> observer);
}
