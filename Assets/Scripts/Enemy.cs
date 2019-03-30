using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxEnemyHealth;
    public int currentEnemyHealth;

    public float minRandomMoveSpeed;
    public float maxRandomMoveSpeed;

    private float moveSpeed;
    public Transform playerPosition;

    private void OnEnable()
    {
        currentEnemyHealth = maxEnemyHealth;
        if (playerPosition == null) { playerPosition = GameManager.instance.player.transform; }
        moveSpeed = Random.Range(minRandomMoveSpeed, maxRandomMoveSpeed);
    }

    private void OnMouseDown()
    {
        GameManager.instance.score++;
        gameObject.SetActive(false);
    }

    private void Update()
    {        
        transform.position = Vector3.MoveTowards(transform.position, playerPosition.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.SetActive(false);
            //collision.GetComponent<Player>().Damage();
            GameManager.instance.player.Damage();
        }
    }
    public void Damage()
    {
        currentEnemyHealth--;
        if (currentEnemyHealth <= 0) gameObject.SetActive(false);
    }

}
