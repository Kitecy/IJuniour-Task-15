using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;

    public float YVelocity => _rigidbody2D.linearVelocityY;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidbody2D.linearVelocityY = 0;
        _rigidbody2D.AddForceY(_jumpForce, ForceMode2D.Impulse);
    }
}