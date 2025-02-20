using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI restartText;
    // Start is called before the first frame update
    void Start()
    {
        if (restartText == null)
            Debug.LogError("restart text is null");

        if(scoreText == null)
            Debug.LogError("score text is null");

        restartText.gameObject.SetActive(false);

    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateHighScore(int highScore)
    {
        highScoreText.text = "High Score: " + highScore.ToString();
    }


}
