using UnityEngine;

public class ItemsCollector : MonoBehaviour
{
    [SerializeField] private Health _characterHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            switch (item)
            {
                case Fruit:
                    (item as Fruit).Collect();
                    break;

                case Kit:
                    _characterHealth.Heal((item as Kit).Use());
                    break;
            }
        }
    }
}