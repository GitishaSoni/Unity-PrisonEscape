using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public int secretItemsCollected = 0;
    public int totalSecretItems = 3;

    public Text scoreText;             // UI Text for score
    public Text secretItemText;        // UI Text for secret items
    public Text healthText;            // UI Text for health display
    public Text gameOverText;          // UI Text for game over message
    public Text winText;               // UI Text for "Prisoner Escaped" or door unlocked
    public Text doorStatusText;        // UI Text for door status (locked/unlocked)

    public GameObject doorCollider;    // Reference to the cube door

    private bool isGameOver = false;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Initially hide all texts at the start of the game
        HideAllTexts();

        UpdateUI();
    }

    // Hide all texts initially
    private void HideAllTexts()
    {
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);  // Hide game over text

        if (winText != null)
            winText.gameObject.SetActive(false);  // Hide win text

        if (doorStatusText != null)
            doorStatusText.text = "Door is Locked";  // Show locked message initially
    }

    // Called when player collects a coin
    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
        Debug.Log("Coin collected! Score: " + score);
    }

    // Called when player collects a secret item
    public void CollectSecretItem()
    {
        secretItemsCollected++;
        AddScore(10); // Bonus score for secret item
        UpdateUI();

        if (secretItemsCollected >= totalSecretItems)
        {
            Debug.Log("✅ All secret items collected!");

            if (doorCollider != null)
            {
                doorCollider.GetComponent<Collider>().enabled = false; // Unlock door
            }

            if (winText != null)
            {
                winText.text = "Prisoner Escaped! You Can Now Escape!";
                winText.gameObject.SetActive(true); // Show "Prisoner Escaped" message
            }

            if (doorStatusText != null)
            {
                doorStatusText.text = "Door Unlocked"; // Change text to unlocked
            }
        }
    }

    // Called by PlayerHealth when health reaches 0
    public void LoseLife()
    {
        if (isGameOver) return;

        isGameOver = true;

        if (gameOverText != null)
        {
            gameOverText.text = "Game Over";
            gameOverText.gameObject.SetActive(true); // Show game over text
        }

        Time.timeScale = 0f; // Pause the game
    }

    // Called by PlayerHealth to update health display
    public void UpdateHealthDisplay(int currentHealth, int maxHealth)
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth + "/" + maxHealth;
        }
    }

    // Updates all UI elements
    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (secretItemText != null)
            secretItemText.text = "Secret Items: " + secretItemsCollected + "/" + totalSecretItems;
    }
}
