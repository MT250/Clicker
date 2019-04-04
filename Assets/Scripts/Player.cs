using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Parameters")]
    public int playerMaxHealth;

    public int playerCurrentHealth;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        playerCurrentHealth = playerMaxHealth;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        StartCoroutine("FadeToColor");
    }

    private IEnumerator FadeToColor()
    {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255), Random.Range(.1f,.9f));
        yield return new WaitForSeconds(Random.Range(3, 6));
        StartCoroutine("FadeToColor");
    }

    public void Damage()
    {
        playerCurrentHealth--;
    }
}
