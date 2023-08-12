using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioListener audioListener;

    public AudioSource mainLevelAudio;

    public AudioSource deathAudio;



    private void Awake()
    {
        Instance = this;

        
    }

    public void CloseAllSounds()
    {
        if (audioListener != null && mainLevelAudio.volume > 0)
        {
            UIManager.instance.muteButton.SetActive(false);
            UIManager.instance.openMuteButton.SetActive(true);
            mainLevelAudio.volume = 0f;
            deathAudio.volume = 0f;
        }
    }

    public void OpenAllSounds()
    {
        UIManager.instance.muteButton.SetActive(true);
        UIManager.instance.openMuteButton.SetActive(false);
        mainLevelAudio.volume = .3f;
        deathAudio.volume = .3f;
    }

}
