using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

/// Class to randomly spawn asteroids using ObjectPool
/// Also automatically increases the spawn speed basing on user score
public class AsteroidsSpawner : MonoBehaviour
{
    [Tooltip("Prefabs that will be spawned, should have an AP_Reference component on it")]
    [SerializeField] private GameObject _asteroidPrefab;
    [Space]
    [SerializeField] private float _minX = -2;
    [SerializeField] private float _maxX = 2;
    [SerializeField] private float _spawnOffsetZ = 70;
    [SerializeField] private float _startDelay = 1.5f;
    [SerializeField] private float _minDelay = 0.4f;

    private GameObject spaceShip;
    private void Start()
    {
        spaceShip = GameManager.instance.shipController.gameObject;
        StartCoroutine(SpawnAsteroids());
    }

    /// <summary>
    /// Spawnes asteroids using coroutine. Speed of spawn is constantly increasing(as increases player score) by lerp. The value of spawn interval is limited by two values
    /// </summary>
    private IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            float currentScore = GameManager.instance.statsController.CurrentScore;
            
            if (currentScore>0)
            {
                var delay = Mathf.Clamp(Mathf.Lerp(_startDelay, 0.4f, currentScore/800), 0.2f, _startDelay);
                yield return new WaitForSeconds(delay); 
            }
            else
            {
                yield return new WaitForSeconds(_startDelay); 
            }
            
            SpawnAsteroid();
        }
    }

    /// <summary>
    /// Takes new asteroids from pool to the specific position based on the players sheep position
    /// </summary>
    private void SpawnAsteroid()
    {
        var spawnPoint = new Vector3(Random.Range(_minX, _maxX), 1.5f, spaceShip.transform.position.z + _spawnOffsetZ);
        MF_AutoPool.Spawn(_asteroidPrefab, spawnPoint, Quaternion.identity);
    }
}
