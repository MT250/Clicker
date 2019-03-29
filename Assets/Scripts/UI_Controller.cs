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

    void SetBordersPositions()
    {
        
    }
}
