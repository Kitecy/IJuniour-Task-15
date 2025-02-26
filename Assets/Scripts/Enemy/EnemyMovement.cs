using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;
    [SerializeField] private Flipper _flipper;

    private Transform _target;

    private void Start()
    {
        _target = _firstPoint;
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (GetXDirectionToTarget() > 0)
            _flipper.FlipToRight();
        else
            _flipper.FlipToLeft();

        if (transform.position == _target.position)
            ChangeTarget();
    }

    private void ChangeTarget()
    {
        _target = _target == _firstPoint ? _secondPoint : _firstPoint;
    }

    private float GetXDirectionToTarget()
    {
        return (_target.position - transform.position).x;
    }
}
