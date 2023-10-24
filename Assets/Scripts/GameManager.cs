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

    private int score;

    public void ResetGame()
    {
        SceneManager.LoadSceneAsync("Main");
    }

    public void AddScore(int value)
    {
        score += value;
        uiManager.DispayScore(score);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }



}
