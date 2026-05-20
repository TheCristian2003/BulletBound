using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Panels")]
    public GameObject victoryPanel;
    public GameObject defeatPanel;

    private int enemiesAlive;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;

        victoryPanel.SetActive(false);
        defeatPanel.SetActive(false);

        enemiesAlive = FindObjectsByType<GruntScript>(FindObjectsSortMode.None).Length;
    }

    public void EnemyKilled()
    {
        enemiesAlive--;

        Debug.Log("Enemigos restantes: " + enemiesAlive);

        if (enemiesAlive <= 0)
        {
            Victory();
        }
    }

    public void PlayerDied()
    {
        Defeat();
    }

    private void Victory()
    {
        Time.timeScale = 0f;
        victoryPanel.SetActive(true);
    }

    private void Defeat()
    {
        Time.timeScale = 0f;
        defeatPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;

        int currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene + 1);
    }
}