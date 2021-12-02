using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameStats : MonoBehaviour
{
    public int Score;
    public float MultipleDifficult;

    [SerializeField] private Text _score;
    [SerializeField] private Text _scoreUp;
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private UnityEvent isSpawned;

    private int _bestScore;
    private YandexSDK SDK;

    private void Start()
    {
        SDK = YandexSDK.Instance;
        isSpawned.Invoke();
        if (PlayerPrefs.HasKey("BestScore"))
        {
            _bestScore = PlayerPrefs.GetInt("BestScore");
        }
        _bestScoreText.text = "Best " + _bestScore.ToString();
    }
    private void FixedUpdate()
    {
        if(MultipleDifficult <= 4f)
        MultipleDifficult += 0.04f * Time.deltaTime;
    }

    public void ScoreUp(int count)
    {
        Score += count;
        _score.text = Score.ToString();
        _scoreUp.gameObject.SetActive(true);
        _scoreUp.text = "+ "+count.ToString();
        if (Score>_bestScore)
        {
            _bestScore = Score;
            PlayerPrefs.SetInt("BestScore", _bestScore);
            _bestScoreText.text = "Best " + _bestScore.ToString();
            SetLeaderBoard();
        }
    }

    public void SetLeaderBoard() => SDK.setLeaderScore(_bestScore);
}
