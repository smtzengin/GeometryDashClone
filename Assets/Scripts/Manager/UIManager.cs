using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Level Progression Bar & attempt count")]
    public TextMeshPro attemptCountText;
    public Slider LevelSlider;

    [Header("Buttons")]
    public GameObject pausePanel;
    public GameObject muteButton;
    public GameObject openMuteButton;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UIManager.instance.attemptCountText.text = "Attempt " + PlayerPrefs.GetInt("attemptCount").ToString();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ClosePausePanel()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

}
