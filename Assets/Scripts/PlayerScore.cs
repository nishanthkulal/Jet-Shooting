using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int score = 0;

    private void OnEnable()
    {
        EventHandler.OnColiderDestroy += AddScore;
        EventHandler.OnGameEnd += GameEnded;
        EventHandler.OnGameStart += GameStart;
    }

    private void OnDisable()
    {
        EventHandler.OnColiderDestroy -= AddScore;
        EventHandler.OnGameEnd -= GameEnded;
        EventHandler.OnGameStart += GameStart;
    }

    private void GameStart()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    private void AddScore(int obj)
    {
        score += obj;
        scoreText.text = score.ToString();
    }
    private void GameEnded()
    {
        EventHandler.GameEndScore(score);
    }
}
