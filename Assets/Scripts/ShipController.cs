using System;
using DG.Tweening;
using UnityEngine;

/// Class to  control the behaviours of the ship such as rolls to the right/left side, death(as well as death effects and animations), increasing the overall score
public class ShipController : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    [SerializeField] private ParticleSystem _flare;
    [SerializeField] private Transform _explosionInstPoint;
    [SerializeField] private Transform _flareInstPoint;
    [SerializeField] private float _rotationAngle = 25.0f;
    [SerializeField] private float _rotationSpeed = 0.2f;
    [SerializeField] private Rigidbody _rigidbody;
    
    private KeyCode _currentKey;
    
    private bool _isKeyPressed;
    private bool _isKeyReleased = true;
    
    private Tween _currentRotationAnimation;

    public event Action OnDeath;

    private void Start()
    {
        OnDeath += EnableGravity;
        OnDeath += GameManager.instance.popUpsContainer.ShowGameOverPopUp;
    }

    void Update()
    {
        //Reset animation and boolean variables if we unpress the arrows, so we can then start animation again
        if (Input.GetKeyUp(KeyCode.LeftArrow) && _isKeyPressed || Input.GetKeyUp(KeyCode.RightArrow) && _isKeyPressed)
        {
            _currentRotationAnimation.Pause();
            _currentRotationAnimation = transform.DORotate(new Vector3(0, 0, 0), _rotationSpeed);
            _currentRotationAnimation.Play();

            _isKeyReleased = true;
            _isKeyPressed = false;
        }
        
        //If we are not pressing the arrow(right) and press it now - starts animation
        if (Input.GetKeyDown(KeyCode.LeftArrow) && _isKeyReleased)
        {
            _currentKey = KeyCode.LeftArrow;
            _isKeyPressed = true;
            _isKeyReleased = false;
            
            Rotate();
        }
        //If we are not pressing the arrow(left) and press it now - starts animation
        else if (Input.GetKeyDown(KeyCode.RightArrow) && _isKeyReleased)
        {
            _currentKey = KeyCode.RightArrow;
            _isKeyPressed = true;
            _isKeyReleased = false;
            
            Rotate();
        }
    }

    //Animation of roll itself based on given angles
    private void Rotate()
    {
        _currentRotationAnimation.Pause();
        
        if (_currentKey==KeyCode.LeftArrow)
        {
            _currentRotationAnimation = this.transform.DORotate(new Vector3(0, 0, _rotationAngle), _rotationSpeed);
        }
        else if (_currentKey==KeyCode.RightArrow)
        {
            _currentRotationAnimation = this.transform.DORotate(new Vector3(0, 0, -_rotationAngle), _rotationSpeed);
        }
            
        _currentRotationAnimation.Play();
    }

    //Controls the collision of ship with asteroids(leads to death) and with ScoreDetectors(increases the score)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            Debug.Log("--------------------------Death------------------------");
            OnDeath?.Invoke();
            Instantiate(_explosion, _explosionInstPoint);
            Instantiate(_flare, _flareInstPoint);
        }
        else if (other.CompareTag("ScoreDetector"))
        {
            GameManager.instance.statsController.AppendAsteroid();
        }
    }

    //Enables gravity in rigidbody to show death animation
    private void EnableGravity()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
    }
}
