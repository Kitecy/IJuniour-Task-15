using System;
using System.Collections;
using UnityEngine;

public class VampirismSkill : MonoBehaviour
{
    [SerializeField] private Health _owner;
    [SerializeField] private int _stealValuePerSecond;
    [SerializeField] private LayerMask _detectableMasks;
    [SerializeField] private VampirismTargetsFinder _targetsFinder;

    private bool _canActivate = true;

    public event Action Activated;
    public event Action<int> RemainingDurationChanged;
    public event Action<int> RemainingCooldownChanged;
    public event Action Recharged;
    public event Action Deactivated;

    private WaitForSeconds _delay = new WaitForSeconds(1);

    [field: SerializeField] public float Radius { get; private set; }

    [field: SerializeField] public int Duration { get; private set; }

    [field: SerializeField] public int ReloadingDuration { get; private set; }

    private void Awake()
    {
        _targetsFinder.SetRadius(Radius);
    }

    public void OnVampirismStarted()
    {
        if (_canActivate == false)
            return;

        _canActivate = false;
        StartCoroutine(Process());
        Activated?.Invoke();
    }

    private IEnumerator Process()
    {
        int timer = Duration;

        while (timer > 0)
        {
            yield return _delay;

            timer--;
            RemainingDurationChanged?.Invoke(timer);
            AttackTarget();
        }

        Deactivated?.Invoke();

        StartCoroutine(Reloading());
    }

    private IEnumerator Reloading()
    {
        int timer = ReloadingDuration;

        while (timer > 0)
        {
            yield return _delay;

            timer--;
            RemainingCooldownChanged?.Invoke(timer);
        }

        _canActivate = true;
        Recharged?.Invoke();
    }

    private void AttackTarget()
    {
        Health nearest = _targetsFinder.GetNearestTarget();

        if (nearest == null)
            return;

        _owner.Heal(nearest.StealHealth(_stealValuePerSecond));
    }
}
