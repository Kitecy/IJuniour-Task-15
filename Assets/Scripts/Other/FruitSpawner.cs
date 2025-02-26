using System.Collections;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private Fruit _fruitPrefab;
    [SerializeField] private float _spawnDelay;

    private Fruit _currentFruit;

    private void Start()
    {
        CreateFruit();
    }

    private void OnDestroy()
    {
        _currentFruit.Collected -= StartCreatingFruit;
    }

    public void StartCreatingFruit()
    {
        StartCoroutine(WaitForCreateFruit());
    }

    private IEnumerator WaitForCreateFruit()
    {
        yield return new WaitForSeconds(_spawnDelay);
        CreateFruit();
    }

    private void CreateFruit()
    {
        Fruit fruit = Instantiate(_fruitPrefab, transform.position, Quaternion.identity);
        fruit.Collected += StartCreatingFruit;
        _currentFruit = fruit;
    }
}
