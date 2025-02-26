using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothImageHealthBar : HealthBar
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _smoothDuration;

    private Coroutine _coroutine;

    private void Awake()
    {
        _slider.maxValue = Health.MaxValue;
        _slider.value = Health.MaxValue;
    }

    protected override void OnDamaged(int health)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Show(health));
    }

    private IEnumerator Show(int health)
    {
        float currentHealth = _slider.value;
        float intermediateValue = 0;
        float time = 0;

        while (time < _smoothDuration)
        {
            time += Time.deltaTime;
            float normalizedTime = time / _smoothDuration;
            intermediateValue = Mathf.Lerp(currentHealth, health, normalizedTime);
            _slider.value = intermediateValue;

            yield return null;
        }
    }
}
