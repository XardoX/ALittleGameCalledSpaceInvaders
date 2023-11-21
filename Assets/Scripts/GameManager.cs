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

    [SerializeField]
    private float powerProgressAmount;

    private Player player;

    private float powerProgress;

    private bool godMode;

    public void ResetGame()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        uiManager.SetEnergy(3);
        SceneManager.LoadSceneAsync("Main");
        score = 0;
        powerProgress = 0;
        uiManager.DispayScore(score);
        uiManager.DisplayHighscore(highscore);
    }

    public void AddScore(int value)
    {
        score += value;
        if(godMode == false)
        {
            powerProgress += powerProgressAmount;
            if(powerProgress >= 1)
            {
                StartCoroutine(GodMode());
            }
        }
        if (score >= highscore)
        {
            highscore = score;
            uiManager.DisplayHighscore(highscore);

        }
        uiManager.SetPowerSlider(powerProgress);
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
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    private  void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
        }
    }

    private IEnumerator GodMode()
    {
        godMode = true;
        player.ToggleGodMode(true);
        powerProgress = 0;
        uiManager.SetPowerSlider(powerProgress, 1f);
        yield return new WaitForSeconds(1f);
        player.ToggleGodMode(false);

    }

}
