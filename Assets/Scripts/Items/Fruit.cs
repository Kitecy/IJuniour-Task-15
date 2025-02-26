using System;
using UnityEngine;

public class Fruit : Item
{
    [SerializeField] private int _value;

    public event Action Collected;

    private void OnDestroy()
    {
        Collected = null;
    }

    public void Collect()
    {
        Collected?.Invoke();
        Destroy(gameObject);
    }
}
