using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour
{
    [Header("GameObjects")]
    public Text HealthText;
    public Text ScoreText;
    public GameObject gameOverText;

    public GameManager gameManager;
    public Player player;

    public bool isPaused = false;
    public GameObject menu;

    void Update()
    {
        SetValuesToUIText();
    }

    void SetValuesToUIText()
    {
        //GameManager a = new GameManager(); //Break singleton
        ScoreText.text = "SCORE: " + gameManager.score.ToString();
        HealthText.text = "HP: " + player.playerCurrentHealth.ToString();
    }

    public void MenuButton()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f;
            menu.SetActive(true);
            player.gameObject.SetActive(false);
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1f;
            menu.SetActive(false);
            player.gameObject.SetActive(true);
        }

    }

    public void ExitGame()
    {
        gameManager.SaveScore();
        gameManager.BackToMainMenu();
    }
}
