using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class EnemyDamagableZone : MonoBehaviour
{
    public event Action Killed;

    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    public void Kill()
    {
        Killed?.Invoke();
    }
}
