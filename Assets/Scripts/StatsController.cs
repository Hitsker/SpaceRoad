using System;
using System.Collections;
using UnityEngine;

/// Class to hold information about current session player stats such as current score, maz score, passed asteroids, passed time. Updates stats view via StatsView
public class StatsController : MonoBehaviour
{
    [SerializeField] private StatsView _statsView;

    private const string MaxScorePref = "MaxScore";

    private int _currentScore;
    private int _currentAsteroids;
    private int _maxScore;
    private float _currentTime=0;
    private bool _isScoreBeaten;

    public int CurrentScore => _currentScore;
    public int CurrentAsteroids => _currentAsteroids;

    public int MaxScore => _maxScore;

    public float CurrentTime => _currentTime;
    public bool IsScoreBeaten => _isScoreBeaten;

    public string CurrentTimeString
    {
        get
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(_currentTime);
            string timeText = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
            return timeText;
        }
    }

    private void Start()
    {
        _currentScore = 0;
        _maxScore = PlayerPrefs.GetInt(MaxScorePref);
        _currentAsteroids = 0;
        _statsView.UpdateCurrentScore(_currentScore);
        _statsView.UpdateMaxScore(_maxScore);
        _statsView.UpdateAsteroids(_currentAsteroids);

        StartCoroutine(Countdown());
    }

    private void AppendScore(int score)
    {
        _currentScore += score;
        //Updates the record if current score is larger than previous record
        if (_currentScore > PlayerPrefs.GetInt(MaxScorePref))
        {
            PlayerPrefs.SetInt(MaxScorePref, _currentScore);
            _statsView.UpdateMaxScore(_currentScore);
            if (!_isScoreBeaten)
            {
                _isScoreBeaten = true;
            }
        }

        _statsView.UpdateCurrentScore(_currentScore);
    }

    public void AppendAsteroid()
    {
        AppendScore(5);
        _currentAsteroids++;
        _statsView.UpdateAsteroids(_currentAsteroids);
    }

    private IEnumerator Countdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            
            _currentTime++;
            _statsView.UpdateTime(_currentTime);
            AppendScore(GameManager.instance.shipParentController.isBoosted ? 2 : 1);
        }
    }
}
