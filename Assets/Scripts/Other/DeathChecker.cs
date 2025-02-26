using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathChecker : MonoBehaviour
{
    [SerializeField] private Health _characterHealth;

    private void OnEnable()
    {
        _characterHealth.Died += OnDied;
    }

    private void OnDisable()
    {
        _characterHealth.Died -= OnDied;
    }

    private void OnDied()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
