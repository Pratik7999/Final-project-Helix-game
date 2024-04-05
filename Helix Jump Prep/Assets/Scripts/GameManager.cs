using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager singleton;
    public int best;
    public int score;
    public int currentStage = 0;
    

    private void Awake()
    {
        if (singleton == null)
            singleton = this;
        else if (singleton != this)
            Destroy(gameObject);

        // Load the saved highscore
        best = PlayerPrefs.GetInt("Highscore");
    }

    public void NextLevel()
    {
        currentStage++;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);
    }

    public void RestartLevel()
    {
        Debug.Log("Restarting Level");
        // Show Adds Advertisement.Show();
        singleton.score = 0;
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<HelixController>().LoadStage(currentStage);
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;

        if (score > best)
        {
            PlayerPrefs.SetInt("Highscore", score);
            best = score;
        }
    }


}
public class LevelManager : MonoBehaviour
{
    public int totalLevels = 3; // Set the total number of levels
    private int completedLevels = 0;

    // Call this method when a level is completed
    public void LevelCompleted()
    {
        completedLevels++;
        if (completedLevels >= totalLevels)
        {
            EndGame();
        }
    }

    // End the game
    private void EndGame()
    {
        Debug.Log("All levels completed! Game over.");
        // You can add any additional logic here such as displaying a game over screen or returning to the main menu.
        // For simplicity, this example only logs a message to the console.
        Application.Quit(); // This line quits the application. You might want to replace it with your own logic.
    }
}