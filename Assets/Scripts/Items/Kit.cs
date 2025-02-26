using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Kit : Item
{
    [SerializeField] private int _regen;

    public int Use()
    {
        Destroy(gameObject);
        return _regen;
    }
}
