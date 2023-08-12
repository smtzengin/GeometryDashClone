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
        if(PlayerPrefs.GetFloat("bestProgression") == 0)
        {
            bestProgression.text = "Best Progression: 0" ;
        }
        else
        {
            bestProgression.text = "Best Progression: " + PlayerPrefs.GetFloat("bestProgression").ToString();
        }

    }

    public void Play()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
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
