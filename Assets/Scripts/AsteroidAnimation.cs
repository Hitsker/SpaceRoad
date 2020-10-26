using DG.Tweening;
using UnityEngine;

public class AsteroidAnimation : MonoBehaviour
{
    [SerializeField] private float _rotationDuration = 5.0f;
    [SerializeField] private float _yoYoDuration = 5.0f;
    [SerializeField] private float _yOffset = 1.0f;
    void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), _rotationDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
        transform.DOMoveY(transform.position.y + _yOffset, _yoYoDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}
