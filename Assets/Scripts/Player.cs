using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Parameters")]
    public int playerMaxHealth;

    [SerializeField]
    public int playerCurrentHealth;

    private void Awake()
    {
        playerCurrentHealth = playerMaxHealth;

    }

    public void Damage()
    {
        playerCurrentHealth--;
    }
}
