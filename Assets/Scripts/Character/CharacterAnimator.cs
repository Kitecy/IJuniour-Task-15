using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    private const string SpeedAnimationPropertyName = "Speed";
    private const string YVelocityAnimationPropertyName = "yVelocity";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(SpeedAnimationPropertyName, speed);
    }

    public void SetFallVelocity(float velocity)
    {
        _animator.SetFloat(YVelocityAnimationPropertyName, velocity);
    }
}
