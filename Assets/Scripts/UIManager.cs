using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image[] energyIcons;

    [SerializeField]
    private Transform energyIconsParent;

    private void Awake()
    {
        energyIcons = energyIconsParent.GetComponentsInChildren<Image>(true);
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

}
