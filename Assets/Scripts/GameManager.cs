using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] StartGameObjects;
    [SerializeField] private GameObject SatrtPanle;
    [SerializeField] private GameObject EndGamePanle;

    //[SerializeField] private TMP_Text _PlayerHealth;
    [SerializeField] private TMP_Text _PlayerScore;

    private void OnEnable()
    {
        EventHandler.OnGameEnd += EndGame;
        EventHandler.OnGameEndScore += GameScore;
    }

    private void OnDisable()
    {
        EventHandler.OnGameEnd -= EndGame;
        EventHandler.OnGameEndScore -= GameScore;
    }

    private void GameScore(int obj)
    {
        _PlayerScore.text = obj.ToString();
    }

    public void StartGame()
    {

        SatrtPanle.SetActive(false);
        EndGamePanle.SetActive(false);
        foreach (GameObject obj in StartGameObjects)
        {
            obj.SetActive(true);
        }
        EventHandler.GameStart();

    }


    public void EndGame()
    {
        EndGamePanle.SetActive(true);
        foreach (GameObject obj in StartGameObjects)
        {
            obj.SetActive(false);
        }
    }

}
