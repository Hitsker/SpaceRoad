using System;
using UnityEngine;

/// Simple class to hold information about RoadPlatform to use in in RoadConstructor
public class RoadPlatform : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private float _size;

    public Transform StartPoint => _startPoint;
    public Transform EndPoint => _endPoint;
    public float Size => _size;

    public event Action OnBecameInvisibleAction;
    private void OnBecameInvisible()
    {
        OnBecameInvisibleAction?.Invoke();
    }
}
