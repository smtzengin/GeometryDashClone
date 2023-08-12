using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;   
    private Camera mainCamera;
    private Vector3 offset;
    [SerializeField] private GameObject BG;
    

    private void Start()
    {
        mainCamera = Camera.main;
        offset = mainCamera.transform.position - target.position;
    }

    private void Update()
    {
        // Karakterin yatay pozisyonu
        float targetX = target.position.x;
        float targetY = target.position.y;

        // Kameranýn yatay pozisyonu
        float cameraX = mainCamera.transform.position.x;
        float cameraY = mainCamera.transform.position.y;

        // Karakterin pozisyonunu takip et
        Vector3 newPosition = new Vector3(targetX + offset.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
        mainCamera.transform.position = newPosition;


        float bgX = target.transform.position.x + 10;

        Vector3 newBGPosition = new Vector3(bgX, BG.transform.position.y, BG.transform.position.z);
        BG.transform.position = newBGPosition;

       
    }
}
