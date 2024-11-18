using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    public GameObject GameOverScreen;  // Reference to the Game Over Screen UI
    public PlayerController Player;    // Reference to the PlayerController script

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the GameOverScreen is hidden at the start
        GameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player has reached the max score
        if (Player.score >= Player.maxScore)
        {
            ShowGameOverScreen();
        }
    }

    void ShowGameOverScreen()
    {
        // Display the Game Over screen
        GameOverScreen.SetActive(true);

        // Optionally, disable the player controls (if needed)
        Player.enabled = false;
    }

    // Method to restart the game
    public void RestartGame()
    {
        // Reload the current scene to restart the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
