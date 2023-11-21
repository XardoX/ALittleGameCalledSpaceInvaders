using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image[] energyIcons;

    [SerializeField]
    private Transform energyIconsParent;

    [SerializeField]
    private TextMeshProUGUI scoreText, highscoreText;

    [SerializeField]
    private Slider powerSlider;
    private void Awake()
    {
        energyIcons = energyIconsParent.GetComponentsInChildren<Image>(true);
    }

    public void SetPowerSlider(float power, float lerpDuration)
    {
        powerSlider.DOValue(power, lerpDuration);

    }
    public void SetPowerSlider(float power)
    {
        SetPowerSlider(power, 0.2f);
    }

    public void SetEnergy(int count)
    {
        foreach (var icon in energyIcons)
        {
            icon.gameObject.SetActive(false);
        }

        for (int i = 0; i < energyIcons.Length && i < count; i++)
        {
            energyIcons[i].gameObject.SetActive(true);
        }
    }

    public void DispayScore(int score)
    {
        scoreText.text = $"score: {score}";
    }
    
    public void DisplayHighscore(int highscore)
    {
        highscoreText.text = $"highscore: {highscore}"; 
    }

}
