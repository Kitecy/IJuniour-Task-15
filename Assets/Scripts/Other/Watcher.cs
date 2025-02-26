using UnityEngine;

public class Watcher : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector2 _offset;

    private void OnValidate()
    {
        if (_target != null)
            transform.position = new Vector3(_target.position.x + _offset.x, _target.position.y + _offset.y, transform.position.z);
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(_target.position.x + _offset.x, _target.position.y + _offset.y, transform.position.z);
    }
}
