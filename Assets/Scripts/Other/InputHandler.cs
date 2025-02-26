using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public const string Horizontal = nameof(Horizontal);

    [SerializeField] private KeyCode _buttonForActivateVampirism;

    public event Action VampirismActivated;

    public bool IsJump { get; private set; }
    public float XDirection { get; private set; }

    private void Update()
    {
        XDirection = Input.GetAxis(Horizontal);
        IsJump = Input.GetKeyDown(KeyCode.Space);

        if (Input.GetKeyDown(_buttonForActivateVampirism))
            VampirismActivated?.Invoke();
    }
}
