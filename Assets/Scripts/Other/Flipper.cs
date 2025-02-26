using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private bool _characterLookAtRight;

    private Quaternion _leftRotation = Quaternion.Euler(0, 180, 0);
    private Quaternion _rightRotation = Quaternion.Euler(0, 0, 0);

    public void Flip()
    {
        transform.rotation = transform.rotation.y == _leftRotation.y ? _rightRotation : _leftRotation;
    }

    public void FlipToRight()
    {
        transform.rotation = _characterLookAtRight ? _rightRotation : _leftRotation;
    }

    public void FlipToLeft()
    {
        transform.rotation = _characterLookAtRight ? _leftRotation : _rightRotation;
    }
}
