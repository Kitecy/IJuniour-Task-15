using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool IsGrounded { get; private set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>())
            IsGrounded = collision.GetContact(0).normal.y > Utils.UpNormalValue;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>())
            IsGrounded = false;
    }
}
