using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playBtn;
    public GameObject muteBtn;
    public GameObject openMutebtn;

    public TextMeshProUGUI bestProgression;

    private void Awake()
    {
        bestProgression.text = "Best Progression: " + PlayerPrefs.GetFloat("bestProgression").ToString();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void CloseAllSounds()
    {
        if (AudioManager.Instance.mainLevelAudio.volume > 0)
        {
            muteBtn.SetActive(false);
            openMutebtn.SetActive(true);
            AudioManager.Instance.mainLevelAudio.volume = 0f;
            AudioManager.Instance.deathAudio.volume = 0f;
        }
    }

    public void OpenAllSounds()
    {
        muteBtn.SetActive(true);
        openMutebtn.SetActive(false);
        AudioManager.Instance.mainLevelAudio.volume = .3f;
        AudioManager.Instance.deathAudio.volume = .3f;
    }
}
