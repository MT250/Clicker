using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public Player player;

    public float enemySpawnInterval;

    public GameObject enemyPrefab;
    public UI_Controller uiController;
    public GameObject[] enemyObjectPool = new GameObject[5];

    public static GameManager instance;



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
        StartCoroutine("Spawning");
    }

    private void Update()
    {
        HealthCheck();
    }

    void InitializeObjectPool()
    {
        for (int i = 0; i < enemyObjectPool.Length; i++)
        {
            GameObject go = Instantiate(enemyPrefab);
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
                enemyObjectPool[i].transform.position = Random.insideUnitCircle.normalized * 10;
                
                break;
            }
        }

        yield return new WaitForSeconds(enemySpawnInterval);

        StartCoroutine("Spawning");
    }

    void HealthCheck()
    {
        //TODO Not called when player health = 0
        if (player.playerCurrentHealth == 0)
        {
            Time.timeScale = 0f;
            StopCoroutine("Spawning");
            uiController.gameOverText.SetActive(true);
        }
    }
}
