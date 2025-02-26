using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterAttacker : MonoBehaviour
{
    [SerializeField] private float _bounceForce;
    [SerializeField] private int _damage;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            if (collision.GetContact(0).normal.y > Utils.UpNormalValue)
            {
                health.TakeDamage(_damage);
                _rigidbody2D.AddForceY(_bounceForce, ForceMode2D.Impulse);
            }
        }
    }
}
