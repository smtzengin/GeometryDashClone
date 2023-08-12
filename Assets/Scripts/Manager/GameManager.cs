using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Variables")]
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Sprite currentSprite;
    [SerializeField] private Sprite targetSprite;

    [Header("Level percentage")]
    [SerializeField] private float totalDistance;
    [SerializeField] private float percentage;

    public int attemptCount;
      

    private void Awake()
    {
        Instance = this;
        playerController = FindObjectOfType<PlayerController>();
        currentSprite = playerController.gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    private void Start()
    {
        attemptCount = PlayerPrefs.GetInt("attemptCount");
        totalDistance = Vector2.Distance(_startPoint.position, _endPoint.position);
    }

    private void Update()
    {
        float characterDistance = Vector2.Distance(_startPoint.position, playerController.transform.position);

        percentage = (characterDistance / totalDistance) * 100f;

        UIManager.instance.LevelSlider.value = percentage / 100f;

        if(PlayerPrefs.GetFloat("bestProgression") < percentage)
            PlayerPrefs.SetFloat("bestProgression", percentage);
    }


    public void ChangePlayerSprite()
    {
        if(targetSprite != null)
        {
            Sprite tempSprite = currentSprite;
            currentSprite = targetSprite;
            targetSprite = tempSprite;

            playerController.gameObject.GetComponent<SpriteRenderer>().sprite = currentSprite;
        }
    }

    public void IncreaseAttemptCount()
    {
        attemptCount++;
        PlayerPrefs.SetInt("attemptCount", attemptCount);
    }

    public Transform StartPoint()
    {
        return _startPoint;
    }



}
