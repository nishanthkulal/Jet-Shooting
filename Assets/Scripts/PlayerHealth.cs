using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Animator playerAnimator;
    private int currentHealth;

    [SerializeField] private Image fillHealthBar;

    private void Start()
    {
        currentHealth = maxHealth; // Initialize player's health
        UpdateHealthBar(); // Ensure the health bar is correctly set initially
    }
    private void OnEnable()
    {
        EventHandler.OnGameStart += GameStart;
    }

    private void OnDisable()
    {
        EventHandler.OnGameStart -= GameStart;
    }

    private void GameStart()
    {
        Debug.Log("Game Start");
        currentHealth = maxHealth; // Reset player's health when the game starts
        UpdateHealthBar(); // Ensure the health bar is correctly set initially
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Astroid"))
        {
            playerAnimator.SetTrigger("Hit");
            currentHealth -= 10; // Decrease health
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health doesn't drop below 0

            UpdateHealthBar();

            if (currentHealth <= 0)
            {
                EventHandler.GameEnd();
                //Destroy(gameObject); // Destroy player object when health is zero
                gameObject.SetActive(false);
            }
        }
    }

    private void UpdateHealthBar()
    {
        Debug.Log("UpdateHealthBar - enetered ");
        if (fillHealthBar != null)
        {
            Debug.Log("UpdateHealthBar - entered if statement");
            fillHealthBar.fillAmount = (float)currentHealth / maxHealth; // Update the fill based on health percentage
        }
    }
}
