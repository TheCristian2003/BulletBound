using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Panels")]
    public GameObject victoryPanel;
    public GameObject defeatPanel;

    [Header("Totems")]
    public int totalTotems = 3;
    private int collectedTotems = 0;

    [Header("Portal")]
    public GameObject portal;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;

        victoryPanel.SetActive(false);
        defeatPanel.SetActive(false);

        if (portal != null)
            portal.SetActive(false);
    }

    public void CollectTotem()
    {
        collectedTotems++;

        Debug.Log("Tótems recogidos: " + collectedTotems + "/" + totalTotems);

        if (collectedTotems >= totalTotems)
        {
            if (portal != null)
                portal.SetActive(true);
        }
    }

    public void PlayerDied()
    {
        Time.timeScale = 0f;
        defeatPanel.SetActive(true);
    }

    public void Victory()
    {
        Time.timeScale = 0f;
        victoryPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;

        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextScene);
        else
            SceneManager.LoadScene("MenuPrincipal");
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }
}