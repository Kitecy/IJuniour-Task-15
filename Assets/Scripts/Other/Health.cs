using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _value;

    public event Action<int> ValueChanged;
    public event Action Died;

    [field: SerializeField]
    public int MaxValue { get; private set; }

    private void Awake()
    {
        _value = MaxValue;
    }

    public void TakeDamage(int damage)
    {
        _value -= Mathf.Clamp(damage, 0, MaxValue);
        _value = Mathf.Clamp(_value, 0, MaxValue);
        ValueChanged?.Invoke(_value);

        if (_value <= 0)
            Died?.Invoke();
    }

    public void Heal(int value)
    {
        _value += Mathf.Clamp(value, 0, MaxValue);
        _value = Mathf.Clamp(_value, 0, MaxValue);
        ValueChanged?.Invoke(_value);
    }
}