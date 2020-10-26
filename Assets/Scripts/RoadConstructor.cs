using System.Collections.Generic;
using UnityEngine;

/// Class to create infinite road. Principle of work: takes the very last peace of road and moves it to the front of the others
/// Used one-dimensional array to hold available peaces 
public class RoadConstructor : MonoBehaviour
{
    [SerializeField] private List<RoadPlatform> _platforms;
    private int _current;
    private int _last;

    private void Start()
    {
        _current = 0;
        _last = +_platforms.Count-1;
        _platforms[_current].OnBecameInvisibleAction += MovePlatform;
    }

    /// <summary>
    /// Moves last peace of road to the front 
    /// </summary>
    private void MovePlatform()
    {
        //Calculating position basing on forward platform position
        var currentPlatform = _platforms[_current];
        var currentPosition = currentPlatform.transform.position;
        currentPlatform.OnBecameInvisibleAction -= MovePlatform;
        currentPlatform.transform.position = new Vector3(currentPosition.x, currentPosition.y, _platforms[_last].EndPoint.position.z + currentPlatform.Size / 2);
        
        if (_current<_platforms.Count-1)
        {
            _current++;
        }
        else
        {
            _current = 0;
        }
        
        if (_last<_platforms.Count-1)
        {
            _last++;
        }
        else
        {
            _last = 0;
        }
        
        _platforms[_current].OnBecameInvisibleAction += MovePlatform;
    }
}
