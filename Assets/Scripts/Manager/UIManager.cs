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
    public MainMenu mainMenu;
    public GameObject levelComplete;

    [Header("Buttons")]
    public GameObject pausePanel;
    public GameObject muteButton;
    public GameObject openMuteButton;

    private void Awake()
    {
        instance = this;
        mainMenu = GetComponent<MainMenu>();
    }

    private void Start()
    {
        UIManager.instance.attemptCountText.text = "Attempt " + PlayerPrefs.GetInt("attemptCount").ToString();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        mainMenu.bestProgression.text ="Best Progression: " + PlayerPrefs.GetFloat("bestProgression").ToString();
        Time.timeScale = 1f;
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
