using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Sprite currentSprite;
    [SerializeField] private Sprite targetSprite;

    [SerializeField] private float totalDistance;

    public int attemptCount;
      

    private void Awake()
    {
        Instance = this;
        playerController = FindObjectOfType<PlayerController>();
        currentSprite = playerController.GetComponent<Sprite>();
    }

    private void Start()
    {
        attemptCount = PlayerPrefs.GetInt("attemptCount");
        totalDistance = Vector2.Distance(_startPoint.position, _endPoint.position);
    }

    private void Update()
    {
        float characterDistance = Vector2.Distance(_startPoint.position, playerController.transform.position);

        // Aradaki mesafeyi yüzde olarak hesapla
        float percentage = (characterDistance / totalDistance) * 100f;

        //Debug.Log("Distance traveled: " + percentage.ToString("F2") + "%");
    }


    public void ChangePlayerSprite()
    {
        if(targetSprite != null)
        {
            Sprite tempSprite = currentSprite;
            currentSprite = targetSprite;
            targetSprite = tempSprite;

            playerController.GetComponent<SpriteRenderer>().sprite = currentSprite;
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
