using UnityEngine;

/// Class that holds all popups to access them via GameManager
public class PopUpsContainer : MonoBehaviour
{
    [SerializeField] private GameObject _parent;
    [SerializeField] private GameOverPopUp _gameOverPopUp;
    [SerializeField] private StartGamePopUp _startGamePopUp;
    [SerializeField] private SettingsPopUp _settingsPopUp;

    public void ShowGameOverPopUp()
    {
        ShowGameOverPopUp(2f);
    }

    private void ShowGameOverPopUp(float delay)
    {
        var popUp = Instantiate(_gameOverPopUp, _parent.transform);
        popUp.Show(delay);
    }

    public void ShowStartPopUp(float delay = 0)
    {
        var popUp = Instantiate(_startGamePopUp, _parent.transform);
        popUp.Show(delay);
    }

    public void ShowSettingsPopup(float delay = 0)
    {
        var popUp = Instantiate(_settingsPopUp, _parent.transform);
        popUp.Show(delay);
    }
}
