using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private CharacterJumper _characterJumper;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private CharacterAnimator _characterAnimator;
    [SerializeField] private VampirismSkill _skill;

    private void OnEnable()
    {
        _inputHandler.VampirismActivated += _skill.OnVampirismStarted;
    }

    private void OnDisable()
    {
        _inputHandler.VampirismActivated += _skill.OnVampirismStarted;
    }

    private void Update()
    {
        _characterMovement.Move(_inputHandler.XDirection);

        if (_groundDetector.IsGrounded && _inputHandler.IsJump)
            _characterJumper.Jump();

        _characterAnimator.SetSpeed(_characterMovement.CurrentSpeed);
        _characterAnimator.SetFallVelocity(_characterJumper.YVelocity);
    }
}
