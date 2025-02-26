using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _throwingForce;

    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            if (CheckIsMe(health.transform))
                return;

            health.TakeDamage(_damage);
            CastAway(collision.rigidbody);
        }
    }

    private void CastAway(Rigidbody2D rigidbody)
    {
        if (rigidbody == null)
            throw new MissingReferenceException();

        Vector2 pushDirection = rigidbody.transform.position - transform.position;
        pushDirection.Normalize();

        rigidbody.AddForce(pushDirection * _throwingForce, ForceMode2D.Impulse);
    }

    private bool CheckIsMe(Transform transform)
    {
        if (transform.parent == null)
            return false;

        return transform.parent.gameObject == gameObject;
    }
}
