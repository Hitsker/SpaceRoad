using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPopUp : PopUp
{
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _asteroids;
    [SerializeField] private GameObject _newRecord;
    [SerializeField] private Button _restart;

    //When the instance of the class is created it take player stats from stats controller, so no setup for the popup required
    public override void Start()
    {
        base.Start();
        var statsController = GameManager.instance.statsController;
        _time.text = statsController.CurrentTimeString;
        _score.text = statsController.CurrentScore.ToString();
        _asteroids.text = statsController.CurrentAsteroids.ToString();
        _newRecord.SetActive(statsController.IsScoreBeaten);
        
        _restart.onClick.AddListener(GameController.RestartGame);
        _restart.onClick.AddListener(()=>
        {
            GameManager.instance.audioManager.PlayUI(Sound.Click);
        });
    }
}
