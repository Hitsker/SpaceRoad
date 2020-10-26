using DG.Tweening;
using UnityEngine;

/// Class to  control the forward and horizontal movements of the ship
public class ShipParentController : MonoBehaviour
{
    [SerializeField] private float _horizontalSpeed = 8.0f;
    [SerializeField] private float _forwardSpeed = 20.0f;
    [SerializeField] private float _maxXPosition = 2;
    public bool isBoosted;

    private float _currentSpeed;
    private bool _isStops;

    private void Start()
    {
        isBoosted = false;
        _currentSpeed = _forwardSpeed;
        GameManager.instance.shipController.OnDeath += StopMovement;
    }

    void Update()
    {
        //If stops moves forward with decreasing speed
        if (_isStops)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _currentSpeed);
            return;
        }
        
        //If we press the space button - increase the speed 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isBoosted = true;
            _currentSpeed = _forwardSpeed * 2;
           GameManager.instance.cameraFollow.Zoom();
        }

        //If we unpress the space button - decrease the speed 
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isBoosted = false;
            _currentSpeed = _forwardSpeed;
            GameManager.instance.cameraFollow.Reset();
        }
        
        //Constant forward movement
        transform.Translate(Vector3.forward * (Time.deltaTime * _currentSpeed));
        MoveHorizontal();
    }

    
    private void MoveHorizontal()
    {
        //Check for bounds of the track
        if (Input.GetAxis("Horizontal")<0 && transform.position.x<0 && Mathf.Abs(transform.position.x)>=_maxXPosition
            ||Input.GetAxis("Horizontal")>0 && transform.position.x>0 && Mathf.Abs(transform.position.x)>=_maxXPosition
        )
        {
            
        }
        else
        {
            //Horizontal movement
            transform.Translate(Input.GetAxis("Horizontal")*_horizontalSpeed*Time.deltaTime, 0, 0);
        }
    }
    
    private void StopMovement()
    {
        _isStops = true;
        //smooth decrease of speed
        DOTween.To(()=> _currentSpeed, x=> _currentSpeed = x, 0, 1);
    }
}
