using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Flipper _flipper;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private RigidbodyConstraints2D _defaultConstraints = RigidbodyConstraints2D.FreezeRotation;

    public float CurrentSpeed => Mathf.Abs(_rigidbody2D.linearVelocityX);

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _rigidbody2D.constraints = _defaultConstraints;
    }

    public void Move(float direction)
    {
        if (direction != 0)
        {
            _rigidbody2D.linearVelocityX = direction * _speed;

            if (direction > 0)
                _flipper.FlipToRight();
            else
                _flipper.FlipToLeft();
        }
    }
}