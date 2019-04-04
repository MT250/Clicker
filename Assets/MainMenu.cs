using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Range(1f, 20f)]
    public float colorLerpSpeed = 10f;
    public Text scoreText;

    private void Awake()
    {
        string path = Application.persistentDataPath + "/TopScore.score";
        BinaryFormatter binFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(path, FileMode.Open);

        if (File.Exists(path))
        {
            scoreText.text += "\n" + binFormatter.Deserialize(fileStream).ToString();
        }
        else
        {
            scoreText.text += "\n0";
        }
    }

    private void Update()
    {
        FadeColor();
    }

    void FadeColor()
    {
        scoreText.color = Color.Lerp(scoreText.color, Random.ColorHSV(), colorLerpSpeed * Time.deltaTime);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
