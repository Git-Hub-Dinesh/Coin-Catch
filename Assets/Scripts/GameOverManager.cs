using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text livesText;

    private int lives = 3;
    private Vector3 currentRespawnPoint;

    void Start()
{
    currentRespawnPoint = Object.FindFirstObjectByType<Playermovement>().transform.position;
    gameOverPanel.SetActive(false);
    UpdateLivesUI();
}


    public void PlayerHit()
    {
        lives--;
        UpdateLivesUI();

        if (lives <= 0)
        {
            ShowGameOver();
        }
    }

    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        currentRespawnPoint = checkpointPosition;
    }

    public Vector3 GetRespawnPoint()
    {
        return currentRespawnPoint;
    }

    public bool HasLivesLeft()
    {
        return lives > 0;
    }
  public void ResetAllFallingTraps()
{
    FallingTrap[] traps = Object.FindObjectsByType<FallingTrap>(FindObjectsSortMode.None);
    foreach (FallingTrap trap in traps)
    {
        trap.ResetTrapPosition();
    }
}

    void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
