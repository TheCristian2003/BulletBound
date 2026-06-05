using UnityEngine;
using UnityEngine.UI;

public class HeartsUI : MonoBehaviour
{
    public static HeartsUI Instance;

    public Image[] hearts;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentHealth;
        }
    }
}