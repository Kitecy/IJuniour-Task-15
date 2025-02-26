using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _minDistanceForDetection;

    public bool TargetInFieldOfView()
    {
        return (_target.position - transform.position).sqrMagnitude <= _minDistanceForDetection * _minDistanceForDetection;
    }
}