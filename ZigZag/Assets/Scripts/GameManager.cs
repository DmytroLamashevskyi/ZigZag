using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text hightScoreText;
    public static GameManager instance;
    public bool isGameStarted;
    public PlatformSpawner spawner;
    public GameObject UIPanel;
    private int score;
    private int hightScore;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        hightScore = PlayerPrefs.GetInt("HightScore");
        hightScoreText.text = hightScore.ToString();
    }

    public void Update()
    {
        if (!isGameStarted && Input.GetMouseButtonDown(0))
        {
            GameStart();
        }
    }

    public void GameStart()
    {
        UIPanel.SetActive(false);
        scoreText.gameObject.SetActive(true);
        isGameStarted = true;
        spawner.gameObject.SetActive(true);
        StartCoroutine(UpdateScore());
    }

    public void GameOver()
    {
        isGameStarted = false;
        spawner.gameObject.SetActive(false);
        SaveHigthScore();
        StopCoroutine("UpdateScore");
        Invoke("ReloadLevel", 3);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator UpdateScore()
    {
        while (isGameStarted)
        {
            yield return new WaitForSeconds(1);
            score++;
            scoreText.text = score.ToString();
        }
    }

    void SaveHigthScore()
    {
        if (PlayerPrefs.HasKey("HightScore"))
        {
            if(score> PlayerPrefs.GetInt("HightScore"))
            {
                PlayerPrefs.SetInt("HightScore", score);
            }

        }
        else
        {
            PlayerPrefs.SetInt("HightScore", 0);
        }
    }
}
