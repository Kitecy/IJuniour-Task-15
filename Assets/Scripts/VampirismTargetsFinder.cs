using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class VampirismTargetsFinder : MonoBehaviour
{
    private List<Collider2D> _colliders = new();
    private CircleCollider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<CircleCollider2D>();
    }

    public void SetRadius(float radius)
    {
        _collider.radius = radius;
    }

    public Health GetNearestTarget()
    {
        List<Health> targets = new();

        foreach (Collider2D collider in _colliders)
            if (collider.TryGetComponent(out Health health))
                targets.Add(health);

        Health nearestTarget = null;
        float previousDistance = float.MaxValue;

        foreach (Health target in targets)
        {
            float distance = (target.transform.position - transform.position).sqrMagnitude;

            if (distance < previousDistance)
                nearestTarget = target;
        }

        return nearestTarget;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _colliders.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _colliders.Remove(collision);
    }
}
