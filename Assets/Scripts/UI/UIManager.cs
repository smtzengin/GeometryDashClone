using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshPro attemptCountText;
    public Slider LevelSlider;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UIManager.instance.attemptCountText.text = "Attempt " + PlayerPrefs.GetInt("attemptCount").ToString();
    }



}
