using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AsteroidDespawner"))
        {
            MF_AutoPool.Despawn(this.gameObject);
        }
    }
}
