using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject playGamePopup;
    public GameObject settingsPopup;
    public GameObject exitPopup;

    public void OnPlayGameButton()
    {
        if (playGamePopup != null)
        {
            playGamePopup.SetActive(true);
        }
    }

    public void OnSettingsButton()
    {
        if (settingsPopup != null)
        {
            settingsPopup.SetActive(true);
        }
    }

    public void OnExitButton()
    {
        if (exitPopup != null)
        {
            exitPopup.SetActive(true);
        }
    }

    public void ClosePopup(GameObject popup)
    {
        if (popup != null)
        {
            popup.SetActive(false);
        }
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() 
    { 
    Application.Quit();
    }

}
