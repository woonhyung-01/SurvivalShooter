using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UIManager uIManager;
    public ZomSpawner zombieSpawner;

    private int score = 0;
    public bool IsGameOver {get; private set;}

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        uIManager.SetScore(score);
    }

    public void AddScore(int add)
    {
        if(IsGameOver)
        {
            return;
        }

        score += add;
        uIManager.SetScore(score);
    }

    public void EndGame()
    {
        IsGameOver = true;
        uIManager.SetActiveGameOverUI(true);

        zombieSpawner.OnEndGame();
        zombieSpawner.enabled = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

}