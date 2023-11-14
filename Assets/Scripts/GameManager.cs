using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private UIManager uiManager;

    public UIManager UIManager => uiManager;

    [SerializeField]

    private int score, highscore;

  

    public void ResetGame()
    {
        SceneManager.LoadSceneAsync("Main");
        score = 0;
        uiManager.DispayScore(score);
        uiManager.DisplayHighscore(highscore);
    }

    public void AddScore(int value)
    {
        score += value;
        if (score >= highscore)
        {
            highscore = score;
            uiManager.DisplayHighscore(highscore);

        }
        uiManager.DispayScore(score);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
        }
    }



}
