using System;
using TMPro;
using UnityEngine;

/// Class to  control and update the view of the stats on the screen
public class StatsView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _maxScore;
    [SerializeField] private TextMeshProUGUI _asteroids;
    [SerializeField] private TextMeshProUGUI _time;


    public void UpdateCurrentScore(int score)
    {
        _currentScore.text = score.ToString();
    }

    public void UpdateMaxScore(int score)
    {
        _maxScore.text = score.ToString();
    }

    public void UpdateAsteroids(int asteroids)
    {
        _asteroids.text = asteroids.ToString();
    }

    public void UpdateTime(float currentTime)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
        string timeText = $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
        _time.text = timeText;
    }
}
