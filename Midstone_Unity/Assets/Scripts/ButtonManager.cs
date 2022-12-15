using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject CreditsPanelCanvas;

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGameScene()
    {
        Application.Quit();
    }
    public void CreditsGameScene()
    {
        CreditsPanelCanvas.SetActive(true);
    }
}
