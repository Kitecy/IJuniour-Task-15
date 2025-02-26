using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VampirismSkillVisualizer : MonoBehaviour
{
    [SerializeField] private VampirismSkill _skill;
    [SerializeField] private SpriteRenderer _useArea;
    [SerializeField] private ParticleSystem _vampirismVFX;
    [SerializeField, Min(1)] private float _effectsMultiplier;

    [SerializeField] private Image _skillImage;
    [SerializeField] private Color _rechargingColor = Color.white;
    [SerializeField] private TMP_Text _timer;

    private void OnEnable()
    {
        _skill.Activated += OnActivated;
        _skill.Activated += ShowEffect;

        _skill.Recharged += OnRecharged;

        _skill.RemainingCooldownChanged += SetTimerValue;
        _skill.RemainingDurationChanged += SetTimerValue;

        _skill.Deactivated += ClearArea;
        _skill.Deactivated += HideEffect;
        _skill.Deactivated += OnStartRecharding;
    }

    private void OnDisable()
    {
        _skill.Activated -= OnActivated;
        _skill.Activated -= ShowEffect;

        _skill.Recharged -= OnRecharged;

        _skill.RemainingCooldownChanged -= SetTimerValue;
        _skill.RemainingDurationChanged -= SetTimerValue;

        _skill.Deactivated -= ClearArea;
        _skill.Deactivated -= HideEffect;
        _skill.Deactivated -= OnStartRecharding;
    }

    private void OnStartRecharding()
    {
        _skillImage.color = _rechargingColor;
        _timer.text = _skill.ReloadingDuration.ToString();
    }

    private void OnRecharged()
    {
        _timer.text = string.Empty;
        _skillImage.color = Color.white;
    }

    private void OnActivated()
    {
        _timer.text = _skill.Duration.ToString();
        DrawArea();
    }

    private void DrawArea()
    {
        _useArea.transform.localScale = new Vector3(_skill.Radius, _skill.Radius, 1);
        _useArea.enabled = true;
    }

    private void SetTimerValue(int time)
    {
        _timer.text = time.ToString();
    }

    private void ShowEffect()
    {
        ParticleSystem.ShapeModule module = _vampirismVFX.shape;
        module.radius = _skill.Radius * _effectsMultiplier;
        _vampirismVFX.Play();
    }

    private void HideEffect()
    {
        _vampirismVFX.Stop();
    }

    private void ClearArea()
    {
        _useArea.enabled = false;
    }
}
