using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.ValueChanged += OnDamaged;
    }

    private void OnDisable()
    {
        Health.ValueChanged -= OnDamaged;
    }

    protected abstract void OnDamaged(int health);
}
