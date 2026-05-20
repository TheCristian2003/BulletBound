// Crea este script, así se ve profesional
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    public GameObject gameOverPanel;
    
    private int score = 0;
    private int lives = 5;
    
    void Start()
    {
        gameOverPanel.SetActive(false);
        UpdateUI();
    }
    
    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }
    
    public void RemoveLife()
    {
        lives--;
        UpdateUI();
        
        if (lives <= 0)
        {
            GameOver();
        }
    }
    
    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
    }
    
    void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
    
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}