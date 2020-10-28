using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject gameOver;
    [SerializeField] AudioClip _gameoverSound;
    public PlayerHealth playerHealth;

    int _currentScore;

    void Update()
    {
        // Increase Score
        //TODO replace with real implementation later
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menu.SetActive(true);
        }
        if (playerHealth.health == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            AudioHelper.PlayClip2D(_gameoverSound, 1);
            gameOver.SetActive(true);
        }

    }
    public void IncreaseScore(int scoreIncrease)
    {
        // increase score
        _currentScore += scoreIncrease;
        // update score display, so we can see the new score
        _currentScoreTextView.text =
            "Score: " + _currentScore.ToString();
    }
    public void ExitLevel()
    {
        // compare score to high score
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (_currentScore > highScore)
        {
            // save current score as new high score
            PlayerPrefs.SetInt("HighScore", _currentScore);
            Debug.Log("New high score: " + _currentScore);
        }
        // load new level
        SceneManager.LoadScene("MainMenu");

    }
    public void ReloadLevel()
    {
        Debug.Log("New high score: " + _currentScore);
        SceneManager.LoadScene("Level01");
    }
}
