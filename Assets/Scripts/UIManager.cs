using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  public TextMeshProUGUI gameOverText;
  public TextMeshProUGUI scoreText;
  public GameObject gameOverUI;

    private void OnEnable()
    {
        SetActiveGameOverUI(false);
    }

    public void SetScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }
    public void SetActiveGameOverUI(bool active)
    {
        gameOverUI.SetActive(active);
    }
}
