using System;
using System.Collections;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    public int score;
    public Player player;

    public float enemySpawnInterval;

    public GameObject enemyPrefab;
    public UI_Controller uiController;
    public GameObject[] enemyObjectPool = new GameObject[5];

    public static GameManager instance;

    private float cameraCornerDis;
    private int topScore;

    private GameManager() //Disable ability to break singleton
    {

    }
    #region Singleton
    private void Awake()
    {
        instance = this;
    }
    #endregion

    void Start()
    {
        InitializeObjectPool();
        GetCameraCornerDis();
        StartCoroutine("Spawning");
        GetTopScore();
    }

    private void GetTopScore()
    {
        string path = Application.persistentDataPath + "/TopScore.score";
        BinaryFormatter binFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(path, FileMode.Open);

        if (File.Exists(path))
        {
            topScore = (int)binFormatter.Deserialize(fileStream);
        }

        fileStream.Close();
    }

    private void GetCameraCornerDis()
    {
        Vector3 corner = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, Camera.main.nearClipPlane));
        cameraCornerDis = Vector3.Distance( player.transform.position, corner);
    }

    private void Update()
    {
        HealthCheck();
    }

    void InitializeObjectPool()
    {
        for (int i = 0; i < enemyObjectPool.Length; i++)
        {
            GameObject go = Instantiate(enemyPrefab, transform.position , Quaternion.identity);
            enemyObjectPool[i] = go;
            go.SetActive(false);
        }
    }
    
    IEnumerator Spawning()
    {
        for (int i = 0; i < enemyObjectPool.Length; i++)
        {
            if (!enemyObjectPool[i].activeSelf)
            {
                enemyObjectPool[i].SetActive(true);
                enemyObjectPool[i].transform.position = UnityEngine.Random.insideUnitCircle.normalized * cameraCornerDis;
                
                break;
            }
        }

        yield return new WaitForSeconds(enemySpawnInterval);

        StartCoroutine("Spawning");
    }

    void HealthCheck()
    {
        if (player.playerCurrentHealth == 0)
        {
            Time.timeScale = 0f;
            StopCoroutine("Spawning");
            uiController.gameOverText.SetActive(true);
            SaveScore();
        }
    }

    void SaveScore()
    {
        string savePath = Application.persistentDataPath + "/TopScore.score";
        BinaryFormatter binFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(savePath, FileMode.Create);


        if (File.Exists(savePath))
        {
            binFormatter.Serialize(fileStream, score);
            fileStream.Close();            
        }       
    }
}
