using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    float killCount = 0;
    public TextMeshProUGUI killCountText;
    public TextMeshProUGUI killCountGameOverText;

    public void AddKill()
    {
        killCount++;
    }

    private void Update()
    {
        killCountText.text = "Kill Count: " + killCount.ToString();

        if (killCountGameOverText != null)
            killCountGameOverText.text = "Kill Count: " + killCount.ToString();
    }
}