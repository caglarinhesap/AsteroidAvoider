using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner asteroidSpawner;

    public void EndGame()
    {
        asteroidSpawner.enabled = false;

        int finalScore = scoreSystem.EndTimer();
        gameOverText.text = "Your Score: " + finalScore.ToString();

        gameOverDisplay.gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
