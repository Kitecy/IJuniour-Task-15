using UnityEngine;

public class Stalker : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private Flipper _flipper;

    public void GoToTarget()
    {
        Vector2 target = new Vector2(_target.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        if (GetTargetOnTheRight())
            _flipper.FlipToRight();
        else
            _flipper.FlipToLeft();
    }

    private bool GetTargetOnTheRight()
    {
        Vector2 direction = _target.position - transform.position;

        return direction.x > 0;
    }
}
