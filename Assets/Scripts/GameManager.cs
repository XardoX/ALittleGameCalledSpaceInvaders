using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public void ResetGame()
    {
        SceneManager.LoadSceneAsync("Main");
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
