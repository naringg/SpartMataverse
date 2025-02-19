using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    private int currentScore = 0;
    private int highScore = 0;

    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        uiManager = FindObjectOfType<UIManager>();

        // 저장된 최고 기록 불러오기
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
        uiManager.UpdateHighScore(highScore); // 최고 기록 UI 업데이트
    }

    public void GameOver()
    {
        Debug.Log("Game Over");

        // 최고 기록 갱신 확인
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore); // 최고 기록 저장
            PlayerPrefs.Save();
        }

        uiManager.UpdateHighScore(highScore); // UI 반영
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        uiManager.UpdateScore(currentScore);
        if (currentScore % 5 == 0)
        {
            // Player의 forwardSpeed를 업데이트
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                player.IncreaseSpeed(0.5f);
            }
        }
    }
}
