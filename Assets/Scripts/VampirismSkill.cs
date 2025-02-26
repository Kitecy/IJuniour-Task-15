using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampirismSkill : MonoBehaviour
{
    [SerializeField] private Health _owner;
    [SerializeField] private int _damagePerSecond;
    [SerializeField] private LayerMask _detectableMasks;

    private bool _activated;
    private bool _canActivate = true;

    public event Action Activated;
    public event Action<int> RemainingDurationChanged;
    public event Action<int> RemainingCooldownChanged;
    public event Action Recharged;
    public event Action Deactivated;

    [field: SerializeField]
    public float Radius { get; private set; }

    [field: SerializeField]
    public int Duration { get; private set; }

    [field: SerializeField]
    public int ReloadingDuration { get; private set; }

    public void OnVampirismStarted()
    {
        if (_activated || _canActivate == false)
            return;

        _activated = true;
        _canActivate = false;
        StartCoroutine(Process());
        Activated?.Invoke();
    }

    private IEnumerator Process()
    {
        int timer = Duration;

        while (timer > 0)
        {
            yield return new WaitForSeconds(1);

            timer--;
            RemainingDurationChanged?.Invoke(timer);
            AttackTarget();

        }

        _activated = false;
        Deactivated?.Invoke();

        StartCoroutine(Reloading());
    }

    private IEnumerator Reloading()
    {
        int timer = ReloadingDuration;

        while (timer > 0)
        {
            yield return new WaitForSeconds(1);

            timer--;
            RemainingCooldownChanged?.Invoke(timer);
        }

        _canActivate = true;
        Recharged?.Invoke();
    }

    private void AttackTarget()
    {
        Health nearest = FindNearestTarget();

        if (nearest == null)
            return;

        nearest.TakeDamage(_damagePerSecond);
        _owner.Heal(_damagePerSecond);
    }

    private Health FindNearestTarget()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, Radius, _detectableMasks);
        List<Health> healths = new List<Health>();

        foreach (Collider2D target in targets)
            if (target.TryGetComponent(out Health health))
                healths.Add(health);

        Health nearestHealth = null;
        float previousDistance = float.MaxValue;

        foreach (Health health in healths)
        {
            float distance = (health.transform.position - transform.position).sqrMagnitude;

            if (distance < previousDistance)
                nearestHealth = health;
        }

        return nearestHealth;
    }
}
