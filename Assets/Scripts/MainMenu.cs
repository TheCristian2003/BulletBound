using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject levelsMenu;
    public GameObject mainMenu;

    // PANEL OPCIONES
    public void OpenOptionsPanel()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void OpenMainMenuPanel()
    {
        mainMenu.SetActive(true);

        optionsMenu.SetActive(false);
        levelsMenu.SetActive(false);
    }

    // PANEL NIVELES
    public void OpenLevelsPanel()
    {
        mainMenu.SetActive(false);
        levelsMenu.SetActive(true);
    }

    // CARGAR NIVELES
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    // BOTON JUGAR
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    // SALIR
    public void QuitGame()
    {
        Application.Quit();
    }
}