using UnityEngine;
using UnityEngine.UI;

public class PlayerTrigger : MonoBehaviour
{
    public GameObject gameOverPanel; // Assign this in Inspector
    public Text messageText;         // Assign this in Inspector

    void Start()
    {
        // Make sure the panel and message are hidden at start
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (messageText != null)
            messageText.text = "";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FinalGround"))
        {
            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);

            if (messageText != null)
                messageText.text = "Prisoner Escaped!";

            Time.timeScale = 0f; // Pause the game
        }
    }
}
