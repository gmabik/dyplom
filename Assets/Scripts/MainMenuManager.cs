using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public GameObject playGamePopup;
    public GameObject settingsPopup;
    public GameObject exitPopup;

    public AudioSource audioSource;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public void OnPlayGameButton()
    {
        PlayClickSound();
        if (playGamePopup != null)
        {
            playGamePopup.SetActive(true);
        }
    }

    public void OnSettingsButton()
    {
        PlayClickSound();
        if (settingsPopup != null)
        {
            settingsPopup.SetActive(true);
        }
    }

    public void OnExitButton()
    {
        PlayClickSound();
        if (exitPopup != null)
        {
            exitPopup.SetActive(true);
        }
    }

    public void ClosePopup(GameObject popup)
    {
        PlayClickSound();
        if (popup != null)
        {
            popup.SetActive(false);
        }
    }

    public void LoadScene1()
    {
        PlayClickSound();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        PlayClickSound();
        Application.Quit();
    }

    public void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

}

