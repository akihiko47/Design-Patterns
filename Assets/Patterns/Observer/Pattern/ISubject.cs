using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour {

    List<IObserver> _observers = new List<IObserver>();

    public void AddObserver(IObserver observer) {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer) {
        _observers.Remove(observer);
    }

    protected void Notify() {
        for (int i = 0; i < _observers.Count; i++) {
            _observers[i].OnNotify();
        }
    }

}
