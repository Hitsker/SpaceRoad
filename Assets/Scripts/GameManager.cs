using UnityEngine;

/// Class with implementation os singleton to simply access game data
public class GameManager : MonoBehaviour
{
    public SmoothFollow cameraFollow;
    public ShipController shipController;
    public ShipParentController shipParentController;
    public StatsController statsController;
    public GameController gameController;
    public PopUpsContainer popUpsContainer;

    public static GameManager instance = null;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else if (instance==this)
        {
            Destroy(gameObject);
        }
    }

}
